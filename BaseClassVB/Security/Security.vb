'''' Toronto Catholic District School Board
''''  
''''
'''' Frank Mi  2003-09-25
''''
'''' Get user permissison list based on page
Option Strict On
Imports System.Security.Principal
Imports System.Threading
Imports System.IO
Imports System.Security
Imports Encryption
Imports System.Text
Imports Microsoft.Win32


Namespace TCDSB
    Namespace Student
        Public Class Security
            '   Inherits TCDSB.Student.Data
            Private Shared _authentication As String
            Private Shared _Authorization As String
            Private Shared _SecurityAccess1 As DataSet

            Public Sub New()

            End Sub
            Public Property SecurityPage() As DataSet
                Get
                    Return _SecurityAccess1
                End Get
                Set(ByVal Value As DataSet)
                    _SecurityAccess1 = Value
                End Set
            End Property
            Public Shared Property authentication() As String
                Get
                    Return _authentication
                End Get
                Set(ByVal Value As String)
                    _authentication = Value
                End Set
            End Property
            Public Shared ReadOnly Property accessKey(ByVal _accessValue As String) As String
                Get
                    Return DeCryptAccessKey(_accessValue)
                End Get
            End Property

            Public Shared ReadOnly Property ListApplications(ByVal _UserID As String) As DataSet
                Get
                    Return getApplPermission(_UserID)
                End Get
            End Property
            Public Shared ReadOnly Property ListPages(ByVal _UserID As String, ByVal _ApplID As String) As DataSet
                Get
                    Return getApplPermission(_UserID, _ApplID)
                End Get
            End Property
            Public Shared ReadOnly Property ListPage(ByVal _UserID As String, ByVal _ApplID As String, ByVal _PageID As String) As DataSet
                Get
                    Return getApplPermission(_UserID, _ApplID, _PageID)
                End Get
            End Property
            Public Shared ReadOnly Property PagePermission(ByVal _UserID As String, ByVal _ApplID As String, ByVal _PageID As String) As String
                Get
                    Return getPagePermission(_UserID, _ApplID, _PageID)
                End Get
            End Property
            Public Shared ReadOnly Property PagePermissionA(ByVal _PageID As String) As String
                Get
                    Return getPage(_PageID)
                End Get
            End Property
            Public Shared ReadOnly Property PagePermissionB(ByVal _PageID As String, ByVal _PageGrantList As DataSet) As String
                Get
                    Return getPage(_PageID, _PageGrantList)
                End Get
            End Property
            Private Shared Function getApplPermission(ByVal _User As String, Optional ByVal _Appl As String = "NxN", Optional ByVal _Page As String = "NxN") As DataSet
                Dim myPermission As New DataSet
                Dim cn As IDbConnection = Data.mydbConnecttion ' TCBase.mydbConnecttion    ' Dim cn As New SqlConnection
                Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "tcdsb_SM_List_Application"
                cmd.Parameters.Add(TCDSB.Student.Data.SetParameter(cmd, "@UserID", DbType.String, 40, _User))
                If _Appl <> "NxN" Then cmd.Parameters.Add(TCDSB.Student.Data.SetParameter(cmd, "@ApplicationID", DbType.String, 50, _Appl))
                If _Page <> "NxN" Then cmd.Parameters.Add(TCDSB.Student.Data.SetParameter(cmd, "@ModuleID", DbType.String, 30, _Page))
                Return Data.myDataSet(cn, cmd)
            End Function
            Private Shared Function getPagePermission(ByVal _User As String, ByVal _Appl As String, ByVal _Page As String) As String
                Dim _myPagePermission As DataSet = getApplPermission(_User, _Appl, _Page)
                Return getPage(_Page, _myPagePermission)
            End Function
            Private Shared Function getPage(ByVal PageID As String, ByVal PageGrant As DataSet) As String
                Dim tRow As DataRow
                Dim str As String = ""
                Dim Str1 As String
                For Each tRow In PageGrant.Tables(0).Rows
                    Str1 = tRow(1).ToString
                    If Str1 = PageID Then    ' myrow(1) = _PageID Then  'ApplicationID, ModuleID, PermissionID
                        str = tRow(2).ToString
                        Exit For
                    End If
                Next
                If str = "" Then
                    str = "NoSetup"
                End If
                Return str
            End Function
            Private Shared Function getPage(ByVal PageID As String) As String
                Dim tRow As DataRow
                Dim str As String = ""
                Dim Str1 As String
                Dim PageGrant As DataSet = _SecurityAccess1  ' _SecurityAccess1   '  TCDSBSessionInfo.GrantPermission
                For Each tRow In PageGrant.Tables(0).Rows
                    Str1 = tRow(1).ToString
                    If Str1 = PageID Then    ' myrow(1) = _PageID Then  'ApplicationID, ModuleID, PermissionID
                        str = tRow(2).ToString
                        Exit For
                    End If
                Next
                If str = "" Then
                    str = "NoSetup"
                End If
                Return str
            End Function
            Public Shared ReadOnly Property UserProfile(ByVal _Type As String, ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile(_Type, _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Public Shared ReadOnly Property UserSchool(ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile("School", _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Public Shared ReadOnly Property UserScope(ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile("Scope", _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Public Shared ReadOnly Property UserPosition(ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile("Position", _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Public Shared ReadOnly Property UserDepartment(ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile("Department", _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Public Shared ReadOnly Property UserRole(ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile("Role", _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Public Shared ReadOnly Property UserArea(ByVal _UserID As String, ByVal _ApplID As String) As String
                Get
                    Return getUserProfile("Area", _UserID, _ApplID)
                    '_type ="Scope";"Department";"Position";"School"
                End Get
            End Property
            Private Shared Function getUserProfile(ByVal _type As String, ByVal vUser As String, ByVal vAppl As String) As String
                Dim myPermission As New DataSet
                Dim cn As IDbConnection = Data.mydbConnecttion    ' Dim cn As New SqlConnection
                Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "tcdsb_SM_UserProfile"
                cmd.Parameters.Add(TCDSB.Student.Data.SetParameter(cmd, "@UserID", DbType.String, 40, vUser))
                cmd.Parameters.Add(TCDSB.Student.Data.SetParameter(cmd, "@Type", DbType.String, 20, _type))
                cmd.Parameters.Add(TCDSB.Student.Data.SetParameter(cmd, "@Application", DbType.String, 20, vAppl))
                Return Data.myValue(cn, cmd)
            End Function
            Private Shared Function DeCryptAccessKey(ByVal _accessValue As String) As String
                Dim _ConnectionString As String
                Try
                    Dim _subKey As String = "Software\" & _accessValue
                    Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey(_subKey, False) ' ("Software\WebCof", False)
                    Dim _ConString As String = CType(rk.GetValue("ConnectionString"), String)
                    Dim _initVector As String = CType(rk.GetValue("initVector"), String)
                    Dim _key As String = CType(rk.GetValue("key"), String)

                    Dim dec As Decryptor
                    dec = New Decryptor(EncryptionAlgorithm.TripleDes)
                    dec.IV = Convert.FromBase64String(_initVector)
                    Dim _conStringByte As Byte() = dec.Decrypt(Convert.FromBase64String(_ConString), Convert.FromBase64String(_key))
                    _ConnectionString = Encoding.ASCII.GetString(_conStringByte)
                    Return _ConnectionString
                Catch e As Exception
                    Throw New Exception("Connection DeCrypt Error:" + e.Message)
                End Try
            End Function

        End Class
    End Namespace
End Namespace
