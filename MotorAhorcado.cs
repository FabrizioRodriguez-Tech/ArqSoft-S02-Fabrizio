using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class MotorAhorcado
    {
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;
        private readonly IRepositorioPalabra _repositorio;

        public string PalabraSecreta => _palabraSecreta;
        public int IntentosRestantes => _intentosRestantes;
        public List<char> LetrasUsadas => _letrasUsadas;
        public bool MostrarPista => _intentosRestantes <= 3;

        public MotorAhorcado(IRepositorioPalabra repositorio)
        {
            _repositorio = repositorio;
            // Corregido para usar el nombre exacto de la interfaz
            _palabraSecreta = _repositorio.ObtenerPalabraAleatoria().ToLower();
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public bool Ganado() => _palabraSecreta.All(c => _letrasUsadas.Contains(c));
        public bool Perdido() => _intentosRestantes <= 0;
        public bool LetraYaUsada(char letra) => _letrasUsadas.Contains(letra);

        public void RegistrarLetra(char letra)
        {
            if (letra == '\0' || LetraYaUsada(letra)) return;

            _letrasUsadas.Add(letra);

            if (!_palabraSecreta.Contains(letra))
            {
                _intentosRestantes--;
            }
        }
    }
}