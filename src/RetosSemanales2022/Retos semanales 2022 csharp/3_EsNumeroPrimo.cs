/*
* Reto #3
 * ¿ES UN NÚMERO PRIMO?
 * Fecha publicación enunciado: 17/01/22
 * Fecha publicación resolución: 24/01/22
 * Dificultad: MEDIA
 *
 * Enunciado: Escribe un programa que se encargue de comprobar si un número es o no primo.
 * Hecho esto, imprime los números primos entre 1 y 100. *
 *
 */

using System;

public class Reto3
{
    public  static void ImprimeLosPrimosEntreUnoYCien()
    {
        Console.WriteLine("Reto 3 c# EsNumeroPrimo");

        var numerosPrimosUtilizandoCache = string.Join(
            ", ",
            Enumerable.Range(1, 100).Where(EsPrimoCache)
        );


        var numerosPrimos = string.Join(
            ", ",
            Enumerable.Range(1, 100).Where(EsPrimo)
        );

        Console.WriteLine(numerosPrimos);
        Console.WriteLine("Utilizando caché:");
        Console.WriteLine(numerosPrimosUtilizandoCache);
        Console.WriteLine("Reto 3 fin");
    }

    public static Func<int, bool> EsPrimo =
        numero =>
        {
            if (numero < 2)
            {
                return false;
            }

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true;
        };

    // Utilizando caché
    public static Func<int, bool> EsPrimoCache =
        numero =>
            EsNumeroPrimoYCachea(numero, EsPrimo);

    private static Dictionary<int, bool> _cacheNumeros = new()
    {
        {1, false},
        {2, true},
        {3, true}
    };

    private static bool EsNumeroPrimoYCachea(int numero, Func<int, bool> funcionEsPrimo)
    {
        if (!_cacheNumeros.ContainsKey(numero))
        {
            var esPrimo = funcionEsPrimo(numero);
            _cacheNumeros.Add(numero, esPrimo);
        }

        return _cacheNumeros[numero];
    }

    // En estilo funcional (copiando de f#)
    public static Func<int, int, bool> EsDivisible = (a, b) => a % b == 0;
    public static Func<Func<int, int, bool>, int, IEnumerable<int>> Matches = (f, x) => 
                                                                        Enumerable.Range(1, x)
                                                                            .Where(y => f(x, y));

    public static Func<int, bool> EsPrimoFunc = x => Matches(EsDivisible, x).Count() == 2;

    //Test para el reto 3

    [Fact]
    public void Tests_es_primo_para_los_quince_primeros_numeros()
    {
        var casos =new List<(int, bool)> {
            (1, false),
            (2, true),
            (3, true),
            (4, false),
            (5, true),
            (6, false),
            (7, true),
            (8, false),
            (9, false),
            (10, false),
            (11, true),
            (12, false),
            (13, true),
            (14, false),
            (15, false)
        } ;

        casos.ForEach(caso =>
        {
            var (i, esperado) = caso;
            var actual = EsPrimoCache(i);
            actual.Should().Be(esperado);
        });
        
       
    }

    private static bool EsNumeroPrimoPrimeraVersion(int numero)
    {
        if (numero == 1) return false;
        if (numero == 2) return true;
        if (numero == 3) return true;

        for (int j = 2; j < numero; j++)
        {
            if (!EsNumeroPrimoPrimeraVersion(j))
                continue;

            if (numero % j == 0)
                return false;
        }

        return true;
    }

}