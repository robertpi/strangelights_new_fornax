#r "_lib/Fornax.Core.dll"

open Config
open System.IO

let postPredicate (projectRoot: string, page: string) =
    let fileName = Path.Combine(projectRoot,page)
    let ext = Path.GetExtension page
    let isMdFile = ext = ".md" && page.Contains "_public" |> not
    if isMdFile then 
        // hack to handle encoding issues
        if File.Exists fileName then
            let header = 
                File.ReadLines fileName 
                |> Seq.skip 1 
                |> Seq.takeWhile (fun x -> x.StartsWith("---") |> not)
            let shouldProcess = 
                header |> Seq.exists (fun x -> x = "draft: true") |> not 
            printfn "%b" shouldProcess
            shouldProcess
        else true
    else false

let staticPredicate (projectRoot: string, page: string) =
    let ext = Path.GetExtension page
    if page.Contains "_public" ||
       page.Contains "_bin" ||
       page.Contains "_lib" ||
       page.Contains "_data" ||
       page.Contains "_settings" ||
       page.Contains "_config.yml" ||
       page.Contains ".sass-cache" ||
       page.Contains ".git" ||
       page.Contains ".ionide" ||
       ext = ".fsx"
    then
        false
    else
        true


let config = {
    Generators = [
        {Script = "less.fsx"; Trigger = OnFileExt ".less"; OutputFile = ChangeExtension "css" }
        {Script = "sass.fsx"; Trigger = OnFileExt ".scss"; OutputFile = ChangeExtension "css" }
        {Script = "post.fsx"; Trigger = OnFilePredicate postPredicate; OutputFile = ChangeExtension "html" }
        {Script = "staticfile.fsx"; Trigger = OnFilePredicate staticPredicate; OutputFile = SameFileName }
        {Script = "index.fsx"; Trigger = Once; OutputFile = MultipleFiles(id) }
        {Script = "about.fsx"; Trigger = Once; OutputFile = NewFileName "about.html" }
    ]
}
