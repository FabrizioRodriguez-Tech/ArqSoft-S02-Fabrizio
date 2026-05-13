using System;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabra
    {
        public string ObtenerPalabraAleatoria()
        {
            string[] palabras = { "arquitectura", "interfaz", "polimorfismo", "encapsulamiento", "herencia" };
            Random random = new Random();
            return palabras[random.Next(palabras.Length)];
        }
    }
}