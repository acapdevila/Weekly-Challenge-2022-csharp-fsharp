/*
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
 */
#pragma warning disable CA1416
using System.Drawing;

public class Reto5
{
    public  static async Task MuestraRelacionAspectoImagen()
    {
        Console.WriteLine("Reto 5 c# RelacionAspectoImagen");
        
        var http = new HttpClient();
        var stream = await http.GetStreamAsync("https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png");
        using var img  = Image.FromStream(stream);

        var relacionAspecto = RelacionDeAspecto(img.Width, img.Height);
        
        Console.WriteLine(relacionAspecto);
        Console.WriteLine("Reto 5 fin");
    }

    /// <summary>
    /// Multiplicar la relación de aspecto decimal por un número entero que permita obtener dos valores enteros.
    /// En este caso, se puede multiplicar 1.33 por 3 para obtener un valor cercano a 4.
    /// 1.33 x 3 = 3.99
    ///
    /// Redondear los dos valores resultantes al entero más cercano.En este caso, se obtienen los valores 4 y 3.
    /// 
    /// Escribir la relación de aspecto como una proporción de los dos valores enteros separados por dos puntos.En este caso, la relación de aspecto sería 4:3.
    ///
    /// </summary>
    /// <param name="ancho"></param>
    /// <param name="alto"></param>
    /// <returns></returns>
    private static string RelacionDeAspecto(decimal ancho, decimal alto)
    {
       var ratio = ancho / alto;

       var i = 0;
       decimal decimas;
       decimal resultado;
       do
       {
           i++;
           resultado = ratio * i;
           decimas = resultado - decimal.Round(resultado);

       } while (0.1m < Math.Abs(decimas));

       return $"{decimal.Round(resultado)}:{i}";
        
    }

    //Test para el reto 0

    [Fact]
    public void Relaciones_de_aspecto_para_varias_medidas()
    {
        var casos =new List<(int, int, string)> {
            (1000,1000, "1:1"),
            (4000, 3000, "4:3"),
            (1920, 1080, "16:9"),
            (3000, 2000, "3:2"),
            (5000, 4000, "5:4")
        } ;

        casos.ForEach(caso =>
        {
            var (ancho, alto, esperado) = caso;
            var actual = RelacionDeAspecto(ancho, alto);
            actual.Should().Be(esperado);
        });
        
       
    }

#pragma warning restore CA1416


}