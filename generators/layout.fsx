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

let layout (ctx : SiteContents) active bodyCnt =
    let pages = ctx.TryGetValues<Pageloader.Page> () |> Option.defaultValue Seq.empty
    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
    let ttl =
      siteInfo
      |> Option.map (fun si -> si.title)
      |> Option.defaultValue ""

    let menuEntries =
      pages
      |> Seq.map (fun p ->
        let cls = if p.title = active then "navbar-item is-active" else "navbar-item"
        a [Class cls; Href p.link] [!! p.title ])
      |> Seq.toList

    html [] [
        head [] [
            meta [CharSet "utf-8"]
            meta [Name "viewport"; Content "width=device-width, initial-scale=1"]
            title [] [!! ttl]
            link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href "/images/favicon.png"]
            link [Rel "stylesheet"; Href "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"]
            link [Rel "stylesheet"; Href "https://fonts.googleapis.com/css?family=Open+Sans"]
            link [Rel "stylesheet"; Href "https://unpkg.com/bulma@0.8.0/css/bulma.min.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "/style/style.css"]

        ]
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
