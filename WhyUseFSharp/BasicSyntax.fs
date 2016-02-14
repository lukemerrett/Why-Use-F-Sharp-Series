module BasicSyntax

// Single line comment

(* 
    Multi-line comment
*)

// The "let" keyword defines an immutable value
// This is a value that cannot be changed after initialisation
let myInt = 5
let myFloat = 3.14
let myString = "hello"
let twoToFiveList = [2;3;4;5]

// Add an item to the front of a list
let oneToFiveList = 1 :: twoToFiveList

// Add 2 lists together
let zeroToFiveList = [0;1] @ twoToFiveList

// Functions are first class citizens so can be declared in the same way
let square x = x * x
let add x y = x + y

let squareOfThree = square 3

// Pass the result into a print statement
// "%i" tells print to expect an integer
// "|>" pipes the result as the last value to the function
square 3 |> printfn "3 squared is %i"
add 3 5 |> printfn "3 + 5 is %i"

// New function "evens" that takes a list of ints
// Returns a new list containing only even numbers
let evens list =
    let isEven x = x%2 = 0
    List.filter isEven list

// "%A" prints the default representation of any type
// Here it prints out the list as "[2; 4]"
evens oneToFiveList |> printfn "%A"

// Traditional nested functions
// [1..100] creates a list containing all values from 1 to 100
// "List.map" runs the function against each item in the list
// Note how there is no return statement, returns are implicit
// The last value is what is returned
let sumOfSquaresTo100 = 
    List.sum(List.map square [1..100])

// The same as the "sumOfSquaresTo100" but using pipes
// The result of the preceding statement is passed as the last value
// into the next function
let sumOfSquaresTo100Piped =
    [1..100] |> List.map square |> List.sum

// The same as the above two functions but with an anonymous func
let sumOfSquaresTo100WithFunction = 
    [1..100] |> List.map (fun x->x*x) |> List.sum

// Should all print the same values
printfn "%A" sumOfSquaresTo100
printfn "%A" sumOfSquaresTo100Piped
printfn "%A" sumOfSquaresTo100WithFunction

// Pattern matching basics
// Similar to switch/case statements but much more flexible
let simplePatternMatch x = 
    match x with
        | "a" -> printfn "x is a"
        | "b" -> printfn "x is b"
        | _ -> printfn "x is something else" // Like "default" in switch

simplePatternMatch "a"
simplePatternMatch "b"
simplePatternMatch "c"

// Demonstrating Some and None pattern matching
// Like nullable types in C#, lets you switch on whether they have a value
let optionPatternMatch input = 
    match input with
        | Some i -> printfn "input is an int=%i" i
        | None -> printfn "input is missing"

let validValue = Some(99)
let invalidValue = None

optionPatternMatch validValue
optionPatternMatch invalidValue

// Complex Data Types
// Tuples are seperated by commas and don't have to contain the same type
let twoTuple = 1,2
let threeTuple = "a",3,true

// Record types have named fields, like standard DTOs or POCOs
type Person = {First: string; Last: string}

// Note how here we don't have to declare what type we are creating
// It infers type based on the fields declared
let person1 = {First="John";  Last="Doe"}

// Union types have choices between different sub-types
type Temperature = 
    | DegreesC of float
    | DegreesF of float

let temp = DegreesF 98.6

// Types can be combined recursively with themselves as below
type Employee = 
    | Worker of Person
    | Manager of Employee list

let jdoe = {First="John"; Last="Doe"}
let worker = Worker jdoe
let manager = Manager [worker]