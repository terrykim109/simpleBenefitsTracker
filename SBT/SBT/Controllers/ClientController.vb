﻿Imports System.Web.Http
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
        'Getting Cllient
        Public Function GetClientById(id As Integer) As IHttpActionResult
            Dim foundClient As Client = Nothing

            For Each c As Client In Clients
                If c.Client_ID = id Then
                    foundClient = c
                    Exit For
                End If
            Next

            If foundClient Is Nothing Then
                Return NotFound()
            End If

            Return Ok(foundClient)
        End Function

        'Putting New Client
        Public Function PostClient(newClient As Client) As IHttpActionResult
            Dim maxId As Integer = 0

            For Each c As Client In Clients
                If c.Client_ID > maxId Then
                    maxId = c.Client_ID
                End If
            Next

            newClient.Client_ID = maxId + 1
            Clients.Add(newClient)
            Return Ok(newClient)
        End Function

        'Updating Client
        Public Function PutClient(id As Integer, updatedClient As Client) As IHttpActionResult
            Dim client As Client = Nothing

            For Each c As Client In Clients
                If c.Client_ID = id Then
                    client = c
                    Exit For
                End If
            Next

            If client Is Nothing Then
                Return NotFound()
            End If

            client.First_Name = updatedClient.First_Name
            client.Last_Name = updatedClient.Last_Name
            client.Current_Program = updatedClient.Current_Program
            client.Current_Status = updatedClient.Current_Status
            client.Program_StartDate = updatedClient.Program_StartDate
            client.Program_ExpiryDate = updatedClient.Program_ExpiryDate
            client.Program_LastRenewal = updatedClient.Program_LastRenewal
            client.Email_Address = updatedClient.Email_Address
            client.Next_AppointmentDate = updatedClient.Next_AppointmentDate

            Return Ok(client)
        End Function

        'Removing Client
        Public Function DeleteClient(id As Integer) As IHttpActionResult
            Dim client As Client = Nothing
            For Each c As Client In Clients
                If c.Client_ID = id Then
                    client = c
                    Exit For
                End If
            Next

            If client Is Nothing Then
                Return NotFound()
            End If

            Clients.Remove(client)

            Return Ok()
        End Function

        Public Function GetClients() As IEnumerable(Of Client)
            Return Clients
        End Function

    End Class
End Namespace
