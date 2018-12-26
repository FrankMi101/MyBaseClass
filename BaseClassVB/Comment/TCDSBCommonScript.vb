Imports System.Web
Namespace TCDSB
    Namespace Student
        Public Class Scripts

            Public Shared Function DetectResolution() As String
                Dim s As New System.Text.StringBuilder("")

                s.Append("<SCRIPT LANGUAGE='Javascript'>")
                s.Append("function getexpirydate( nodays){")
                s.Append("var UTCstring;")
                s.Append("Today = new Date();")
                s.Append("nomilli=Date.parse(Today);")
                s.Append("Today.setTime(nomilli+nodays*24*60*60*1000);")
                s.Append("UTCstring = Today.toUTCString();")
                s.Append("return UTCstring;")
                s.Append("}")
                s.Append("function getcookie(cookiename) {")
                s.Append("var cookiestring=''+document.cookie;")
                s.Append("var index1=cookiestring.indexOf(cookiename);")
                s.Append("if (index1==-1 || cookiename=='') return '';")
                s.Append("var index2=cookiestring.indexOf(';',index1);")
                s.Append("if (index2==-1) index2=cookiestring.length;")
                s.Append("return unescape(cookiestring.substring(index1+cookiename.length+1,index2));")
                s.Append("}")
                s.Append("function setcookie(name,value,duration){")
                s.Append("cookiestring=name+'='+escape(value)+';EXPIRES='+getexpirydate(duration);")
                s.Append("document.cookie=cookiestring;")
                s.Append("if(!getcookie(name)){")
                s.Append("return false;")
                s.Append("}")
                s.Append("else{")
                s.Append("return true;")
                s.Append("}")
                s.Append("}")
                s.Append("</SCRIPT>")

                s.Append("<script LANGUAGE='Javascript'>")
                s.Append("var resolution=window.screen.width+'*'+window.screen.height;")
                s.Append("setcookie('Resolution', resolution, 10)")
                s.Append("</script>")

                Return s.ToString
            End Function


            Public Shared Function GetResolutionCookie() As String
                If HttpContext.Current.Request.Cookies("Resolution") Is Nothing Then
                    Return String.Empty
                Else
                    Return HttpContext.Current.Request.Cookies("Resolution").Value
                End If
            End Function


            Public Shared Function WarningMessage(ByRef msg As String) As String

                Dim js As New System.Text.StringBuilder("")

                js.Append("<Script LANGUAGE='JavaScript'>" & vbCrLf)

                js.Append("window.alert('" & msg & "');")

                js.Append("</SCRIPT>")

                Return js.ToString

                'RegisterStartupScript("OpenWinScript", js.ToString())

                'Me.Page.RegisterClientScriptBlock("OpenWinScript", js.ToString())
            End Function
            Public Shared Sub WarningMessage(ByRef pg As System.Web.UI.Page, ByRef msg As String)

                Dim js As New System.Text.StringBuilder("")

                js.Append("<Script LANGUAGE='JavaScript'>" & vbCrLf)

                js.Append("window.alert('" & msg & "');")

                js.Append("</SCRIPT>")

                pg.RegisterClientScriptBlock("User Message", js.ToString)

                'Return js.ToString

                'RegisterStartupScript("OpenWinScript", js.ToString())

                'Me.Page.RegisterClientScriptBlock("OpenWinScript", js.ToString())
            End Sub
        End Class
    End Namespace
End Namespace


