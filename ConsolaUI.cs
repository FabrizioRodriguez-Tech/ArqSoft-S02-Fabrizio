using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }

        public string PedirCategoria()
        {
            Console.Clear();
            Console.WriteLine("=== SELECCIONA UNA CATEGORÍA ===");
            Console.WriteLine("1. Arquitectura");
            Console.WriteLine("2. POO");
            Console.WriteLine("3. .NET");
            Console.Write("\nOpción: ");
            return Console.ReadLine() ?? "1";
        }

        public void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();

            if (_motor.MostrarPista)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"PISTA: La palabra empieza con '{_motor.PalabraSecreta[0]}'");
                Console.ResetColor();
            }

            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");

            Console.Write("Palabra: ");
            foreach (char c in _motor.PalabraSecreta)
            {
                Console.Write(_motor.LetrasUsadas.Contains(c) ? $"{c} " : "_ ");
            }
            Console.WriteLine();
        }

        public char PedirLetra()
        {
            Console.Write("\nIngresa una letra: ");
            string entrada = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            return entrada.Length > 0 ? entrada[0] : '\0';
        }

        public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);

        public bool PreguntarOtraVez()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            string respuesta = Console.ReadLine()?.Trim().ToLower() ?? "n";
            return respuesta == "s";
        }

        private void MostrarAhorcado()
        {
            string[] etapas = {
                " -----\n |   |\n |   \n |   \n |   \n |   \n=========",
                " -----\n |   |\n |   O\n |   \n |   \n |   \n=========",
                " -----\n |   |\n |   O\n |   |\n |   \n |   \n=========",
                " -----\n |   |\n |   O\n |  /|\n |   \n |   \n=========",
                " -----\n |   |\n |   O\n |  /|\\\n |   \n |   \n=========",
                " -----\n |   |\n |   O\n |  /|\\\n |  /  \n |   \n=========",
                " -----\n |   |\n |   O\n |  /|\\\n |  / \\\n |   \n========="
            };
            int intentos = _motor.IntentosRestantes;
            int indice = Math.Clamp(6 - intentos, 0, 6);
            Console.WriteLine(etapas[indice]);
        }
    }
}