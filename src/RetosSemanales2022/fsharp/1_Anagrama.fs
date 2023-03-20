(*
 * Reto #1
 * ¿ES UN ANAGRAMA?
 * Fecha publicación enunciado: 03/01/22
 * Fecha publicación resolución: 10/01/22
 * Dificultad: MEDIA
 *
 * Enunciado: Escribe una función que reciba dos palabras (String) y retorne verdadero o falso (Boolean) según sean o no anagramas.
 * Un Anagrama consiste en formar una palabra reordenando TODAS las letras de otra palabra inicial.
 * NO hace falta comprobar que ambas palabras existan.
 * Dos palabras exactamente iguales no son anagrama.
 * 
 *)

module Reto1

open Xunit

let enMinusculasYOrdenada (palabra : string) = 
     let enMinusculas =  palabra.ToLowerInvariant().ToCharArray()
     let arrayOrdenado = Array.sort (enMinusculas) 
     arrayOrdenado |> (fun s -> System.String s)

let esAnagrama (palabra1 :string) (palabra2:string) =
    if palabra1.ToLowerInvariant() = palabra2.ToLowerInvariant() then 
        false
    else
        enMinusculasYOrdenada palabra1 = enMinusculasYOrdenada palabra2

let EjecutaAnagrama = 
    printfn "Reto 1 f# Anagrama"
    
    [
            ("amor", "roma");
            ("amor", "amor"); // dos palabras iguales no son anagrama
            ("casa", "saca");
            ("Casa", "saca");
            ("casa", "caza");
            ("casa", "sacá")
    ]
    |> List.map (fun (palabra1, palabra2) -> 
                    let siONo = if esAnagrama palabra1 palabra2 then "Sí" else "No"
                    $"¿Es {palabra1} un anagrama de {palabra2}? {siONo}"                    
    )
    |> String.concat "\n"
    |> printfn "%s"

    printfn "Reto 1 fin"


    
[<Fact>]
let ``Diferentes tests para anagramas`` () =
    let casos =
        [
            ("amor", "roma", true);
            ("amor", "amor", false); // dos palabras iguales no son anagrama
            ("casa", "saca", true);
            ("casa", "caza", false);
            ("casa", "Casa", false);
            ("casa", "Saca", true);
            ("casa", "sacá", false); // podríamos programar para que no tuviera en cuneta los acentos
        ]
        
    casos
    |> List.iter (fun (palabra1, palabra2, esperado) ->
        let actual = esAnagrama palabra1 palabra2
        Assert.Equal(esperado, actual)
    )
    
   

    

