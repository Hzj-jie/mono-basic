' 
' Visual Basic.Net Compiler
' Copyright (C) 2004 - 2007 Rolf Bjarne Kvinge, RKvinge@novell.com
' 
' This library is free software; you can redistribute it and/or
' modify it under the terms of the GNU Lesser General Public
' License as published by the Free Software Foundation; either
' version 2.1 of the License, or (at your option) any later version.
' 
' This library is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' Lesser General Public License for more details.
' 
' You should have received a copy of the GNU Lesser General Public
' License along with this library; if not, write to the Free Software
' Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
' 
Public Class ResumeStatement
    Inherits Statement

    Private m_IsResumeNext As Boolean

    Sub New(ByVal Parent As ParsedObject, ByVal IsResumeNext As Boolean)
        MyBase.New(Parent)
        m_IsResumeNext = IsResumeNext
    End Sub

    Friend Overrides Function GenerateCode(ByVal Info As EmitInfo) As Boolean
        Dim result As Boolean = True

        Dim ResumeOK As Label = Info.ILGen.DefineLabel

        Dim block As CodeBlock = Me.FindFirstParent(Of CodeBlock)()
        Dim lastblock As CodeBlock = block
        Do Until lastblock Is Nothing
            block = lastblock
            lastblock = block.FindFirstParent(Of CodeBlock)()
        Loop

        'Clear the error.
        Emitter.EmitCall(Info, Compiler.TypeCache.MS_VB_CS_PD_ClearProjectError)

        'Test if the code is in an exception handler
        Emitter.EmitLoadVariable(Info, block.IsInUnstructuredHandler)
        Info.Stack.SwitchHead(Compiler.TypeCache.Integer, Compiler.TypeCache.Boolean)
        Emitter.EmitBranchIfTrue(Info, ResumeOK)

        'If code is not in an exception handler raise an error
        Emitter.EmitLoadI4Value(Info, -2146828268)
        Emitter.EmitCall(Info, Compiler.TypeCache.MS_VB_CS_PD_CreateProjectError__Integer)
        Emitter.EmitThrow(Info)

        Info.ILGen.MarkLabel(ResumeOK)
        'Load the instruction switch index
        Emitter.EmitLoadVariable(Info, block.CurrentInstruction)
        'Increment the instruction pointer if it is a Resume Next statement
        If m_IsResumeNext Then
            Emitter.EmitLoadI4Value(Info, 1)
            Emitter.EmitAdd(Info, Compiler.TypeCache.Integer)
        End If
        'If everything is ok, jump to the instruction switch (adding one to the instruction if necessary)
        Emitter.EmitLeave(Info, block.UnstructuredSwitchHandler)

        Return result
    End Function


#If DEBUG Then
    Public Sub Dump(ByVal Dumper As IndentedTextWriter)
        If m_IsResumeNext Then
            Dumper.WriteLine("Resume Next")
        Else
            Dumper.WriteLine("Resume")
        End If
    End Sub
#End If

    Public Overrides Function ResolveStatement(ByVal Info As ResolveInfo) As Boolean
        Dim result As Boolean = True

        Compiler.Helper.AddCheck("Resume statement can only occur in methods with no structured exception handling.")

        Dim block As CodeBlock = Me.FindFirstParent(Of CodeBlock)()
        block.HasUnstructuredExceptionHandling = True
        block.HasResume = True

        Return True
    End Function
End Class