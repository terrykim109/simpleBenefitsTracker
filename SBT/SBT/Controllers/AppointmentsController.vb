' File: Controllers\AppointmentsController.vb

Imports System.Web.Http
Imports System.Collections.Generic
Imports MockSAMS_API.Models
Imports SBT.MockSAMS_API.Models

Namespace MockSAMS_API.Controllers
    Public Class AppointmentsController
        Inherits ApiController

        ' Mock Appointments
        Private Shared ReadOnly Appointments = New List(Of Appointment) From {
            New Appointment With {
                .Appointment_ID = 1,
                .Client_ID = 1,
                .Appointment_DateTime = New DateTime(2026, 2, 25, 10, 0, 0),
                .Location = "Toronto Office",
                .Client_Notes = "Annual review"
            },
            New Appointment With {
                .Appointment_ID = 2,
                .Client_ID = 2,
                .Appointment_DateTime = New DateTime(2025, 10, 3, 14, 30, 0),
                .Location = "Missisauga Office",
                .Client_Notes = "Income verification"
            },
            New Appointment With {
                .Appointment_ID = 3,
                .Client_ID = 3,
                .Appointment_DateTime = Nothing,
                .Location = String.Empty,
                .Client_Notes = String.Empty
            }
        }

        ' GET /api/appointment
        Public Function GetAppointments() As IEnumerable(Of Appointment)
            Return Appointments
        End Function

        ' GET /api/appointment/{id}
        Public Function GetAppointmentById(id As Integer) As IHttpActionResult
            Dim appt = Appointments.FirstOrDefault(Function(a) a.Appointment_ID = id)
            If appt Is Nothing Then
                Return NotFound()
            End If
            Return Ok(appt)
        End Function

        ' POST /api/appointment
        Public Function PostAppointment(newAppt As Appointment) As IHttpActionResult
            newAppt.Appointment_ID = Appointments.Max(Function(a) a.Appointment_ID) + 1
            Appointments.Add(newAppt)
            Return Ok(newAppt)
        End Function

        ' PUT /api/appointment/{id}
        Public Function PutAppointment(id As Integer, updatedAppt As Appointment) As IHttpActionResult
            Dim appt = Appointments.FirstOrDefault(Function(a) a.Appointment_ID = id)
            If appt Is Nothing Then
                Return NotFound()
            End If

            appt.Client_ID = updatedAppt.Client_ID
            appt.DateTime = updatedAppt.Appointment_DateTime
            appt.Location = updatedAppt.Location
            appt.Notes = updatedAppt.Client_Notes

            Return Ok(appt)
        End Function

        ' DELETE /api/appointment/{id}
        Public Function DeleteAppointment(id As Integer) As IHttpActionResult
            Dim appt = Appointments.FirstOrDefault(Function(a) a.Appointment_ID = id)
            If appt Is Nothing Then
                Return NotFound()
            End If

            Appointments.Remove(appt)
            Return Ok()
        End Function
    End Class
End Namespace
