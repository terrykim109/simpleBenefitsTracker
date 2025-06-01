Imports System.Web.Http

Namespace MockSAMS_API.Controllers
    <RoutePrefix("api")>
    Public Class ApiRootController
        Inherits ApiController

        ' This will match GET requests to "/api"
        <HttpGet>
        <Route("")>
        Public Function [Get]() As IHttpActionResult
            Return Ok("API Root: MockSAMS is running.")
        End Function
    End Class
End Namespace
