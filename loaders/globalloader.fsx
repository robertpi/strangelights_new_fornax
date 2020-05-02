#r "../_lib/Fornax.Core.dll"

type SiteInfo = {
    title: string
    description: string
    imageThumb: string option
    imageLarge: string option
    linkedin: string option
    github: string option
    twitter: string option
    facebook: string option
    instagram: string option
}

let loader (projectRoot: string) (siteContent: SiteContents) =
    let siteInfo =
        { title = "Strangelights";
          description = "Another tech blog."
          imageThumb = Some "/images/266A7910_small.jpg"
          imageLarge = Some "/images/266A7910_large.jpg"
          linkedin = Some "robertpickering"
          github = Some "robertpi"
          twitter = Some "robertpi"
          facebook = Some "robertfpickering"
          instagram = Some "robertfpickering" }
    siteContent.Add(siteInfo)

    siteContent
