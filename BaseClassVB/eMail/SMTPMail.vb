
Imports System.Net.Mail
Imports System.Web.Configuration
Public Class SMTPMail

    Public Shared Sub SendMail(ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Sbject As String, ByVal _Mail_Format As String)
        Try

            Dim myMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient
            myMail.Host = WebConfigurationManager.AppSettings("SMTPServer")
            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()

            If Mail_TO.IndexOf("@") > 0 Then
                If Mail_TO.IndexOf(";") > 0 Then
                    Dim myarray As String() = Mail_TO.Split(";")
                    Dim i As Integer
                    For i = 0 To myarray.Length - 1
                        Try
                            Mailmsg.To.Add(New System.Net.Mail.MailAddress(myarray(i)))
                        Catch ex As Exception

                        End Try
                    Next
                Else
                    Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
                End If
            End If

            ''More than one recipient 
            If Mail_CC.IndexOf("@") > 0 Then
                If Mail_CC.IndexOf(";") > 0 Then
                    Dim myarray As String() = Mail_CC.Split(";")
                    Dim i As Integer
                    For i = 0 To myarray.Length - 1
                        Try
                            Mailmsg.CC.Add(New System.Net.Mail.MailAddress(myarray(i)))

                        Catch ex As Exception

                        End Try
                    Next
                Else
                    Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
                End If
            End If
            'Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
            'Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
            If Mail_BCC.IndexOf("@") > 0 Then
                If Mail_BCC.IndexOf(";") > 0 Then
                    Dim myarray As String() = Mail_BCC.Split(";")
                    Dim i As Integer
                    For i = 0 To myarray.Length - 1
                        Try
                            Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(myarray(i)))

                        Catch ex As Exception

                        End Try
                    Next
                Else
                    Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(Mail_BCC))
                End If
            End If
            If Mail_From.IndexOf("@") > 0 Then
                Try
                    Mailmsg.From = New System.Net.Mail.MailAddress(Mail_From)
                Catch ex As Exception
                End Try
            End If
            Mailmsg.Subject = Mail_Sbject
            Mailmsg.Priority = MailPriority.High
            If _Mail_Format = "HTML" Then Mailmsg.IsBodyHtml = True
            Mailmsg.Body = Mail_Body
            Try
                myMail.Send(Mailmsg)
            Catch ex As Exception
                Dim errorMessage As String = ex.Message

            End Try

        Catch ex As Exception

        End Try



    End Sub
    Public Shared Sub SendMail(ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Sbject As String, ByVal _Mail_Format As String, _attachement As String)
        Try

            Dim myMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient
            myMail.Host = WebConfigurationManager.AppSettings("SMTPServer")
            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()

            If Mail_TO.IndexOf("@") > 0 Then
                If Mail_TO.IndexOf(";") > 0 Then
                    Dim myarray As String() = Mail_TO.Split(";")
                    Dim i As Integer
                    For i = 0 To myarray.Length - 1
                        Try
                            Mailmsg.To.Add(New System.Net.Mail.MailAddress(myarray(i)))
                        Catch ex As Exception

                        End Try
                    Next
                Else
                    Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
                End If
            End If

            ''More than one recipient 
            If Mail_CC.IndexOf("@") > 0 Then
                If Mail_CC.IndexOf(";") > 0 Then
                    Dim myarray As String() = Mail_CC.Split(";")
                    Dim i As Integer
                    For i = 0 To myarray.Length - 1
                        Try
                            Mailmsg.CC.Add(New System.Net.Mail.MailAddress(myarray(i)))

                        Catch ex As Exception

                        End Try
                    Next
                Else
                    Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
                End If
            End If
            'Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
            'Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
            If Mail_BCC.IndexOf("@") > 0 Then
                If Mail_BCC.IndexOf(";") > 0 Then
                    Dim myarray As String() = Mail_BCC.Split(";")
                    Dim i As Integer
                    For i = 0 To myarray.Length - 1
                        Try
                            Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(myarray(i)))

                        Catch ex As Exception

                        End Try
                    Next
                Else
                    Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(Mail_BCC))
                End If
            End If
            If Mail_From.IndexOf("@") > 0 Then
                Try
                    Mailmsg.From = New System.Net.Mail.MailAddress(Mail_From)
                Catch ex As Exception
                End Try
            End If
            Mailmsg.Subject = Mail_Sbject
            Mailmsg.Priority = MailPriority.High
            If _Mail_Format = "HTML" Then Mailmsg.IsBodyHtml = True
            Mailmsg.Body = Mail_Body
            Dim myAttachment As System.Net.Mail.Attachment
            myAttachment = New System.Net.Mail.Attachment(_attachement)
            Mailmsg.Attachments.Add(myAttachment)
            Try
                myMail.Send(Mailmsg)
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try



    End Sub
End Class
