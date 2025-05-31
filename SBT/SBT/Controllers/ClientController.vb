Imports System.Web.Http
Imports System.Collections.Generic
Imports SBT.MockSAMS_API.Models

Namespace MockSAMS_API.Controllers
    Public Class ClientController
        Inherits ApiController

        ' Mock Client Data - Three, James, Christine, Lanah

        Private Shared ReadOnly Clients = New List(Of Client) From {
             New Client With {
                .Client_ID = 1,
                .First_Name = "James",
                .Last_Name = "Mccavoy",
                .Current_Program = "ODSP",
                .Current_Status = "Active",
                .Program_StartDate = New DateTime(2020, 3, 11),
                .Program_ExpiryDate = New DateTime(2026, 3, 15),
                .Program_LastRenewal = New DateTime(2025, 2, 25),
                .Email_Address = "James_Mccavoy1970@hmail.com",
                .Next_AppointmentDate = New DateTime(2026, 2, 25)
            },
            New Client With {
                .Client_ID = 2,
                .First_Name = "Christine",
                .Last_Name = "O' Hara",
                .Current_Program = "Ontario Works",
                .Current_Status = "Active",
                .Program_StartDate = New DateTime(2022, 6, 23),
                .Program_ExpiryDate = New DateTime(2026, 4, 15),
                .Program_LastRenewal = New DateTime(2025, 4, 25),
                .Email_Address = "Ohara19900@hwork.ca",
                .Next_AppointmentDate = New DateTime(2025, 10, 3)
             },
             New Client With {
                .Client_ID = 3,
                .First_Name = "Lanah",
                .Last_Name = "Kim",
                .Current_Program = "ODSP",
                .Current_Status = "Inactive",
                .Program_StartDate = New DateTime(2010, 3, 13),
                .Program_ExpiryDate = New DateTime(2024, 4, 15),
                .Program_LastRenewal = New DateTime(2023, 4, 15),
                .Email_Address = "LKimFlyHigh@naver.com",
                .Next_AppointmentDate = Nothing
        }
    }


        Public Function GetClients() As IEnumerable(Of Client)
            Return Clients
        End Function

    End Class
End Namespace
