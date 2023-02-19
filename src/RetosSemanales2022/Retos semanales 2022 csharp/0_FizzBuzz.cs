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
 */

using System;

public class Reto0
{
    public  static void MuestraResultadosFizzBuzz()
    {
        Console.WriteLine("Reto 0 c# FizzBuzz");

        var numeros = string.Join(
            Environment.NewLine,
            Enumerable.Range(1, 100).Select(FizzBuzzONumero)
        );

        Console.WriteLine(numeros);
        Console.WriteLine("Reto 0 fin");
    }

    private static string FizzBuzzONumero(int i)
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
            var actual = FizzBuzzONumero(i);
            actual.Should().Be(esperado);
        });
        
       
    }


    /// <summary>
    /// Primera versión del método.
    /// Hay 100 llamadas a Console.WriteLine
    /// No es posible realizar pruebas unitarias sobre él. => pq el método está acoplado a la Consola
    /// </summary>
    private static void PrimeraVersionDelReto()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Primera versión del método.
    /// No es posible realizar pruebas unitarias sobre él. => pq el método está acoplado a la Consola
    /// </summary>
    private static void SegundaVersionDelReto()
    {
        Enumerable.Range(1, 100)
            .Select(i =>
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    return "fizzbuzz";
                }
                if (i % 3 == 0)
                {
                    return "fizz";
                }
                if (i % 5 == 0)
                {
                    return "buzz";
                }
                return i.ToString();
            })
            .ToList()
            .ForEach(Console.WriteLine);
    }

    /// <summary>
    /// La versión que más idiomática con c# suponiendo que se domina LINQ
    /// </summary>
    private static void TerceraVersionDelReto()
    {
        // función local
        string FizzBuzzONumeroLocal(int i)
        {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    return "fizzbuzz";
                }

                if (i % 3 == 0)
                {
                    return "fizz";
                }

                if (i % 5 == 0)
                {
                    return "buzz";
                }

                return i.ToString();
        }

        Enumerable.Range(1, 100)
            .Select(FizzBuzzONumeroLocal)
            .ToList()
            .ForEach(Console.WriteLine);
    }


}