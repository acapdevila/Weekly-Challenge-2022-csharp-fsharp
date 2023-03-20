(*
 * Reto #3
 * ¿ES UN NÚMERO PRIMO?
 * Fecha publicación enunciado: 17/01/22
 * Fecha publicación resolución: 24/01/22
 * Dificultad: MEDIA
 *
 * Enunciado: Escribe un programa que se encargue de comprobar si un número es o no primo.
 * Hecho esto, imprime los números primos entre 1 y 100. *
 *
 * 
 *)

//https://www.garethrepton.com/FSharpPrimeCalculator/
//“A prime number that is divisible only by itself and 1.”

module Reto3

open Xunit

let isDivisible a b = a % b = 0
let matches f x = [1..x] |> Seq.filter(fun y -> f x y) 
let isPrime x = matches isDivisible x |> Seq.length = 2

let ImprimeLosPrimosEntreUnoYCien = 
    printfn "Reto 3 f# Es número primo"

    [1..100]
    |> List.filter isPrime
    |> List.map (fun i -> string i)
    |> String.concat " "
    |> printfn "%s"

    printfn "Reto 3 fin"


[<Fact>]
let ``Tests_es_primo_para_los_quince_primeros_numeros`` () =
    let casos =
        [
            (1, false);
            (2, true);
            (3, false);
            (4, false);
            (5, false);
            (6, false);
            (7, true);
            (8, false);
            (9, false);
            (10, false);
            (11, true);
            (12, false);
            (13, true);
            (14, false);
            (15, false);
        ]
        
    casos
    |> List.iter (fun (i, esperado) ->
        let actual = isPrime i
        Assert.Equal(esperado, actual)
    )
    
   

    

