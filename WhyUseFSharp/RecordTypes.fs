module RecordTypes

type Person = {FirstName:string; LastName: string}
type Employee = {FirstName:string; LastName: string}
        
// The compiler believes this to be an Employee
// This is because it uses the last type matching the labels used
let whatAmI = {FirstName="Bob"; LastName="Bills"}

// To be explicit about the type we can specify which type we want to use
let iAmAPerson = {Person.FirstName="Bob"; Person.LastName="Bills"}
let iAmAnEmployee = {Employee.FirstName="Bob"; Employee.LastName="Bills"}

// How about this set of Record types, they overlap with one another?
type ErrorCode = {Code:int}
type ErrorMessage = {Message:string}
type Error = {Code:int; Message:string}

// This won't compile as the last Record type with label "Code" 
// also required the label "Message", so the compiler cannot infer type
//    let errorCode = {Code=99}

// This is totally fine as we've hinted the type to use in each instance
let errorCode = {ErrorCode.Code=99}
let errorMsg = {ErrorMessage.Message="Error 99"}
let error = {Error.Code=99; Error.Message="Error 99"}