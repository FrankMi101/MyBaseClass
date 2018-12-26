Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

'Namespace IEPBase
Namespace TCDSB
    Namespace Student
        Public Class Parameters

            Private _User As String
            Private _domain As String
            Public Sub New(ByVal cUser As String)
                _User = cUser
            End Sub
            Public Shared Property SchoolCode(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "SchoolCode")
                End Get
                Set(ByVal Value As String)
                    SaveTC(vUser, "SchoolCode", Value)
                End Set
            End Property

            Public Shared Property SchoolYear(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "SchoolYear")
                End Get
                Set(ByVal Value As String)
                    SaveTC(vUser, "SchoolYear", Value)
                End Set
            End Property
            Shared ReadOnly Property SchoolName(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "SchoolName")
                End Get
            End Property

            Public Shared Property SchoolDate(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "SchoolDate")
                End Get
                Set(ByVal Value As String)
                    SaveTC(vUser, "SchoolDate", Value)
                End Set
            End Property
            Public Shared Property StudentNo(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "StudentNo")
                End Get
                Set(ByVal Value As String)
                    SaveTC(vUser, "StudentNo", Value)
                End Set
            End Property
            Public Shared Property StudentOEN(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "StudentOEN")
                End Get
                Set(ByVal Value As String)
                    SaveTC(vUser, "StudentOEN", Value)
                End Set
            End Property
            Public Shared Property Course(ByVal vUser As String) As String
                Get
                    Return GetTC(vUser, "Course")
                End Get
                Set(ByVal Value As String)
                    SaveTC(vUser, "Course", Value)
                End Set
            End Property

            Private Shared Function GetTC(ByVal vUser As String, ByVal vType As String) As String
                Dim cn As String = TCDSB.Student.Data.dbConnectionSTR 'DB.TrilliumCompanionConnectionString
                Dim dr As SqlDataReader
                Dim sqlStr As String = "tcdsb_DOTNET_TrilliumCompanion"
                '  Dim returnValue As String
                '  Dim cmd As New SqlCommand
                '  cn.ConnectionString = TCDSBDB.TrilliumCompanionConnectionString 'TCDSBDB.SecurityModel  'TCDSB.Student.TC_BaseFunction.dbConnectionStr ' dbConnectionStr()
                ' cmd = New SqlCommand(sqlStr, cn)
                'cmd.CommandType = CommandType.StoredProcedure
                'cmd.Parameters.Add("@pType", vType)
                'cmd.Parameters.Add("@pUserID", vUser)
                Dim myparams(1) As SqlParameter
                myparams(0) = New SqlParameter("@pType", SqlDbType.VarChar, 20)
                myparams(0).Value = vType
                myparams(1) = New SqlParameter("@pUserID", SqlDbType.VarChar, 20)
                myparams(1).Value = vUser

                Try
                    dr = TCDSB.Student.DataAccess.ExecuteReader(cn, CommandType.StoredProcedure, sqlStr, myparams)
                    '   cn.Open()
                    '   dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dr.Read()
                    Return CType(dr("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Data Access Error")  ' TCDSB.Student.Exceptions.PublishException(e, "Student")

                    'Return e.Message()  ' Return (e.Message())
                Finally
                    'If cn.State = ConnectionState.Open Then
                    'cn.Close()
                    'End If
                End Try
            End Function
            Private Shared Sub SaveTC(ByVal vUser As String, ByVal vType As String, ByVal vValue As String)
                Dim sqlStr As String = "tcdsb_DOTNET_TrilliumCompanion"
                Dim cn As String = TCDSB.Student.Data.dbConnectionSTR 'DB.TrilliumCompanionConnectionString
                '   Dim returnValue As String
                '    Dim cmd As SqlCommand
                '    Dim dr As SqlDataReader
                '    Dim cn As New SqlConnection()
                'cn.ConnectionString = tcdsbDB.SecurityModel 'TCDSB.Student.TC_BaseFunction.dbConnectionStr '  dbConnectionStr ' dbConnectionStr() 'ConfigurationSettings.AppSettings("dbCon")

                Dim myparams(2) As SqlParameter
                myparams(0) = New SqlParameter("@pType", SqlDbType.VarChar, 20)
                myparams(0).Value = vType
                myparams(1) = New SqlParameter("@pUserID", SqlDbType.VarChar, 20)
                myparams(1).Value = vUser
                myparams(2) = New SqlParameter("@pValue", SqlDbType.VarChar, 20)
                myparams(2).Value = vValue

                Try
                    TCDSB.Student.DataAccess.ExecuteNonQuery(cn, CommandType.StoredProcedure, sqlStr, myparams)

                    '  tcdsbdataaccess.ExecuteNonQuery(
                    'cn.Open()
                    'cmd = New SqlCommand(sqlStr, cn)
                    'cmd.CommandType = CommandType.StoredProcedure
                    'cmd.Parameters.Add("@pType", vType)
                    'cmd.Parameters.Add("@pUserID", _User)
                    'cmd.Parameters.Add("@pValue", vValue)
                    'cmd.ExecuteNonQuery()  ' myCmd.ExecuteNonQuery
                Catch e As Exception
                    Throw New Exception("Data Access Error") 'TCDSB.Student.Exceptions.PublishException(e, "Student")
                    'Return (e.Message())
                Finally
                    'If cn.State = ConnectionState.Open Then
                    'cn.Close()
                    'End If
                End Try
            End Sub

        End Class

    End Namespace
End Namespace
