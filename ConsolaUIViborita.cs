using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            // Reposiciona el cursor al inicio para evitar que la pantalla parpadee al limpiar
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"=== VIBORITA ===   Puntos: {_motor.Puntos}");

            // Borde superior
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.Write("|"); // Borde izquierdo

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    // Lógica de dibujo priorizada
                    if (_motor.Cuerpo.First() == pos)
                    {
                        Console.Write("@"); // Cabeza
                    }
                    else if (_motor.Cuerpo.Contains(pos))
                    {
                        Console.Write("o"); // Cuerpo
                    }
                    else if (_motor.Comida == pos)
                    {
                        Console.Write("*"); // Comida
                    }
                    else
                    {
                        Console.Write(" "); // Espacio vacío
                    }
                }

                Console.WriteLine("|"); // Borde derecho
            }

            // Borde inferior
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.WriteLine("Flechas: mover   |   Q: salir");
        }

        public ConsoleKey LeerTecla()
        {
            // Lee la tecla solo si hay una disponible para no bloquear el juego
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;

            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);
    }
}