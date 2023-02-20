/*
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
 * *
 */

using System;

public class Reto1
{
    public  static void EjecutaAnagrama()
    {
        Console.WriteLine("Reto 1 c# Anagrama");

        new List<(string, string)>
        {
            ("amor", "roma"),
            ("amor", "amor"), // dos palabras iguales no son anagrama
            ("casa", "saca"),
            ("Casa", "saca"),
            ("casa", "caza"),
            ("casa", "sacá"), // podríamos programar para que no tuviera en cuneta los acentos
        }.ForEach(caso =>
        {
            var (palabra1, palabra2) = caso;
            var siONo = EsAnagrama(palabra1, palabra2) ? "Sí" : "No";
            Console.WriteLine($"¿Es '{palabra1}' un anagrama de '{palabra2}'? {siONo}");
        });

        Console.WriteLine("Reto 1 fin");
    }
    

    private static bool EsAnagrama(string palabra1, string palabra2)
    {
        if (string.Equals(palabra1, palabra2, 
                StringComparison.InvariantCultureIgnoreCase)) 
                    return false;

        return EnMinusculasYOrdenadaPorLetras(palabra1) == EnMinusculasYOrdenadaPorLetras(palabra2);
    }

    private static string EnMinusculasYOrdenadaPorLetras(string palabra) => 
        string.Concat(palabra.ToLower().OrderBy(letter => letter));

    //Test para el reto 1

    [Fact]
    public void Diferentes_tests_para_anagramas()
    {
        new List<(string, string, bool)>
        {
            ("amor", "roma", true),
            ("amor", "amor", false), // dos palabras iguales no son anagrama
            ("casa", "saca", true),
            ("casa", "caza", false),
            ("casa", "Casa", false),
            ("casa", "Saca", true),
            ("casa", "sacá", false), // podríamos programar para que no tuviera en cuneta los acentos
        }.ForEach(caso =>
        {
            var (palabra1, palabra2, esAnagramaEsperado) = caso;
            var esAnagrama = EsAnagrama(palabra1, palabra2);
            esAnagrama.Should().Be(esAnagramaEsperado);
        });
    }

 
}