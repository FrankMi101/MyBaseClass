Imports System.Data.SqlClient
Namespace TCDSB
    Namespace Student
        Namespace Common
            Public Class OperationTimes
                Public Shared Function GetOperationTimes() As Hashtable
                    Dim myOperationTimes As New Hashtable
                    Dim sp_name As String
                    Dim mydr As SqlDataReader
                    sp_name = "tcdsb_DN_sp_Operation_Times"
                    Try
                        mydr = TCDSB.Student.DataAccess.ExecuteReader(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name)
                        Do While mydr.Read
                            myOperationTimes.Add("StartTime", mydr("start_time"))
                            myOperationTimes.Add("EndTime", mydr("end_time"))
                        Loop
                        Return myOperationTimes
                    Catch ex As Exception
                        Throw New Exception("Data Access Error") '  TCDSB.Student.Exceptions.PublishException(ex, "BasePage")
                    End Try
                End Function

            End Class
        End Namespace
    End Namespace
End Namespace
