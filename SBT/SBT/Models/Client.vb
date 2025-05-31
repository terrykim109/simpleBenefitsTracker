Namespace MockSAMS_API.Models
    Public Class Client

        'Clients - Assuming they have ID, name, Program, start date and end date, last renewal data email address and the appointment date next.
        Public Property Client_ID As Integer
        Public Property First_Name As String
        Public Property Last_Name As String

        Public Property Current_Program As String
        Public Property Current_Status As String
        Public Property Program_StartDate As DateTime
        Public Property Program_ExpiryDate As DateTime
        Public Property Program_LastRenewal As DateTime
        Public Property Email_Address As String
        Public Property Next_AppointmentDate As DateTime

    End Class
End Namespace
