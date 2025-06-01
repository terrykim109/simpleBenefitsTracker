Imports System.Web.Http
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

        ' GET Benefit
        Public Function GetBenefitById(id As Integer) As IHttpActionResult
            Dim benefit As Benefit = Nothing

            For Each b As Benefit In Benefits
                If b.Benefits_ID = id Then
                    benefit = b
                    Exit For
                End If
            Next

            If benefit Is Nothing Then
                Return NotFound()
            End If
            Return Ok(benefit)
        End Function

        ' Add new Benefits 
        Public Function PostBenefit(newBenefit As Benefit) As IHttpActionResult
            Dim maxId As Integer = 0

            For Each b As Benefit In Benefits
                If b.Benefits_ID > maxId Then
                    maxId = b.Benefits_ID
                End If
            Next

            newBenefit.Benefits_ID = maxId + 1
            Benefits.Add(newBenefit)
            Return Ok(newBenefit)
        End Function

        ' Update New Benefit 
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
            Dim benefitToRemove As Benefit = Nothing

            For Each b As Benefit In Benefits
                If b.Benefits_ID = id Then
                    benefitToRemove = b
                    Exit For
                End If
            Next

            If benefitToRemove Is Nothing Then
                Return NotFound()
            End If

            Benefits.Remove(benefitToRemove)
            Return Ok()
        End Function
    End Class
End Namespace
