#r "../_lib/Fornax.Core.dll"
#r "../_lib/Markdig.dll"
#load "layout.fsx"

open Markdig
open Html

let about = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi diam, vehicula quis blandit id, suscipit sed libero. Proin at diam dolor. In hac habitasse platea dictumst. Donec quis dui vitae quam eleifend dignissim non sed libero. In hac habitasse platea dictumst. In ullamcorper mollis risus, a vulputate quam accumsan at. Donec sed felis sodales, blandit orci id, vulputate orci."

let generate' (ctx : SiteContents) (page: string) =
    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()

    let text = """Robert is a Paris based software engineering leader and published technical author. He has a proven track record growing startups from scratch into successful, high value companies. He has also helped deliver important projects within large corporate environments.

He believes in creating a software engineering culture that is experiment-based and empowerment-based. His style of leadership is to motivate the team by ensuring they understand why the features they are working on are important and ensuring they believe in the design choices that have been made.

He has a good understanding of agile development and believes in the removal of toil though aggressive automation and the importance of small but frequent releases to production.  He believes software design is about understanding tradeoffs, particularly between developing a long-term vision while delivering value in the short term. He speaks at software conferences from time to time.
"""

    let post: Postloader.Post =
        { file = page
          link = page
          title = "About"
          author = None
          published = None
          tags = []
          content =  Markdown.ToHtml(text)
          summary = text
          summaryTagFree = text }

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

    Layout.layout ctx post.title body page

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page None None
  |> Layout.render ctx