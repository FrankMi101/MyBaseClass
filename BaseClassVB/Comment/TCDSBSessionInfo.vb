''*************************************************
'' Toronto Catholic District School Board
'' Jerry Lu, 2003/07/19
'' This class is aim to totally control 
'' all the session objects here instead
'' of let user(developer) typing the session object
'' name, this will reduce the chance
'' of getting an empty session object
'' because of wrong session object name
''*************************************************
Imports System.web
Namespace TCDSB
    Namespace Student
        Public Class SessionInfo
            Public Shared Property Authentication() As String
                Get
                    Return HttpContext.Current.Session("Authentication")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("Authentication") = Value
                End Set
            End Property

            Public Shared Property ScreenResolution() As String
                Get
                    Return HttpContext.Current.Session("ScreenResolution")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("ScreenResolution") = Value
                End Set
            End Property

            Public Shared Property DetectTimes() As Integer
                Get
                    Return HttpContext.Current.Session("DetectTimes")
                End Get
                Set(ByVal Value As Integer)
                    HttpContext.Current.Session("DetectTimes") = Value
                End Set
            End Property

            Public Shared Property UserID() As String
                Get
                    Return HttpContext.Current.Session("UserID")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("UserID") = Value
                End Set
            End Property

            Public Shared Property LastCustomerID() As String
                Get
                    Return HttpContext.Current.Session("LastCustomerID")
                End Get

                Set(ByVal Value As String)
                    HttpContext.Current.Session("LastCustomerID") = Value
                End Set
            End Property

            Public Shared Property LastPage() As String
                Get
                    Return HttpContext.Current.Session("LastPage")
                End Get

                Set(ByVal Value As String)
                    HttpContext.Current.Session("LastPage") = Value
                End Set
            End Property

            Public Shared Property LastException() As Exception
                Get
                    Return DirectCast(HttpContext.Current.Session("LastException"), Exception)
                End Get

                Set(ByVal Value As Exception)
                    HttpContext.Current.Session("LastException") = Value
                End Set
            End Property

            Public Shared Property SchoolYear() As String
                Get
                    Return HttpContext.Current.Session("SchoolYear")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("SchoolYear") = Value
                End Set
            End Property

            Public Shared Property SchoolCode() As String
                Get
                    Return HttpContext.Current.Session("SchoolCode")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("SchoolCode") = Value
                End Set
            End Property

            Public Shared Property GoalSubmited() As Boolean
                Get
                    Return HttpContext.Current.Session("GoalSubmited")
                End Get
                Set(ByVal Value As Boolean)
                    HttpContext.Current.Session("GoalSubmited") = Value
                End Set
            End Property

            Public Shared Property SchoolName() As String
                Get
                    Return HttpContext.Current.Session("SchoolName")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("SchoolName") = Value
                End Set
            End Property



            Public Shared Property SchoolDate() As String
                Get
                    Return HttpContext.Current.Session("SchoolDate")
                End Get
                Set(ByVal Value As String)
                    HttpContext.Current.Session("SchoolDate") = Value
                End Set
            End Property

            Public Shared Property GrantPermission() As DataSet
                Get
                    Return CType(HttpContext.Current.Session("GrantPermission"), DataSet)
                End Get
                Set(ByVal Value As DataSet)
                    HttpContext.Current.Session("GrantPermission") = Value
                End Set
            End Property
            'Shared Sub New()
            '    TCDSBSessionInfo.SchoolCode = String.Empty
            '    TCDSBSessionInfo.SchoolName = String.Empty
            '    TCDSBSessionInfo.SchoolYear = String.Empty
            '    TCDSBSessionInfo.SchoolDate = String.Empty
            '    TCDSBSessionInfo.GoalSubmited = False
            '    TCDSBSessionInfo.Authentication = False
            '    TCDSBSessionInfo.ScreenResolution = String.Empty
            '    TCDSBSessionInfo.UserID = String.Empty
            '    TCDSBSessionInfo.SchoolYear = String.Empty
            '    TCDSBSessionInfo.LastCustomerID = String.Empty
            '    TCDSBSessionInfo.LastPage = String.Empty
            '    TCDSBSessionInfo.LastException = Nothing
            'End Sub
        End Class
    End Namespace  'TCDSB
End Namespace      'Student

