using System;
using System.Threading;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuarEnApp = true;

            while (continuarEnApp)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL GNOSIS ===");
                Console.WriteLine("¿Qué juego quieres jugar?");
                Console.WriteLine("  1 — Ahorcado");
                Console.WriteLine("  2 — Viborita");
                Console.WriteLine("  3 — Salir");
                Console.Write("\nOpción: ");
                var opcion = Console.ReadLine();

                if (opcion == "2")
                {
                    EjecutarViborita();
                }
                else if (opcion == "1")
                {
                    EjecutarAhorcado();
                }
                else if (opcion == "3")
                {
                    continuarEnApp = false;
                }
            }
        }

        static void EjecutarViborita()
        {
            var motor = new MotorViborita();
            var ui = new ConsolaUIViborita(motor);

            Console.CursorVisible = false;

            while (!motor.Ganado() && !motor.Perdido())
            {
                ui.MostrarTablero();
                var tecla = ui.LeerTecla();

                if (tecla == ConsoleKey.Q) break;

                if (tecla != ConsoleKey.NoName)
                    motor.CambiarDireccion(tecla);

                motor.Avanzar();
                Thread.Sleep(150); // Velocidad del juego
            }

            ui.MostrarTablero();
            ui.MostrarMensaje(motor.Ganado()
                ? "\n¡Ganaste! Llegaste a 10 puntos."
                : "\nGame over.");

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        static void EjecutarAhorcado()
        {
            PalabrasEnMemoria fuente = new PalabrasEnMemoria();
            bool jugarOtraVez = true;

            while (jugarOtraVez)
            {
                // UI temporal para pedir categoría (motor es null al inicio)
                ConsolaUI uiInicial = new ConsolaUI(null);
                fuente.CategoriaSeleccionada = uiInicial.PedirCategoria();

                MotorAhorcado motor = new MotorAhorcado(fuente);
                ConsolaUI ui = new ConsolaUI(motor);

                while (!motor.Ganado() && !motor.Perdido())
                {
                    ui.MostrarTablero();
                    char letra = ui.PedirLetra();

                    if (motor.LetraYaUsada(letra))
                    {
                        ui.MostrarMensaje("Ya usaste esa letra. Presiona Enter...");
                        Console.ReadLine();
                        continue;
                    }

                    motor.RegistrarLetra(letra);
                }

                ui.MostrarTablero();

                if (motor.Ganado())
                    ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
                else
                    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

                jugarOtraVez = ui.PreguntarOtraVez();
            }
        }
    }
}