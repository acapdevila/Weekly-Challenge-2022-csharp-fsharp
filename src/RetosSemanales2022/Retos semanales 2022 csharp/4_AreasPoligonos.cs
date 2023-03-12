/*
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
 *
 *
 */

using System;
using static Reto4;

public class Reto4
{
    public  static void ImprimeAreasDePoligonos()
    {
        Console.WriteLine("Reto 4 c# área polígonos");

       var triangulo = new Triangulo(5, 4);
       triangulo.ImprimeArea();

        var cuadrado = new Cuadrado(4);
        cuadrado.ImprimeArea();

        var rectangulo = new Rectangulo(5, 4);
        rectangulo.ImprimeArea();
        
        Console.WriteLine("Reto 4 fin");
    }

    public interface IPoligono
    {
        decimal Area();
        void ImprimeArea();
    }

    public class Triangulo : IPoligono
    {
        public Triangulo(decimal @base, decimal altura)
        {
            Base = @base;
            Altura = altura;
        }

        public decimal Base { get; }
        public decimal Altura { get; }

        public decimal Area() => Base * Altura / 2;
        public void ImprimeArea()
        {
            Console.WriteLine($"Área triángulo (Base: {Base}, Altura {Altura}): {Area()}");
        }
    }

    public class Rectangulo : IPoligono
    {
        public Rectangulo(decimal ancho, decimal largo)
        {
            Ancho = ancho;
            Largo = largo;
        }

        public decimal Ancho { get; }
        public decimal Largo { get; }

        public decimal Area() => Ancho * Largo;
        public void ImprimeArea()
        {
            Console.WriteLine($"Área rectángulo (Ancho: {Ancho}, Largo {Largo}): {Area()}");
        }
    }


    public class Cuadrado : IPoligono
    {
        public Cuadrado(decimal lado)
        {
            Lado = lado;
        }

        public decimal Lado { get; }

        public decimal Area() => Lado * Lado;
        public void ImprimeArea()
        {
            Console.WriteLine($"Área cuadrado (Lado: {Lado}): {Area()}");
        }
    }

}

