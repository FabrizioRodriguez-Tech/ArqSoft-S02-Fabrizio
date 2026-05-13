using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabra
    {
        // Propiedad para guardar la categoría seleccionada por el usuario
        public string CategoriaSeleccionada { get; set; } = "1";

        public string ObtenerPalabraAleatoria()
        {
            var categorias = new Dictionary<string, string[]>
            {
                { "1", new[] { "arquitectura", "componente", "descomposición", "dependencia", "acoplamiento" } }, // Arquitectura
                { "2", new[] { "polimorfismo", "encapsulamiento", "herencia", "clase", "abstraccion" } }, // POO
                { "3", new[] { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }         // .NET
            };

            // Usamos la categoría guardada previamente
            string[] palabras = categorias.ContainsKey(CategoriaSeleccionada)
                ? categorias[CategoriaSeleccionada]
                : categorias["1"];

            Random random = new Random();
            return palabras[random.Next(palabras.Length)];
        }
    }
}