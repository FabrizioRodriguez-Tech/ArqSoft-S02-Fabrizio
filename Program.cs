using System;
using Ahorcado;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepositorioPalabra repositorio = new PalabrasEnMemoria();

            bool jugarOtraVez = true;

            while (jugarOtraVez)
            {
                MotorAhorcado motor = new MotorAhorcado(repositorio);
                ConsolaUI ui = new ConsolaUI(motor);

                Console.WriteLine("=== AHORCADO ===");

                while (!motor.Ganado() && !motor.Perdido())
                {
                    ui.MostrarTablero();

                    char letra = ui.PedirLetra();

                    if (motor.LetraYaUsada(letra))
                    {
                        ui.MostrarMensaje("Ya usaste esa letra.");
                        Console.ReadLine();
                        continue;
                    }

                    motor.RegistrarLetra(letra);
                }

                ui.MostrarTablero();

                if (motor.Ganado())
                {
                    ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
                }
                else
                {
                    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
                }

                jugarOtraVez = ui.PreguntarOtraVez();
            }
        }
    }
}