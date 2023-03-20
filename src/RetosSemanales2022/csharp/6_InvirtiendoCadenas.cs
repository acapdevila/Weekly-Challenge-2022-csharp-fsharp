/*
 * Reto #6
 * INVIRTIENDO CADENAS
 * Fecha publicación enunciado: 07/02/22
 * Fecha publicación resolución: 14/02/22
 * Dificultad: FÁCIL
 *
 * Enunciado: Crea un programa que invierta el orden de una cadena de texto sin usar funciones propias del lenguaje que lo hagan de forma automática.
 * - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
 */

public class Reto6
{
    public static void MuestraHolaMundoInvertido()
    {
        Console.WriteLine("Reto 6 c# Invirtiendo cadenas");
        var cadena = "Hola mundo";
        Console.WriteLine($"Invierte cadena \"{cadena}\":");
        var cadenaInvertida = InvierteCadena(cadena);
        Console.WriteLine(cadenaInvertida);
        Console.WriteLine("Reto 6 fin");
    }
    
    private static string InvierteCadena(string cadena)
    {
        var cadenaArr = cadena.ToCharArray();

        var invertidaArr = new char[cadenaArr.Length];

        for (int i = 0; i < cadena.Length; i++)
        {
            invertidaArr[i] = cadenaArr[cadena.Length - 1 - i];
        }

        return string.Join(string.Empty, invertidaArr);

    }

    [Fact]
    public void Test_de_inversion_de_cadena()
    {
        var casos = new List<(string, string)> {
            ("Hola mundo","odnum aloH")
        };

        casos.ForEach(caso =>
        {
            var (cadena, esperado) = caso;
            var actual = InvierteCadena(cadena);
            actual.Should().Be(esperado);
        });


    }
    


}