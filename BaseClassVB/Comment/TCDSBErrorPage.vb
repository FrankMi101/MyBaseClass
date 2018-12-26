Imports System.web
Namespace TCDSB
    Namespace Student
        Namespace Common
            Public Class ErrorPage
                Inherits System.Web.UI.Page

                Public Shared Sub ShowErrorPage(Optional ByVal ErrorMSG As String = "System experierence some techinical difficulty, please contact HelpDesk for help.")

                    Dim errorPage As String
                    errorPage = "<%@ Register TagPrefix='uc1' TagName='header' Src='inc/header.ascx %>"
                    errorPage += "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>"
                    errorPage += "<HTML>"
                    errorPage += "<HEAD>"
                    errorPage += "<title>ErrPage</title>"
                    errorPage += "<script language='javascript'>"
                    errorPage += "function GoBack()"
                    errorPage += "{ history.back();}"
                    errorPage += "</script>"
                    errorPage += "</HEAD>"
                    errorPage += "<body topmargin='0' leftmargin='0' rightmargin='0'>"

                    'errorPage += "<TABLE id='Table2' style='BORDER-COLLAPSE: collapse' cellSpacing='0' cellPadding='0' width='100%' border='0'>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD bgColor='#7c7c7c' colSpan='2'><IMG src='Images/shim.gif'></TD>"
                    'errorPage += "</TR>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD><IMG id='Image3' src='Images/tcdsblogo_new.gif' border='0'></TD>"
                    'errorPage += "<TD vAlign='top'>"
                    'errorPage += "<TABLE id='LinkTable' style='BORDER-COLLAPSE: collapse' cellSpacing='0' cellPadding='0' width='100%' border='0'>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD vAlign='top' align='right' height='20' width='30%'>"
                    'errorPage += "<IMG src='Images/shim.gif'>"
                    'errorPage += "</TD>"
                    'errorPage += "<TD align='right' width='70%' height='20'>"
                    'errorPage += "<TABLE id='Table1' cellSpacing='0' cellPadding='0' width='100%' border='0' align='right'>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD noWrap>"
                    'errorPage += "<P align='right'><FONT color='#ffffff'><IMG height='20' src='Images/curve.jpg'></FONT></P>"
                    'errorPage += "</TD>"
                    'errorPage += "<TD noWrap bgColor='#9dcd5f'>"
                    'errorPage += "<P align='right'>Link Web Sites:&nbsp; </FONT><A id='TCDSBLink' href='http://www.tcdsb.on.ca/'><FONT color='#000000'>TCDSB</FONT></A><FONT color=#ffffff>"
                    'errorPage += "<FONT color=#000000>&nbsp;|&nbsp;</FONT> </FONT><A id='IntranetLink' href='http://intranet/'>"
                    'errorPage += "<FONT color=#000000>Intranet</FONT></A>&nbsp;&nbsp;|&nbsp;&nbsp;<A id='Trillium' href='http://intranet/trillium/'><FONT color=#000000>Trillium</FONT></A>&nbsp; &nbsp;</P>"
                    'errorPage += "</TD>"
                    'errorPage += "</TR>"
                    'errorPage += "</TABLE>"
                    'errorPage += "</TD>"
                    'errorPage += "</TR>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD style='WIDTH: 200px'>"
                    'errorPage += "</TD>"
                    'errorPage += "<TD vAlign='center' align='middle'><STRONG><FONT size='4'>"
                    'errorPage += "<TABLE id='Table3' cellSpacing='0' cellPadding='4' width='100%' border='0'>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD noWrap vAlign='center' align='middle'>"
                    'errorPage += "<P align='center'><STRONG><FONT size='5'>TCDSB Student&nbsp;Web Applications</FONT></STRONG></P>"
                    'errorPage += "</TD>"
                    'errorPage += "</TR>"
                    'errorPage += "</TABLE>"
                    'errorPage += "</FONT></STRONG><FONT color=#ffffff></FONT>"
                    'errorPage += "</TD>"
                    'errorPage += "</TR>"
                    'errorPage += "</TABLE>"
                    'errorPage += "</TD>"
                    'errorPage += "</TR>"
                    'errorPage += "<TR>"
                    'errorPage += "<TD bgColor=#9dcd5f colSpan=2><IMG src='Images/shim.gif'></TD>"
                    'errorPage += "</TR>"
                    'errorPage += "</TABLE>"

                    errorPage += "<DIV align='center'><table id='table112' height='100%'><tr><td><TABLE id=table13 width='350px' cellpadding='8'>"
                    errorPage += "<tr><td align='center'><img src='images/smallTCDSB-logo.gif' border='0'></img></td></tr>"
                    errorPage += "<tr><td align='center'>System experienced some technical difficulty, please try it later or contact HelpDesk for help.</td></tr>"
                    errorPage += "<tr><td><P align='center'><INPUT style='WIDTH: 112px; HEIGHT: 24px' type='button' onclick='javascript:GoBack()' value='Back'></P></td></tr>"
                    errorPage += "</TABLE></tr></td></TABLE></DIV>"

                    errorPage += "</body>"
                    errorPage += "</html>"

                    HttpContext.Current.Response.Write(errorPage)
                    HttpContext.Current.Response.End()
                End Sub
            End Class
        End Namespace
    End Namespace
End Namespace


