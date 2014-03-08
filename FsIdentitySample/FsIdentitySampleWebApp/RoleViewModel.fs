namespace FsWeb.Models

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel

[<CLIMutable>]
type RoleViewModel = {
    Id : string

    [<Required; Display(Name = "Role name")>]
    Name : string
}