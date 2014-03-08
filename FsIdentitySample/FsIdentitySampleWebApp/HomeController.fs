namespace FsWeb.Controllers

open System.Web
open System.Web.Mvc

[<HandleError>]
type HomeController() =
    inherit Controller()

    member this.Index () = this.View()

    [<Authorize>]
    member this.MemberPage() = this.View()

    [<Authorize(Roles = "Admin")>]
    member this.Admin() = this.View()
