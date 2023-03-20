/*
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
 * 
 */

using System.Numerics;

public class Reto2
{
    // no funciona ni con int ni con long
    public  static void EjecutaFibonacci()
    {
        Console.WriteLine("Reto 2 c# Fobonacci");

        var serie = Fibonacci(50).ToList();
        
        var serieString = string.Join(" ", serie);
        Console.Write(serieString);
        Console.WriteLine(" ");
        Console.WriteLine("Reto 2 fin");
    }


    private static IEnumerable<BigInteger> Fibonacci(int max)
    {
        BigInteger a = new(0), b = new(1); 
        
        yield return a;
        yield return b;
        
        for (var i = 2; i < max; i++)
        {
            var suma = a + b; 
            yield return suma;
            a = b;
            b = suma;
        }
    }
   

    [Fact]
    public void Test_fibonacci()
    {
       var casos = new List<BigInteger>
        {
            0,
            1,
            1,
            2,
            3,
            5,
            8,
            13,
            21,
            34,
            55,
            89,
            144,
            233
        };

       List<BigInteger> serie = Fibonacci(14).ToList();

       serie.Count.Should().Be(14);

       for (var i = 0; i < 14; i++)
       {
           casos[i].Should().Be(serie[i]);
       }

    }
}