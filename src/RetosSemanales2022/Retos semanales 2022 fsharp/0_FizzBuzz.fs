(*
 * Reto #0
 * EL FAMOSO "FIZZ BUZZ"
 * Fecha publicación enunciado: 27/12/21
 * Fecha publicación resolución: 07/01/23
 * Dificultad: FÁCIL
 * Enunciado: Escribe un programa que muestre por consola (con un print) los números de 1 a 100 (ambos incluidos y con un salto de línea entre cada impresión), sustituyendo los siguientes:
 * - Múltiplos de 3 por la palabra "fizz".
 * - Múltiplos de 5 por la palabra "buzz".
 * - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
 * 
 *)

module Reto0

open Xunit

let FizzBuzzONumero (i : int) =
    match (i % 3 = 0, i % 5 = 0) with
    | (true, true) -> "fizzbuzz"
    | (true, _) -> "fizz"
    | (_, true) -> "buzz"
    | _ -> string i

let MuestraResultadosFizzBuzz = 
    printfn "Reto 0 f# FizzBuzz"

    [1..100]
    |> List.map FizzBuzzONumero
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
        let actual = FizzBuzzONumero i
        Assert.Equal(esperado, actual)
    )
    
   

    

