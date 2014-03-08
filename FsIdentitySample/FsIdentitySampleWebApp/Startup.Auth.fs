namespace FsWeb.Identity

open Owin
open Microsoft.Owin
open Microsoft.Owin.Security.Cookies
open Microsoft.AspNet.Identity

type Startup() =
    let configureAuth (app:IAppBuilder) : unit =
        CookieAuthenticationOptions(
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = PathString("/Account/Login")
        )
        |> app.UseCookieAuthentication |> ignore

        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

    member this.Configuration(app:IAppBuilder) = configureAuth app


[<assembly:Microsoft.Owin.OwinStartup(typeof<Startup>)>]
do ()