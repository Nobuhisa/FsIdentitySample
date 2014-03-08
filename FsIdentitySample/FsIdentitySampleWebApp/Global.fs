﻿namespace FsWeb

open System
open System.Web
open System.Web.Mvc
open System.Web.Routing
open System.Data.Entity
open FsWeb.Models

type Route = { controller : string
               action : string
               id : UrlParameter }

type Global() =
    inherit System.Web.HttpApplication() 

    static member RegisterRoutes(routes:RouteCollection) =
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.MapRoute("Default", 
                        "{controller}/{action}/{id}", 
                        { controller = "Home"; action = "Index"
                          id = UrlParameter.Optional } )

    member this.Start() =
        AreaRegistration.RegisterAllAreas()
        Global.RegisterRoutes(RouteTable.Routes) |> ignore

        Database.SetInitializer<MyDbContext>(MyDbInitializer())