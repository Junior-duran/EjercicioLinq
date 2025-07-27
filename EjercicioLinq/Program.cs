using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioLinq
{
    public class Cervezas
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double PorcentajeAlcohol { get; set; }
        public string Marca { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cervezas> Cervezas = new List<Cervezas>
            {
                new Cervezas { Nombre = "Corona", Marca = "Grupo Modelo", PorcentajeAlcohol = 4.6 },
                new Cervezas { Nombre = "Heineken", Marca = "Heineken", PorcentajeAlcohol = 5.0 },
                new Cervezas { Nombre = "Guinness", Marca = "Diageo", PorcentajeAlcohol = 6.0 },
                new Cervezas { Nombre = "Budweiser", Marca = "AB InBev", PorcentajeAlcohol = 5.0 },
                new Cervezas { Nombre = "Delirium Tremens", Marca = "Huyghe", PorcentajeAlcohol = 8.5 },
                new Cervezas { Nombre = "Punk IPA", Marca = "BrewDog", PorcentajeAlcohol = 5.6 },
                new Cervezas { Nombre = "precidente",Marca = "johansell", PorcentajeAlcohol = 10.0}
            };

            //1. Obtener todas las cervezas con un porcentaje de alcohol superior al 5%
           Console.WriteLine("Cervezas con porcentaje de alcohol superior al 5%:");
            var cervezasConAltoAlcohol = Cervezas.Where(c => c.PorcentajeAlcohol > 5).ToList();
            foreach (var cerveza in cervezasConAltoAlcohol)
            {
                Console.WriteLine($"{cerveza.Nombre} - {cerveza.PorcentajeAlcohol}%");
            }
            //2. Obtener todas las cervezas de la marca "Grupo Modelo"
            Console.WriteLine("\nCervezas de la marca 'Grupo Modelo':");
            var cervezasGrupoModelo = Cervezas.Where(c => c.Marca == "Grupo Modelo").ToList();
            foreach (var cerveza in cervezasGrupoModelo)
            {
                Console.WriteLine($"{cerveza.Nombre} - {cerveza.Marca}");

            }
            // consultar LinQ
            var top3Consulta = (from c in Cervezas
                                orderby c.PorcentajeAlcohol descending
                                select new { c.Nombre, c.PorcentajeAlcohol }).Take(3);

            Console.WriteLine("\nTop 3 cervezas más fuertes (consulta):");
            foreach (var c in top3Consulta)
                Console.WriteLine($"{c.Nombre} - {c.PorcentajeAlcohol}%");


     
            //3. Obtener el nombre de todas las cervezas ordenadas alfabéticamente
            Console.WriteLine("\nNombres de todas las cervezas ordenadas alfabéticamente:");
            var nombresCervezasOrdenados = Cervezas.Select(c => c.Nombre).OrderBy(n => n).ToList();
            foreach (var nombre in nombresCervezasOrdenados)
            {
                Console.WriteLine(nombre);
            }
            //4. Obtener el porcentaje de alcohol promedio de todas las cervezas
            double promedioAlcohol = Cervezas.Average(c => c.PorcentajeAlcohol);
            Console.WriteLine($"\nPorcentaje de alcohol promedio: {promedioAlcohol}%");
            //5. Obtener la cerveza con el mayor porcentaje de alcohol
            var cervezaMasFuerte = Cervezas.OrderByDescending(c => c.PorcentajeAlcohol).FirstOrDefault();
            if (cervezaMasFuerte != null)
            {
                Console.WriteLine($"\nCerveza con mayor porcentaje de alcohol: {cervezaMasFuerte.Nombre} - {cervezaMasFuerte.PorcentajeAlcohol}%");
            }
            
            bool existeConsulta = (from c in Cervezas
                                   where c.PorcentajeAlcohol > 8.0
                                   select c).Any();

            Console.WriteLine("\n¿Hay alguna cerveza con más de 8%? (consulta): " + (existeConsulta ? "Sí" : "No"));
            Console.ReadLine();
        }
    }
}
    
 