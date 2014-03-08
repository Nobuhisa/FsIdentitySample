namespace FsWeb

open Microsoft.AspNet.Identity
open Microsoft.AspNet.Identity.EntityFramework
open Microsoft.AspNet.Identity.Owin
open System.Data.Entity
open FsWeb.Models

type MyDbInitializer() =
    inherit DropCreateDatabaseAlways<MyDbContext>()

    let createUserManager context =
        new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context))

    let createRoleManager context =
        new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context))

    let init context =
        use userManager = createUserManager context
        use roleManager = createRoleManager context

        let adminRoleName = "Admin"
        let adminUser = ApplicationUser(UserName = "admin", Email = "a@b.com")

        if not <| roleManager.RoleExists(adminRoleName) then
            roleManager.Create(IdentityRole(adminRoleName)) |> ignore

        userManager.Create(adminUser, password = "123456") |> ignore
        userManager.AddToRole(adminUser.Id, adminRoleName) |> ignore

    override this.Seed(context) =
        init context
        base.Seed(context)