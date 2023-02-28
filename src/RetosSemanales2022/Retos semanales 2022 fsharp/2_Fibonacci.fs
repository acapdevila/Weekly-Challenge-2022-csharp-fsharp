(*
 * Reto #2
 * LA SUCESIÓN DE FIBONACCI
 * Fecha publicación enunciado: 10/01/22
 * Fecha publicación resolución: 17/01/22
 * Dificultad: DIFÍCIL
 *
 * Enunciado: Escribe un programa que imprima los 50 primeros números de la sucesión de Fibonacci empezando en 0.
 * La serie Fibonacci se compone por una sucesión de números en la que el siguiente siempre es la suma de los dos anteriores.
 * 0, 1, 1, 2, 3, 5, 8, 13...
 *
 *)

module Reto2

open Xunit

// iterativo y mutable. No funciona ni con int ni con long
let fibonacci n = 
    let mutable a = bigint 0
    let mutable b = bigint 1
    let total = n - 1 
    seq {
        bigint 0
        bigint 1
        for i in 2 .. total do
            let suma = a + b
            a <- b
            b <- suma
            suma
        }

// funcional
let fib max =
        (bigint 0,bigint 1, 0) // Initial state (0, 1) indice 0
            |> Seq.unfold (fun (fst, snd, index) ->
                if(index = 0) then
                    Some(bigint 0, (fst, snd, index + 1))
                else if(index = 1) then
                    Some(bigint 1, (fst, snd, index + 1))
                else if (max - 1 < index ) then
                    None
                else
                    Some (fst + snd, (snd, fst + snd, index + 1))                        )

let EjecutaFibonacci = 
    printfn "Reto 2 f# Fibonacci"
    
    printfn "\nSerie fibonacci iterativa y mutable."
    for x in fibonacci 50 do printf $"{string x} "
         
    printfn "\nSerie fibonacci funcional."
    for x in fib 50 do printf $"{string x} "
        
    printfn "\nReto 2 fin"


    //falta realizar los test
[<Fact>]
let ``Tests fibonacci`` () =
    let casos =
        [
            0;
            1;
            1;
            2;
            3;
            5;
            8;
            13;
            21;
            34;
            55;
            89;
            144;
            233
        ]
        
    let serie = fibonacci 14 |> List.ofSeq
    let total = serie |> Seq.length     
    Assert.Equal(total, 14)
    for i in 2 .. (total - 1) do Assert.Equal(serie.[i], casos.[i])
    
    let serie = fib 14 |> List.ofSeq
    let total = serie |> Seq.length     
    Assert.Equal(total, 14)
    for i in 2 .. (total - 1) do Assert.Equal(serie.[i], casos.[i])
  
   

    

