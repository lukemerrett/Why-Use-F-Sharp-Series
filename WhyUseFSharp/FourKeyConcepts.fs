module FourKeyConcepts

(*
    Function-oriented rather than object-oriented
    Expressions rather than statements
    Algebraic types for creating domain models
    Pattern matching for flow of control
*)

// Function-orientated
// -------------------

// As functions are first class citizens they can be passed around and used freely
// like standard variables.
// Allows us to focus on composition; building larger functions atop smaller ones
// Helps maintain separation of concerns and single responsibility principle

let square x = x * x
let squareclone = square

let result = [1..10] |> List.map squareclone

// "execFunction" is completely generic, taking in a function and parameter to execute
// Demonstrates functions as first class citizens
let execFunction aFunc aParam = aFunc aParam
let result2 = execFunction square 12

// Expressions rather than statements
// ----------------------------------

// Every piece of code returns a value, allowing composition
// Expressions tend to be safer and more compact
// Maintain less state (or no state) and reduce room for error

// Algebraic types
// ---------------

// The F# type system is based on algebraic data types
// This simply means new compound types can be created from existing types
// Either "product types" combining labels from a set of types
// Or "sum types" allowing a choice between a set of types
// Useful for states in state machines

// Product types
type IntAndBool = {intPart: int; boolPart: bool}
let x = {intPart=1; boolPart=false}


// Sum types (Union types)
type IntOrBool = 
    | IntChoice of int
    | BoolChoice of bool

let y = IntChoice 42
let z = BoolChoice true

// Pattern matching for flow of control
// ------------------------------------

// F#'s common control flow statement is "match x with"
// This represents a powerful filtering system when combined with union types

// The * syntax here is confusing, it is actually declaring the types expected
// by the tuples being passed in to the union types

type SinglePoint = (int * int)

type Shape = 
    | Circle of int
    | Rectangle of SinglePoint
    | Polygon of SinglePoint list
    | Point of SinglePoint

let draw shape =
    match shape with
        | Circle radius ->
            printfn "The circle has a radius of %d" radius
        | Rectangle (height, width) ->
            printfn "The rectangle is %d high by %d wide" height width
        | Polygon points ->
            printfn "The polygon is made of these points %A" points
        | _ -> printfn "I don't recognise this shape"

let circle = Circle(10)
let rect = Rectangle(4,5)
let polygon = Polygon([(1,1); (2,2); (3,3)])
let point = Point(2,3)

[circle; rect; polygon; point] |> List.iter draw