module SortingAlgorithm

// "rec" denotes this function is recursive
// You cannot call the same function without this keyword
let rec quicksort list = 
    match list with
        // If the list is empty return an empty list
        | [] -> []
        // Otherwise split the list into the first element
        // and a list of the other elements in the list
        | firstElem::otherElements ->
            // Function to get the elements smaller than our current element
            let smallerElements = 
                otherElements
                    |> List.filter (fun e -> e < firstElem)
                    |> quicksort
            // Function to get the elements larger than our current element
            let largerElements =
                otherElements
                    |> List.filter (fun e -> e >= firstElem)
                    |> quicksort

            // Run the 2 functions and create a new list with the right order
            List.concat [smallerElements; [firstElem]; largerElements]

quicksort [1;5;9;34;2;68;2;0] |> printfn "%A"

// Same as above but much more compact, the succinct code is due to
// the lack of typing and ability to pipe arguments easily
let rec compactquicksort = function
    | [] -> []
    | first::rest ->
        let smaller,larger = List.partition((>=) first) rest
        List.concat [compactquicksort smaller; [first]; compactquicksort larger]

compactquicksort [1;5;9;34;2;68;2;0] |> printfn "%A"

// Breaking the compact code down
// "List.partition" takes a function and splits the list based on whether
// it resolves to true or false.  A tuple is then output based on this result
// Here the function is "((>=) 2)"
let smaller, larger = List.partition((>=) 2) [1;3;2]

// This is the same code but with a clearer, more verbose anonymous function.
let small, large = List.partition(fun x -> x >= 2) [1;3;2]

// From here it's just understanding the function calls itself recursively
// Splitting and ordering smaller portions of the list until none remain
// It would iterate through our original list like so:
//    [1;5;9;34;2;68;2;0]
//    [0] [1] [5;9;34;2;68;2]
//    [0] [1] [2;2] [5] [9;34;68]
//    [0] [1] [2] [2] [5] [9] [34;68]
//    [0] [1] [2] [2] [5] [9] [34] [68]