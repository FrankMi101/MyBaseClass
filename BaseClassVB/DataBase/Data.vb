Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security
Imports Encryption
Imports System.Text
Imports Microsoft.Win32
Namespace TCDSB
    Namespace Student
        Public Class Data
            Public Structure MyParameter
                Public pName As String
                Public pType As System.Data.DbType
                Public pLeng As Integer
                Public pValue As Object ' String
            End Structure 'MyPerson
            Public Structure MyParameterRS
                Public pName As String
                Public pValue As Object
            End Structure
            'Public Shared myPara() As MyParameter
            Public Shared applicationName As String
            Public Shared dbConnectionSTR As String ' = "Data Source=cecw0964232;Initial Catalog=trilliumcompanion;Integrated Security=SSPI"
            Private Shared _dbType As String = "SQL"
            Public Shared Function dbConnectString() As String
                If dbConnectionSTR = "Registry" Then
                    dbConnectionSTR = DeCryptConnectString()
                End If
                Return dbConnectionSTR
            End Function
            Public Shared Function mydbConnecttion() As IDbConnection
                Dim dbconString As String = dbConnectString()
                'If dbConnectionSTR = "Registry" Then
                '    dbConnectionSTR = DeCryptConnectString()
                'End If
                Select Case _dbType
                    Case "SQL"
                        Dim myCon As New SqlConnection(dbconString)
                        Return mycon
                    Case "ORA"
                        Dim mycon As New OleDb.OleDbConnection(dbconString)
                        Return mycon
                    Case "Access"
                        Dim mycon As New OleDb.OleDbConnection(dbconString)
                        Return mycon
                    Case Else
                        Dim myCon As New SqlConnection(dbconString)
                        Return mycon
                End Select

            End Function
            Public Shared Function myValueA(ByVal _SP As String, ByRef _Paramater() As Object) As String
                Dim dr As IDataReader = Nothing ' Dim dr As SqlDataReader
                Dim cn As IDbConnection = mydbConnecttion()
                Try
                    Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
                    Dim x As Integer                    '   Dim _value As String
                    For x = 0 To _Paramater.GetUpperBound(0)    '     _value = pArray(x).pValue
                        If _Paramater(x).pValue <> "NxN" Then cmd.Parameters.Add(SetParameter(cmd, _Paramater(x).pName, _Paramater(x).pType, _Paramater(x).pLeng, _Paramater(x).pValue))
                    Next
                    cn.Open()
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    Return CType(dr(0), String) ' ("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                    If Not dr Is Nothing Then dr.Dispose()
                End Try
            End Function
            'Public Shared Function myValueA(ByVal _SP As String, ByRef _Paramater() As Object, ByVal cn As Object) As String
            '    Dim dr As IDataReader ' Dim dr As SqlDataReader
            '    Try
            '        Dim cn As IDbConnection = mydbConnecttion()
            '        Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
            '        cmd.CommandType = CommandType.StoredProcedure
            '        cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
            '        Dim x As Integer                    '   Dim _value As String
            '        For x = 0 To _Paramater.GetUpperBound(0)    '     _value = pArray(x).pValue
            '            If _Paramater(x).pValue <> "NxN" Then cmd.Parameters.Add(SetParameter(cmd, _Paramater(x).pName, _Paramater(x).pType, _Paramater(x).pLeng, _Paramater(x).pValue))
            '        Next
            '        cn.Open()
            '        dr = cmd.ExecuteReader()
            '        dr.Read()
            '        Return CType(dr(0), String) ' ("rValue"), String)
            '    Catch e As Exception
            '        Throw New Exception("Database Orperation Error: " + e.Message)
            '    Finally
            '        If cn.State = ConnectionState.Open Then cn.Close()
            '        If Not dr Is Nothing Then dr.Dispose()
            '    End Try
            'End Function
            Public Shared Function myDataSetA(ByVal _SP As String, ByRef _Paramater() As Object) As DataSet
                Dim cn As IDbConnection = mydbConnecttion()
                Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = _SP '"tcdsb_TPA_ListDDL"
                Dim x As Integer
                For x = 0 To _Paramater.GetUpperBound(0)
                    If _Paramater(x).pValue <> "NxN" Then cmd.Parameters.Add(SetParameter(cmd, _Paramater(x).pName, _Paramater(x).pType, _Paramater(x).pLeng, _Paramater(x).pValue))
                Next
                Dim myDA As New SqlDataAdapter 'IDbDataAdapter   
                myDA.SelectCommand = cmd  'SelectCommand = cmd
                Dim Dataset1 As New DataSet
                Try
                    cn.Open()
                    myDA.Fill(Dataset1) ' "StudentList")  ', "Table1")
                    Return Dataset1
                Catch e As Exception
                    Throw New Exception("Database Orperation Error:" + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                End Try
            End Function
            Public Shared Function myDataSetB(ByVal _SP As String, ByRef _Paramater() As MyParameter) As DataSet
                Dim cn As IDbConnection = mydbConnecttion()
                Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = _SP '"tcdsb_TPA_ListDDL"
                Dim x As Integer
                For x = 0 To _Paramater.GetUpperBound(0)
                    If _Paramater(x).pValue <> "NxN" Then cmd.Parameters.Add(SetParameter(cmd, _Paramater(x).pName, _Paramater(x).pType, _Paramater(x).pLeng, _Paramater(x).pValue))
                Next
                Dim myDA As New SqlDataAdapter 'IDbDataAdapter   
                myDA.SelectCommand = cmd  'SelectCommand = cmd
                Dim Dataset1 As New DataSet
                Try
                    cn.Open()
                    myDA.Fill(Dataset1) ' "StudentList")  ', "Table1")
                    Return Dataset1
                Catch e As Exception
                    Throw New Exception("Database Orperation Error:" + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                End Try
            End Function
            Public Shared Function myValueB(ByVal _SP As String, ByRef _Paramater() As MyParameter) As String
                Dim cn As IDbConnection = mydbConnecttion()
                Dim dr As IDataReader = Nothing ' Dim dr As SqlDataReader
                Try
                    Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
                    Dim x As Integer                    '   Dim _value As String
                    For x = 0 To _Paramater.GetUpperBound(0)    '     _value = pArray(x).pValue
                        If _Paramater(x).pValue <> "NxN" Then cmd.Parameters.Add(SetParameter(cmd, _Paramater(x).pName, _Paramater(x).pType, _Paramater(x).pLeng, _Paramater(x).pValue))
                    Next
                    cn.Open()
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    Return CType(dr(0), String) ' ("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                    If Not dr Is Nothing Then dr.Dispose()
                End Try
            End Function

            Public Shared Sub myDataSave(ByVal _SP As String, ByRef _Paramater() As Object)
                Dim cn As IDbConnection = mydbConnecttion()
                Try
                    Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
                    Dim myPara As MyParameter
                    For Each myPara In _Paramater
                        If myPara.pValue <> "NxN" Then cmd.Parameters.Add(SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue))
                    Next
                     cn.Open()
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                End Try
            End Sub

            Public Shared Function myValue(ByVal cn As Object, ByVal cmd As Object) As String
                Dim dr As IDataReader = Nothing  ' Dim dr As SqlDataReader
                Try
                    cn.Open()
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    Return CType(dr(0), String) ' ("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                    ' Return e.Message()   ' Return (e.Message())
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    If Not dr Is Nothing Then
                        dr.Dispose()
                    End If
                    '      cn.Dispose()
                End Try
            End Function
            Public Shared Function myDataSet(ByVal cn As Object, ByVal cmd As Object) As DataSet
                Dim myDA As New SqlDataAdapter 'IDbDataAdapter     ' IDataAdapter  '        ' = cn.CreateCommand()
                myDA.SelectCommand = cmd  'SelectCommand = cmd
                Dim Dataset1 As New DataSet
                Try
                    cn.Open()
                    myDA.Fill(Dataset1) ' "StudentList")  ', "Table1")
                    Return Dataset1
                Catch e As Exception
                    Throw New Exception("Database Orperation Error:" + e.Message)
                    ' TCDSB.Student.TCDSBException.PublishException(e, " IEP  Get Text Data ")
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End Try
            End Function

            Public Shared Sub SaveMyData(ByVal cn As Object, ByVal cmd As Object)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                    ' TCDSB.Student.TCDSBException.PublishException(e, " IEP  Save Text Data ")
                    'e.Message().ToString() ' Return (e.Message())
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End Try

            End Sub
            Public Shared Function SetParameter(ByVal cmd As Object, ByVal pName As String, ByVal pType As DbType, ByVal pSize As Integer, ByVal pValue As Object) As IDbDataParameter
                Dim myParameter As IDbDataParameter = cmd.CreateParameter()
                With myParameter
                    .ParameterName = pName
                    .DbType = pType 'oeDbType.String
                    .Size = pSize '20
                    .Value = pValue '_user
                End With
                Return myParameter
            End Function
            Public Shared Function myDataReader(ByVal cn As Object, ByVal cmd As Object) As IDataReader
                Dim dr As IDataReader ' Dim dr As SqlDataReader
                Try
                    cn.Open()
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Return dr
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                    '   TCDSB.Student.TCDSBException.PublishException(e, " IEP  Get Text Data ")
                    '  Me.PublishException(e, "IEP")
                    ' Dim showMsg As String = e.Message()     ' Return (e.Message())
                Finally
                End Try
            End Function
            Public Shared Function CurrentSchoolyear() As String
                Dim vYear As String
                If Month(Now) < 8 Then
                    vYear = (Year(Now) - 1).ToString + Year(Now).ToString
                Else
                    vYear = Year(Now).ToString + (Year(Now) + 1).ToString
                End If
                Return vYear
            End Function

            Public Shared Function DateF(ByVal vDate As Date, ByVal vType As String) As String
                Dim yy, mm, dd As String
                yy = Year(vDate).ToString
                If Month(vDate) > 9 Then
                    mm = Month(vDate).ToString
                Else
                    mm = "0" + Month(vDate).ToString
                End If
                If Day(vDate) > 9 Then
                    dd = Day(vDate).ToString
                Else
                    dd = "0" + Day(vDate).ToString
                End If
                Select Case vType
                    Case "YYYY/MM/DD"
                        DateF = yy + "/" + mm + "/" + dd 'Day(vDate).ToString
                    Case "YYYY-MM-DD"
                        DateF = yy + "-" + mm + "-" + dd 'Day(vDate).ToString
                    Case Else
                        DateF = yy + "." + mm + "." + dd
                End Select
            End Function
            Private Shared Function DeCryptConnectString() As String
                Dim _ConnectionString As String
                Try
                    Dim _subKey As String = "Software\" & applicationName
                    Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey(_subKey, False) ' ("Software\WebCof", False)
                    Dim _ConString As String = rk.GetValue("ConnectionString")
                    Dim _initVector As String = rk.GetValue("initVector")
                    Dim _key As String = rk.GetValue("key")

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

        Public Structure MyParameterRS
            Public pName As String
            Public pValue As Object
        End Structure
        Public Class Data2
            Public Structure MyParameter2
                Public pName As String
                Public pType As System.Data.SqlDbType
                Public pLeng As Integer
                Public pValue As Object ' String
            End Structure 'MyPerson
            Public Shared applicationName As String
            Public Shared dbConnectionSTR As String
            Private Shared _dbType As String = "SQL"
            Public Shared Function dbConnectString() As String
                If dbConnectionSTR = "Registry" Then
                    dbConnectionSTR = DeCryptConnectString()
                End If
                Return dbConnectionSTR
            End Function
            Public Shared Function mydbConnecttion() As IDbConnection
                Dim dbconString As String = dbConnectString()
                 Select Case _dbType
                    Case "SQL"
                        Dim myCon As New SqlConnection(dbconString)
                        Return myCon
                    Case "ORA"
                        Dim mycon As New OleDb.OleDbConnection(dbconString)
                        Return mycon
                    Case "Access"
                        Dim mycon As New OleDb.OleDbConnection(dbconString)
                        Return mycon
                    Case Else
                        Dim myCon As New SqlConnection(dbconString)
                        Return myCon
                End Select

            End Function

            Public Shared Function myValue(ByVal _SP As String, ByRef _Paramater() As Object) As String
                Dim dr As IDataReader = Nothing  ' Dim dr As SqlDataReader
                Dim cn As IDbConnection = mydbConnecttion()
                Try
                    Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
                    Dim myPara As MyParameter2
                    For Each myPara In _Paramater
                        cmd.Parameters.Add(SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue))
                    Next
                    cn.Open()
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    Return CType(dr(0), String) ' ("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                    If Not dr Is Nothing Then dr.Dispose()
                End Try
            End Function
            Public Shared Function myDataDate(ByVal _SP As String, ByRef _Paramater() As Object) As Date
                Dim dr As IDataReader = Nothing  ' Dim dr As SqlDataReader
                Dim cn As IDbConnection = mydbConnecttion()
                Try
                    Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
                    Dim myPara As MyParameter2
                    For Each myPara In _Paramater
                        cmd.Parameters.Add(SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue))
                    Next
                    cn.Open()
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    Return CType(dr(0), Date) ' ("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                    If Not dr Is Nothing Then dr.Dispose()
                End Try
            End Function
            Public Shared Function myDataSet(ByVal _SP As String, ByRef _Paramater() As Object) As DataSet
                Dim cn As IDbConnection = mydbConnecttion()
                Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = _SP '"tcdsb_TPA_ListDDL"
                Dim myPara As MyParameter2
                For Each myPara In _Paramater
                    cmd.Parameters.Add(SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue))
                Next
                Dim myDA As New SqlDataAdapter 'IDbDataAdapter   
                myDA.SelectCommand = cmd  'SelectCommand = cmd
                Dim Dataset1 As New DataSet
                Try
                    cn.Open()
                    myDA.Fill(Dataset1) ' "StudentList")  ', "Table1")
                    Return Dataset1
                Catch e As Exception
                    Throw New Exception("Database Orperation Error:" + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                End Try
            End Function
   
            Public Shared Sub myDataSave(ByVal _SP As String, ByRef _Paramater() As Object)
                Dim cn As IDbConnection = mydbConnecttion()
                Try
                    Dim cmd As IDbCommand = cn.CreateCommand()  ' Dim cmd As SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = _SP '"dbo.tcdsb_TPA_ListDDL"
                    Dim myPara As MyParameter2
                    For Each myPara In _Paramater
                        cmd.Parameters.Add(SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue))
                    Next
                    cn.Open()
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                Finally
                    If cn.State = ConnectionState.Open Then cn.Close()
                End Try
            End Sub

            Public Shared Function SetParameter(ByVal cmd As Object, ByVal pName As String, ByVal pType As SqlDbType, ByVal pSize As Integer, ByVal pValue As Object) As IDbDataParameter
                Dim myParameter As IDbDataParameter = cmd.CreateParameter()
                With myParameter
                    .ParameterName = pName
                    .DbType = pType 'oeDbType.String
                    .Size = pSize '20
                    .Value = pValue '_user
                End With
                Return myParameter
            End Function


            Public Shared Function myValue2(ByVal cn As Object, ByVal cmd As Object) As String
                Dim dr As IDataReader = Nothing ' Dim dr As SqlDataReader
                Try
                    cn.Open()
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    Return CType(dr(0), String) ' ("rValue"), String)
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                    ' Return e.Message()   ' Return (e.Message())
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    If Not dr Is Nothing Then
                        dr.Dispose()
                    End If
                    '      cn.Dispose()
                End Try
            End Function
            Public Shared Function myDataSet2(ByVal cn As Object, ByVal cmd As Object) As DataSet
                Dim myDA As New SqlDataAdapter 'IDbDataAdapter     ' IDataAdapter  '        ' = cn.CreateCommand()
                myDA.SelectCommand = cmd  'SelectCommand = cmd
                Dim Dataset1 As New DataSet
                Try
                    cn.Open()
                    myDA.Fill(Dataset1) ' "StudentList")  ', "Table1")
                    Return Dataset1
                Catch e As Exception
                    Throw New Exception("Database Orperation Error:" + e.Message)
                    ' TCDSB.Student.TCDSBException.PublishException(e, " IEP  Get Text Data ")
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End Try
            End Function

            Public Shared Sub SaveMyData2(ByVal cn As Object, ByVal cmd As Object)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    Throw New Exception("Database Orperation Error: " + e.Message)
                    ' TCDSB.Student.TCDSBException.PublishException(e, " IEP  Save Text Data ")
                    'e.Message().ToString() ' Return (e.Message())
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End Try

            End Sub
            Private Shared Function DeCryptConnectString() As String
                Dim _ConnectionString As String
                Try
                    Dim _subKey As String = "Software\" & applicationName
                    Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey(_subKey, False) ' ("Software\WebCof", False)
                    Dim _ConString As String = rk.GetValue("ConnectionString")
                    Dim _initVector As String = rk.GetValue("initVector")
                    Dim _key As String = rk.GetValue("key")

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

