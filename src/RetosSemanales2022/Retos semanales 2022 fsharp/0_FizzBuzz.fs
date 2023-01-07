module Reto0

open Xunit

let GetFizzBuzzString (i : int) =
    match (i % 3 = 0, i % 5 = 0) with
    | (true, true) -> "fizzbuzz"
    | (true, _) -> "fizz"
    | (_, true) -> "buzz"
    | _ -> string i

let FizzBuzz = 
    printfn "Reto 0 f# FizzBuzz"

    [1..100]
    |> List.map GetFizzBuzzString
    |> String.concat "\n"
    |> printfn "%s"

    printfn "Reto 0 fin"


[<Fact>]
let ``FizzBuzz devuelve resultados correctos para 15 primeros inputs`` () =
    let casos =
        [
            (1, "1");
            (2, "2");
            (3, "fizz");
            (4, "4");
            (5, "buzz");
            (6, "fizz");
            (7, "7");
            (8, "8");
            (9, "fizz");
            (10, "buzz");
            (11, "11");
            (12, "fizz");
            (13, "13");
            (14, "14");
            (15, "fizzbuzz");
        ]
        
    casos
    |> List.iter (fun (i, esperado) ->
        let actual = GetFizzBuzzString i
        Assert.Equal(esperado, actual)
    )
    
   

    

