
Namespace MockSAMS_API.Models
    Public Class Appointment

        'Appointments - Assuming they have Appointment ID, client ID, Time for the appointment, location and client notes.
        Public Property Appointment_ID As Integer
        Public Property Client_ID As Integer
        Public Property Appointment_DateTime As DateTime
        Public Property Location As String
        Public Property Client_Notes As String
    End Class
End Namespace
