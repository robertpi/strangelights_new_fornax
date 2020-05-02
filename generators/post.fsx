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

    let body = [
        Layout.titleSegment siteInfo
        div [Class "container"] [
            section [Class "articles"] [
                div [Class "column is-8 is-offset-2"] [
                    Layout.postLayout false siteInfo post
                ]
            ]
        ]
    ]

    Layout.layout ctx post.title body post.link (Some post.title) (Some post.summary)


let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
    generate' ctx page
    |> Layout.render ctx