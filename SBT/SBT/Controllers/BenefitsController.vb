' File: Controllers\BenefitsController.vb


Imports System.Web.Http
Imports System.Collections.Generic
Imports MockSAMS_API.Models
Imports SBT.MockSAMS_API.Models


Namespace MockSAMS_API.Controllers
    Public Class BenefitsController
        Inherits ApiController

        ' BEnefits examples
        Private Shared ReadOnly Benefits = New List(Of Benefit) From {
            New Benefit With {
                .Benefits_ID = 1,
                .Title = "ODSP",
                .Description = "Ontario Disability Support Program",
                .IsActive = True,
                .ExpiryDate = New DateTime(2048, 7, 1)
            },
            New Benefit With {
                .Benefits_ID = 2,
                .Title = "Ontario Works",
                .Description = "Basic financial assistance for low‐income residents",
                .IsActive = True,
                .ExpiryDate = New DateTime(2050, 10, 1)
            }
        }

        ' GET /api/benefit
        Public Function GetBenefits() As IEnumerable(Of Benefit)
            Return Benefits
        End Function

        ' GET 
        Public Function GetBenefitById(id As Integer) As IHttpActionResult
            Dim benefit = Benefits.FirstOrDefault(Function(b) b.Benefit_ID = id)
            If benefit Is Nothing Then
                Return NotFound()
            End If
            Return Ok(benefit)
        End Function

        ' POST 
        Public Function PostBenefit(newBenefit As Benefit) As IHttpActionResult
            newBenefit.Benefits_ID = Benefits.Max(Function(b) b.Benefit_ID) + 1
            Benefits.Add(newBenefit)
            Return Ok(newBenefit)
        End Function

        ' PUT 
        Public Function PutBenefit(id As Integer, updatedBenefit As Benefit) As IHttpActionResult
            Dim existing As Benefit = Nothing

            For Each b As Benefit In Benefits
                If b.Benefits_ID = id Then
                    existing = b
                    Exit For
                End If
            Next

            If existing Is Nothing Then
                Return NotFound()
            End If

            existing.Title = updatedBenefit.Title
            existing.Description = updatedBenefit.Description
            existing.IsActive = updatedBenefit.IsActive
            existing.ExpiryDate = updatedBenefit.ExpiryDate

            Return Ok(existing)
        End Function


        ' DELETE 
        Public Function DeleteBenefit(id As Integer) As IHttpActionResult
            Dim benefit = Benefits.FirstOrDefault(Function(b) b.Benefit_ID = id)
            If benefit Is Nothing Then
                Return NotFound()
            End If

            Benefits.Remove(benefit)
            Return Ok()
        End Function
    End Class
End Namespace
