module DownloadWebPage

open System.Net
open System
open System.IO

let fetchUrl callback url =        
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    callback reader url

// Note how in this instance we have to hint to F# what the type is
let myCallback (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let first1000Characters = html.Substring(0,1000)
    printfn "Downloaded %s. First 1000 characters are %s" url first1000Characters

let google = fetchUrl myCallback "http://www.google.com"

// Here we can "bake in" the first parameter, creating a new function
// that only expects the url
let fetchAndPrint1000Characters = fetchUrl myCallback

let sites = [
    "http://www.lukemerrett.com";
    "http://www.google.com";
    "http://www.yahoo.com"
]

sites |> List.iter fetchAndPrint1000Characters