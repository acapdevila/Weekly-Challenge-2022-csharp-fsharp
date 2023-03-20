(*
 * Reto #6
 * INVIRTIENDO CADENAS
 * Fecha publicación enunciado: 07/02/22
 * Fecha publicación resolución: 14/02/22
 * Dificultad: FÁCIL
 *
 * Enunciado: Crea un programa que invierta el orden de una cadena de texto sin usar funciones propias del lenguaje que lo hagan de forma automática.
 * - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
 *)

module Reto6

open Xunit

let invierteCadena (cadena:string) =
    let cadenaArr = Seq.toArray cadena

    let invertidaArr = Array.create cadenaArr.Length ' '

    for i in 0.. cadenaArr.Length - 1 do
        Array.set invertidaArr i cadenaArr[i]

    invertidaArr |> (fun c -> string c)


let MuestraHolaMundoInvertido = 
    printfn "Reto 6 f# InvirtiendoCadenas"
    
    let cadena = "Hola mundo";
    printfn $"Invierte cadena \"{cadena}\":"
    let cadenaInvertida = invierteCadena cadena
   
    printfn $"{cadenaInvertida}"
       
    printfn "Reto 6 fin"


[<Fact>]
let ``Relaciones de aspecto para varias medidas`` () =
    let casos =
        [
             ("Hola mundo","odnum aloH");
        ]
        
    casos
    |> List.iter (fun (cadena, esperado) ->
        let actual = invierteCadena cadena
        Assert.Equal(esperado, actual)
    )
    
   

    

