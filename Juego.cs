using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "arquitectura", "interfaz", "polimorfismo", "encapsulamiento", "herencia"
        };

        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)].ToLower();
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            while (_intentosRestantes > 0)
            {
                MostrarTablero();

                if (VerificarVictoria())
                {
                    Console.WriteLine($"\n¡Ganaste! La palabra era: {_palabraSecreta}");
                    Reiniciar();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                string entrada = Console.ReadLine()?.ToLower();

                // Validación de entrada vacía
                if (string.IsNullOrEmpty(entrada)) continue;

                char letra = entrada[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya usaste esa letra. Presiona Enter para continuar...");
                    Console.ReadLine();
                    continue;
                }

                _letrasUsadas.Add(letra);

                if (!_palabraSecreta.Contains(letra))
                {
                    _intentosRestantes--;
                }
            }

            // Si sale del bucle es porque perdió
            MostrarTablero();
            Console.WriteLine($"\nPerdiste. La palabra era: {_palabraSecreta}");
            Reiniciar();
        }

        private bool VerificarVictoria()
        {
            // Más limpio usando LINQ
            return _palabraSecreta.All(c => _letrasUsadas.Contains(c));
        }

        private void Reiniciar()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                new Juego().Jugar();
            }
        }

        private void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            Console.Write("Palabra: ");

            foreach (char c in _palabraSecreta)
            {
                Console.Write(_letrasUsadas.Contains(c) ? $"{c} " : "_ ");
            }
            Console.WriteLine();
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                " -----\n |   |\n |   \n |   \n |   \n |   \n=========", // 6 intentos
                " -----\n |   |\n |   O\n |   \n |   \n |   \n=========", // 5
                " -----\n |   |\n |   O\n |   |\n |   \n |   \n=========", // 4
                " -----\n |   |\n |   O\n |  /|\n |   \n |   \n=========", // 3
                " -----\n |   |\n |   O\n |  /|\\\n |   \n |   \n=========", // 2
                " -----\n |   |\n |   O\n |  /|\\\n |  /  \n |   \n=========", // 1
                " -----\n |   |\n |   O\n |  /|\\\n |  / \\\n |   \n========="  // 0
            };

            int indice = 6 - _intentosRestantes;
            Console.WriteLine(etapas[indice]);
        }
    }
}