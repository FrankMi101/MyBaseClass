Imports System.Data.SqlClient
Namespace TCDSB
    Namespace Student
        Namespace SearchList
            Public Class Classes
                Public Shared Function ClassSearch(ByRef UserID As String, ByRef ClassCode As String, ByRef SchoolCode As String) As SqlDataReader
                    Dim sp_name As String
                    sp_name = "tcdsb_DN_sp_ClassesList"

                    Dim myparams(2) As SqlParameter
                    myparams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 30)
                    myparams(0).Value = UserID

                    myparams(1) = New SqlParameter("@ClassCode", SqlDbType.VarChar, 16)
                    myparams(1).Value = ClassCode

                    myparams(2) = New SqlParameter("@SchoolCode", SqlDbType.VarChar, 8)
                    myparams(2).Value = SchoolCode

                    Try
                        Return TCDSB.Student.DataAccess.ExecuteReader(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name, myparams)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error")   'TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try

                End Function

            End Class
            Public Class Teachers

                Public Shared Function TeacherSearch(ByRef UserID As String, ByRef LastName As String, ByRef FirstName As String, ByRef StaffNO As String, ByVal SchoolCode As String) As SqlDataReader
                    Dim sp_name As String
                    sp_name = "tcdsb_DN_sp_TeachersList"

                    Dim myparams(4) As SqlParameter

                    myparams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 30)
                    myparams(0).Value = UserID

                    myparams(1) = New SqlParameter("@LastName", SqlDbType.VarChar, 70)
                    myparams(1).Value = LastName

                    myparams(2) = New SqlParameter("@FirstName", SqlDbType.VarChar, 70)
                    myparams(2).Value = FirstName

                    myparams(3) = New SqlParameter("@StaffNo", SqlDbType.VarChar, 9)
                    myparams(3).Value = StaffNO

                    myparams(4) = New SqlParameter("@SchoolCode", SqlDbType.VarChar, 8)
                    myparams(4).Value = SchoolCode

                    Try
                        Return TCDSB.Student.DataAccess.ExecuteReader(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name, myparams)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error") ' TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try

                End Function
            End Class
            Public Class Students
                Public Shared Function StudentSearch(ByRef UserID As String, ByRef LastName As String, ByRef FirstName As String, ByRef StudentNO As String, ByRef OENNo As String, ByVal SchoolCode As String) As SqlDataReader
                    Dim sp_name As String
                    sp_name = "tcdsb_DN_sp_StudentsList"

                    Dim myparams(5) As SqlParameter

                    myparams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 30)
                    myparams(0).Value = UserID

                    myparams(1) = New SqlParameter("@LastName", SqlDbType.VarChar, 70)
                    myparams(1).Value = LastName

                    myparams(2) = New SqlParameter("@FirstName", SqlDbType.VarChar, 70)
                    myparams(2).Value = FirstName

                    myparams(3) = New SqlParameter("@StudentNo", SqlDbType.VarChar, 9)
                    myparams(3).Value = StudentNO

                    myparams(4) = New SqlParameter("@OENNo", SqlDbType.VarChar, 9)
                    myparams(4).Value = OENNo

                    myparams(5) = New SqlParameter("@SchoolCode", SqlDbType.VarChar, 8)
                    myparams(5).Value = SchoolCode

                    Try
                        Return TCDSB.Student.DataAccess.ExecuteReader(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name, myparams)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error")  ' TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try

                End Function
            End Class
            Public Class Schools
                ''' Get Schools depend on user id
                ''' if user_id = "" then "All Schools"
                ''' else "Secure Schools for this user"
                Public Shared Function GetSchools(Optional ByVal user_id As String = "") As SqlDataReader
                    Dim sp_name As String
                    sp_name = "tcdsb_DN_sp_Schools_List"

                    Dim myparams(0) As SqlParameter
                    myparams(0) = New SqlParameter("@user_id", SqlDbType.VarChar, 30)
                    myparams(0).Value = user_id

                    Try
                        Return TCDSB.Student.DataAccess.ExecuteReader(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name, myparams)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error")  ' TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try
                End Function

                Public Shared Function SchoolsDataset(Optional ByVal user_id As String = "") As DataSet
                    Dim sp_name As String
                    sp_name = "tcdsb_DN_sp_Schools_List"

                    Dim myparams(0) As SqlParameter
                    myparams(0) = New SqlParameter("@user_id", SqlDbType.VarChar, 30)
                    myparams(0).Value = user_id

                    Try
                        Return TCDSB.Student.DataAccess.ExecuteDataset(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name, myparams)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error")  '  TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try
                End Function
            End Class
            Public Class SchoolYears
                Public Shared Function SchoolYears() As DataSet
                    Dim sp_name As String
                    sp_name = "tcdsb_DN_sp_School_Years"

                    Try
                        Return TCDSB.Student.DataAccess.ExecuteDataset(TCDSB.Student.Data.dbConnectionSTR, CommandType.StoredProcedure, sp_name)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error")  ' TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try
                End Function
            End Class
            Public Class Locators

                Public Shared ReadOnly Property StudentList(ByVal pDomainID As String, _
                                                   ByVal pUserID As String, _
                                                   ByVal pApplicationID As String, _
                                                   ByVal pScope As String, _
                                                   ByVal pRequestValue As String, _
                                                   ByVal pShowMsg As String, _
                                                   ByVal pNeedType As String) As DataSet
                    Get
                        Return GetStudent(pDomainID, pUserID, pApplicationID, pScope, pRequestValue, pShowMsg, pNeedType) 'GetStudentList() ' GetStudentDataSet()
                    End Get

                End Property

                Private Shared Function GetStudent(ByVal pDomainID As String, _
                                                   ByVal pUserID As String, _
                                                   ByVal pApplicationID As String, _
                                                   ByVal pScope As String, _
                                                   ByVal pRequestValue As String, _
                                                   ByVal pShowMsg As String, _
                                                   ByVal pNeedType As String) As DataSet
                    '@Scope   varchar(20),  -- Can be a 'Board', 'School', 'Class', 'Grade', 'Course', 'Student' 
                    '@RequestValue varchar(50)= null, -- Class ='ENG4O1-01' / Grade = '01' / Student ='0001233431'  
                    '@ShowMsg  varchar(20),  -- 'Non', 'IEP','ISA','SS','IPRC','SuspenSion'   ..........
                    '@NeedType varchar(20)-- 'All', 'IEP','ISA','SS','IPRC','SuspenSion'
                    Dim sqlStr As String = "tcdsb_DOTNET_Current_Student_List"

                    Dim myparams(5) As SqlParameter
                    myparams(0) = New SqlParameter("@Domain", SqlDbType.VarChar, 30)
                    myparams(0).Value = pDomainID
                    myparams(1) = New SqlParameter("@UserID", SqlDbType.VarChar, 30)
                    myparams(1).Value = pUserID
                    myparams(2) = New SqlParameter("@Request", SqlDbType.VarChar, 20)
                    myparams(2).Value = pScope
                    myparams(3) = New SqlParameter("@RequestValue", SqlDbType.VarChar, 50)
                    myparams(3).Value = pRequestValue
                    myparams(4) = New SqlParameter("@ShowMsg", SqlDbType.VarChar, 20)
                    myparams(4).Value = pShowMsg
                    myparams(5) = New SqlParameter("@NeedType", SqlDbType.VarChar, 20)
                    myparams(5).Value = pNeedType
                    Dim cn As String = TCDSB.Student.Data.dbConnectionSTR
                    Try
                        Return TCDSB.Student.DataAccess.ExecuteDataset(cn, CommandType.StoredProcedure, sqlStr, myparams)
                    Catch ex As Exception
                        Throw New Exception("Data Access Error")  ' TCDSB.Student.Exceptions.PublishException(ex, "Base Page")
                    End Try
                End Function

            End Class
        End Namespace
    End Namespace
End Namespace
