'
' ContextValue.vb
'
' Authors:
'   Rolf Bjarne Kvinge (RKvinge@novell.com>
'
' Copyright (C) 2007 Novell (http://www.novell.com)
'
' Permission is hereby granted, free of charge, to any person obtaining
' a copy of this software and associated documentation files (the
' "Software"), to deal in the Software without restriction, including
' without limitation the rights to use, copy, modify, merge, publish,
' distribute, sublicense, and/or sell copies of the Software, and to
' permit persons to whom the Software is furnished to do so, subject to
' the following conditions:
' 
' The above copyright notice and this permission notice shall be
' included in all copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
' EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
' MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
' NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
' LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
' OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
' WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
'
Imports System.ComponentModel
Namespace Microsoft.VisualBasic.MyServices.Internal
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Class ContextValue(Of T)

        '<MonoLimitationAttribute("Microsoft.VisualBasic.MyServices.Internal.ContextValue(Of T) is not supported.") _
        Public Sub New()
            ' Throw New NotImplementedException
        End Sub

        '<MonoLimitationAttribute("Microsoft.VisualBasic.MyServices.Internal.ContextValue(Of T) is not supported.") _
        Public Property Value() As T
            Get
                'Throw New NotImplementedException
                Return Nothing
            End Get
            Set(ByVal value As T)
                'Throw New NotImplementedException
            End Set
        End Property
    End Class
End Namespace
