using System;
using System.Collections.Generic;

namespace Ahorcado
{
    internal class PalabrasEnMemoria : IRepositorioPalabra
    {
        private readonly List<string> _palabras = new()
        {
            "arquitectura",
            "interfaz",
            "polimorfismo",
            "encapsulamiento",
            "herencia"
        };

        public string ObtenerPalabraAleatoria()
        {
            Random random = new Random();
            return _palabras[random.Next(_palabras.Count)];
        }
    }
}