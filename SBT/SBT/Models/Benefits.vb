Namespace MockSAMS_API.Models
    Public Class Benefit

        'Benefits - Assuming they have benefit id, benefit Title, description, active status, and the expiry date.

        Public Property Benefits_ID As Integer
        Public Property Title As String
        Public Property Description As String
        Public Property IsActive As Boolean
        Public Property ExpiryDate As DateTime
    End Class
End Namespace