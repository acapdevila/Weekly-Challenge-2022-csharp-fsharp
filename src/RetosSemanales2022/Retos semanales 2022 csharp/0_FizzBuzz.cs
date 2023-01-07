/*
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
 * Información adicional:
 * - Usa el canal de nuestro discord (https://mouredev.com/discord) "🔁reto-semanal" para preguntas, dudas o prestar ayuda a la acomunidad.
 * - Puedes hacer un Fork del repo y una Pull Request al repo original para que veamos tu solución aportada.
 * - Revisaré el ejercicio en directo desde Twitch el lunes siguiente al de su publicación.
 * - Subiré una posible solución al ejercicio el lunes siguiente al de su publicación.
 *
 */

public class Reto0
{
    public  static void FizzBuzz()
    {
        Console.WriteLine("Reto 0 c# FizzBuzz");

        var numeros = string.Join(
            Environment.NewLine,
            Enumerable.Range(1, 100).Select(GetFizzBuzzString)
        );

        Console.WriteLine(numeros);
        Console.WriteLine("Reto 0 fin");
    }

    private static string GetFizzBuzzString(int i)
    {
        return (i % 3 == 0, i % 5 == 0) switch
        {
            (true, true) => "fizzbuzz",
            (true, _) => "fizz",
            (_, true) => "buzz",
            _ => i.ToString()
        };
    }

    //Test para el reto 0
    
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "buzz")]
    [InlineData(6, "fizz")]
    [InlineData(7, "7")]
    [InlineData(8, "8")]
    [InlineData(9, "fizz")]
    [InlineData(10, "buzz")]
    [InlineData(11, "11")]
    [InlineData(12, "fizz")]
    [InlineData(13, "13")]
    [InlineData(14, "14")]
    [InlineData(15, "fizzbuzz")]
    public void FizzBuzz_devuelve_resultados_correctos_para_15_primeros_inputs(int i, string esperado)
    {
        var actual = GetFizzBuzzString(i);
        actual.Should().Be(esperado);
    }


 
}