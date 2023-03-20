(*
 * Reto #4
 * ÁREA DE UN POLÍGONO
 * Fecha publicación enunciado: 24/01/22
 * Fecha publicación resolución: 31/01/22
 * Dificultad: FÁCIL
 *
 * Enunciado: Crea UNA ÚNICA FUNCIÓN (importante que sólo sea una) que sea capaz de calcular y retornar el área de un polígono.
 * - La función recibirá por parámetro sólo UN polígono a la vez.
 * - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
 * - Imprime el cálculo del área de un polígono de cada tipo.
 * * 
 *)

//https://www.garethrepton.com/FSharpPrimeCalculator/
//“A prime number that is divisible only by itself and 1.”

module Reto4

type Rectangulo =  {ancho: decimal ; largo : decimal }
type Cuadrado =  {lado: decimal }
type Triangulo =  {baseTri: decimal ; altura : decimal }

type Poligono =
    | Rectangulo of Rectangulo
    | Cuadrado of Cuadrado
    | Triangulo of Triangulo


let areaPoligono poligono = 
   match poligono with
    | Triangulo t -> t.baseTri * t.altura / 2m
    | Cuadrado c -> c.lado * c.lado
    | Rectangulo r -> r.ancho * r.largo

let imprime areaPoligono poligono = 
    let area = areaPoligono poligono
    match poligono with
       | Triangulo t -> printf $"Área triangulo (Base {t.baseTri}, Altura {t.altura}): {area}"
       | Cuadrado c -> printf $"Área cuarado (Lado {c.lado}): {area}"
       | Rectangulo r -> printf $"Área rectángulo (ancho {r.ancho}, Largo {r.largo}): {area}"

let ImprimeAreasDePoligonos = 
    printfn "Reto 4 f# áreas de polígonos"
    
    let poligonos = [ 
                      Triangulo { baseTri = 5.0m; altura = 3.0m };
                      Cuadrado { lado = 4.0m };
                      Rectangulo { ancho = 6.0m; largo = 8.0m }
                    ]

    poligonos |> List.iter (imprime areaPoligono)
    
    printfn "Reto 4 fin"


    
   

    

