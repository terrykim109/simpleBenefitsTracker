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
                .ExpiryDate = New DateTime(1998, 7, 1)
            },
            New Benefit With {
                .Benefits_ID = 2,
                .Title = "Ontario Works",
                .Description = "Basic financial assistance for low‐income residents",
                .IsActive = True,
                .ExpiryDate = New DateTime(1998, 10, 1)
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
            Dim existing = Benefits.FirstOrDefault(Function(b) b.Benefit_ID = id)
            If existing Is Nothing Then
                Return NotFound()
            End If

            existing.Name = updatedBenefit.Title
            existing.Description = updatedBenefit.Description
            existing.IsActive = updatedBenefit.IsActive
            existing.EffectiveDate = updatedBenefit.ExpiryDate

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
