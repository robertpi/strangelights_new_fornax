#r "../_lib/Fornax.Core.dll"
#if !FORNAX
#load "../loaders/postloader.fsx"
#load "../loaders/pageloader.fsx"
#load "../loaders/globalloader.fsx"
#endif

open Html

let injectWebsocketCode (webpage:string) =
    let websocketScript =
        """
        <script type="text/javascript">
          var wsUri = "ws://localhost:8080/websocket";
      function init()
      {
        websocket = new WebSocket(wsUri);
        websocket.onclose = function(evt) { onClose(evt) };
      }
      function onClose(evt)
      {
        console.log('closing');
        websocket.close();
        document.location.reload();
      }
      window.addEventListener("load", init, false);
      </script>
        """
    let head = "<head>"
    let index = webpage.IndexOf head
    webpage.Insert ( (index + head.Length + 1),websocketScript)

let titleSegment (siteInfo: option<Globalloader.SiteInfo>) =
    let title, desc =
      siteInfo
      |> Option.map (fun si -> si.title, si.description)
      |> Option.defaultValue ("", "")

    section [Class "hero is-info is-bold"] [
      div [Class "hero-body"] [
        div [Class "container has-text-centered"] [
          h1 [Class "title"] [ span [Class "transparent-backgroud"] [!!title] ]
          h3 [] [ span [Class "transparent-backgroud"] [!!desc] ]
        ]
      ]
    ]

let layout (ctx : SiteContents) active bodyCnt url pageTitle pageDescription =
    let pages = ctx.TryGetValues<Pageloader.Page> () |> Option.defaultValue Seq.empty
    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
    let ttl =
      siteInfo
      |> Option.map (fun si -> si.title)
      |> Option.defaultValue ""
    let desc =
      siteInfo
      |> Option.map (fun si -> si.description)
      |> Option.defaultValue ""

    let menuEntries =
      pages
      |> Seq.map (fun p ->
        let cls = if p.title = active then "navbar-item is-active" else "navbar-item"
        a [Class cls; Href p.link] [!! p.title ])
      |> Seq.toList

    let socialMediaPreviewTags (siteInfo: Globalloader.SiteInfo) =
        let fullUrl = sprintf "%s/%s" siteInfo.baseUrl url
        let description = Option.defaultValue siteInfo.description pageDescription
        let title =
            pageTitle
            |> Option.map (fun t -> sprintf "%s | %s" t siteInfo.title)
            |> Option.defaultValue siteInfo.description
        [ yield meta [Property "og:url"; Content fullUrl ]
          yield meta [Property "og:type"; Content "article"]
          yield meta [Property "og:title"; Content title ]
          yield meta [Property "og:description"; Content description ]
          yield meta [Property "twitter:card"; Content "summary" ]
          yield meta [Property "twitter:url"; Content fullUrl ]
          yield meta [Property "twitter:title"; Content title ]
          yield meta [Property "twitter:description"; Content description ]
          match siteInfo.imageSocialMediaPreview with
          | Some image ->
              let fullImageUrl = siteInfo.baseUrl + image
              yield meta [Property "og:image"; Content fullImageUrl ]
              yield meta [Property "twitter:image"; Content fullImageUrl ]
          | None -> () ]

    html [] [
        head [] [
            yield meta [CharSet "utf-8"]
            yield meta [Name "viewport"; Content "width=device-width, initial-scale=1"]
            yield title [] [!! ttl]
            yield link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href "/images/favicon.png"]
            yield link [Rel "stylesheet"; Href "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"]
            yield link [Rel "stylesheet"; Href "https://fonts.googleapis.com/css?family=Open+Sans"]
            yield link [Rel "stylesheet"; Href "https://unpkg.com/bulma@0.8.0/css/bulma.min.css"]
            yield link [Rel "stylesheet"; Type "text/css"; Href "/style/style.css"]
            match siteInfo with
            | Some siteIndo -> yield! socialMediaPreviewTags siteIndo
            | None -> () ]

        body [] [
          nav [Class "navbar"] [
            div [Class "container"] [
              div [Class "navbar-brand"] [
                span [Class "navbar-burger burger"; Custom ("data-target", "navbarMenu")] [
                  span [] []
                  span [] []
                  span [] []
                ]
              ]
              div [Id "navbarMenu"; Class "navbar-menu"] menuEntries
            ]
          ]
          yield! bodyCnt
        ]
    ]

let render (ctx : SiteContents) cnt =
  let disableLiveRefresh = ctx.TryGetValue<Postloader.PostConfig> () |> Option.map (fun n -> n.disableLiveRefresh) |> Option.defaultValue false
  cnt
  |> HtmlElement.ToString
  |> fun n -> if disableLiveRefresh then n else injectWebsocketCode n

let published (post: Postloader.Post) =
    post.published
    |> Option.defaultValue System.DateTime.Now
    |> fun n -> n.ToString("yyyy-MM-dd")

let shareButtons (url: string) =
  let encodeUrl = System.Web.HttpUtility.UrlEncode(url)
  let s = HtmlProperties.Style [BackgroundColor "black"]
  div [Class "share-text"] [
    a [ Href (sprintf "https://www.addtoany.com/add_to/twitter?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/twitter.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/add_to/linkedin?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/linkedin.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/add_to/facebook?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/facebook.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/add_to/reddit?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/reddit.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/add_to/email?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/email.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/add_to/mastodon?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/mastodon.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/add_to/copy_link?linkurl=%s&amp;linkname=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/link.svg"; Width "32"; Height "32"; s ]]
    a [ Href (sprintf "https://www.addtoany.com/share#url=%s&amp;title=" encodeUrl); Target "_blank"] [img [Src "https://static.addtoany.com/buttons/a2a.svg"; Width "32"; Height "32"; s ]]
    ]

let postLayout (useSummary: bool) (siteInfoOpt: option<Globalloader.SiteInfo>) (post: Postloader.Post) =
    let socialMediaSquare urlBase username squarename =
      a [Href (sprintf "https://%s/%s" urlBase username )] [
          i [Class (sprintf "fa fa-%s fa-1x" squarename) ] [] ]

    let mediaHeader (siteInfo: Globalloader.SiteInfo) =
      div [] [
        match siteInfo.imageThumb with
        | Some path ->
            let displayNone  = HtmlProperties.Style [Display "none"; ]
            yield input [Type "checkbox"; Id "check"; displayNone ]
            yield label [Custom("for", "check" )] [
              img [ Class "author-image"; Src path ] ]
            match siteInfo.imageLarge with
            | Some path ->
              yield label [Custom("for", "check" )] [
                div [Id "cover"] [
                  div [Id "box"] [ img [ Class "author-image-large"; Src path ] ] ] ]
            | None -> ()
        | None -> ()

        yield p [Class "title"] [ span [Class "transparent-backgroud"] [
          match siteInfo.linkedin with
          | Some linkedin ->
              yield socialMediaSquare "linkedin.com/in" linkedin "linkedin-square"
          | None -> ()
          match siteInfo.github with
          | Some github ->
              yield socialMediaSquare "github.com" github "github-square"
          | None -> ()
          match siteInfo.twitter with
          | Some twitter ->
              yield socialMediaSquare "twitter.com" twitter "twitter-square"
          | None -> ()
          match siteInfo.facebook with
          | Some facebook ->
              yield socialMediaSquare "facebook.com" facebook "facebook-square"
          | None -> ()
          match siteInfo.instagram with
          | Some facebook ->
              yield socialMediaSquare "instagram.com" facebook "instagram"
          | None -> () ] ]
      ]

    div [Class "card article"] [
        div [Class "card-content"] [
            div [Class "media-content has-text-centered"] [
              match siteInfoOpt with
              | Some siteInfo ->
                  yield mediaHeader siteInfo
              | None -> ()
              yield p [] [ !! "&nbsp;"]
              yield p [Class "title article-title"; ] [ span [Class "transparent-backgroud"] [a [Href post.link] [!! post.title]]]
              yield p [Class "subtitle is-6 article-subtitle"] [
              yield a [Href "#"] [!! (defaultArg post.author "")]
              yield !! (sprintf "Published: %s" (published post)) ]
              if not useSummary then yield shareButtons post.link
            ]
            div [Class "content article-body"] [
                !! (if useSummary then post.summary else post.content)
            ]
            if useSummary then
              div [Class "content article-body"] [
                a [Href post.link] [!! "Continue reading ..."]
              ]
            else
              div [] []
        ]
    ]
