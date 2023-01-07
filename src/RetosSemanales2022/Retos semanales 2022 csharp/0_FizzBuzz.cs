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
    
    [Fact]
    public void FizzBuzz_devuelve_resultados_correctos_para_15_primeros_inputs()
    {
        var casos =new List<(int, string)> {
            (1, "1"),
            (2, "2"),
            (3, "fizz"),
            (4, "4"),
            (5, "buzz"),
            (6, "fizz"),
            (7, "7"),
            (8, "8"),
            (9, "fizz"),
            (10, "buzz"),
            (11, "11"),
            (12, "fizz"),
            (13, "13"),
            (14, "14"),
            (15, "fizzbuzz")
        } ;

        casos.ForEach(caso =>
        {
            var (i, esperado) = caso;
            var actual = GetFizzBuzzString(i);
            actual.Should().Be(esperado);
        });
        
       
    }


 
}