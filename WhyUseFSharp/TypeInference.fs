module TypeInference

// In both the below examples, neither requires a generic type definition

// F# version of Linq .Where()
let Where source predicate 
    = Seq.filter predicate source

// F# version of Linq .GroupBy()
let GroupBy source keySelector = 
    Seq.groupBy keySelector source

let myList = [2;3;4;5]
let myFilteredList = Where myList (fun x -> x < 3) 

printfn "%A" myFilteredList


// Lot's of types, no explicit declaration
let i  = 1
let s = "hello"
let tuple  = s,i      // pack into tuple   
let s2,i2  = tuple    // unpack
let list = [s2]       // type is string list

let sumLengths strList = 
    strList |> List.map String.length |> List.sum