#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"

open Html


let generate' (ctx : SiteContents) (page: string) =
    let post = ctx.TryGetValues<Postloader.Post> ()

    let post =
        post
        |> Option.defaultValue Seq.empty
        |> Seq.find (fun n -> n.file = System.Web.HttpUtility.UrlDecode(page))

    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
    let title =
        siteInfo
        |> Option.map (fun si -> si.title)
        |> Option.defaultValue ""
    let desc =
        siteInfo
        |> Option.map (fun si -> si.description)
        |> Option.defaultValue ""

    Layout.layout ctx post.title [
        section [Class "hero is-info is-medium is-bold"] [
            div [Class "hero-body"] [
                div [Class "container has-text-centered"] [
                    h1 [Class "title"] [!!title]
                    h4 [Class "title"] [!!desc]
                ]
            ]
        ]
        div [Class "container"] [
            section [Class "articles"] [
                div [Class "column is-8 is-offset-2"] [
                    Layout.postLayout false siteInfo post
                ]
            ]
        ]
    ]

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
    generate' ctx page
    |> Layout.render ctx