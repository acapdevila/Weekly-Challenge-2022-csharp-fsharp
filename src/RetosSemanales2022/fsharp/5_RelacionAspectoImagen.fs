(*
* Reto #5
 * ASPECT RATIO DE UNA IMAGEN
 * Fecha publicación enunciado: 01/02/22
 * Fecha publicación resolución: 07/02/22
 * Dificultad: DIFÍCIL
 *
 * Enunciado: Crea un programa que se encargue de calcular el aspect ratio de una imagen a partir de una url.
 * - Nota: Esta prueba no se puede resolver con el playground online de Kotlin. Se necesita Android Studio.
 * - Url de ejemplo: https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png
 * - Por ratio hacemos referencia por ejemplo a los "16:9" de una imagen de 1920*1080px.
 * 
 *)

module Reto5

open Xunit
open System
open System.Net.Http
open System.Drawing


let relacionAspectoImagen (ancho:int) (alto:int) =
    let ratio = float ancho / float alto    
    let ratioPorEntero entero = ratio * float entero

    let esEntero (numero : float) = 
            let delta = (numero) - Math.Round(numero)
            Math.Abs(delta) < 0.1

    let cumpleRatio i = ratioPorEntero i |> esEntero
            
    let alto = [1..100] |> Seq.find cumpleRatio 

    let ancho = ratioPorEntero alto |> Math.Round |> int
    
    $"{ancho}:{alto}"


let relacionAspectoImagenPrimeraVersion (ancho:int) (alto:int) =
    let ratio = float ancho / float alto    
    let rec calcularRatio i =
        let resultado = ratio * float i
        let decimas = resultado - Math.Round(resultado)
        if (0.1 < Math.Abs(decimas)) then
            calcularRatio (i + 1)
        else
            $"{(int (Math.Round resultado))}:{i}"
    calcularRatio 1
    
let descargarImagen (url: string) =
    async {
        use http = new HttpClient()
        let! stream = http.GetStreamAsync url |> Async.AwaitTask
        let img = Image.FromStream(stream)
        return img
    }

let MuestraRelacionAspectoImagen = 
    printfn "Reto 5 f# RelacionAspectoImagen"
    
    let img = descargarImagen "https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png" |> Async.RunSynchronously;
    let aspectoRatio = relacionAspectoImagen img.Width img.Height
    printfn $"{aspectoRatio}" 
    printfn "Reto 5 fin"


[<Fact>]
let ``Relaciones de aspecto para varias medidas`` () =
    let casos =
        [
            (1000, 1000, "1:1");
            (4000, 3000, "4:3");
            (1920, 1080, "16:9");
            (3000, 2000, "3:2");
            (5000, 4000, "5:4")
        ]
        
    casos
    |> List.iter (fun (ancho, alto, esperado) ->
        let actual = relacionAspectoImagen ancho alto
        Assert.Equal(esperado, actual)
    )
    
   

    

