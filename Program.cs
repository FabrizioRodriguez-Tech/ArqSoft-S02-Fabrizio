using System;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Usamos la clase concreta para acceder a la propiedad CategoriaSeleccionada
            PalabrasEnMemoria fuente = new PalabrasEnMemoria();
            bool jugarOtraVez = true;

            while (jugarOtraVez)
            {
                // 2. Creamos una UI temporal para pedir la categoría antes que el motor exista
                ConsolaUI uiInicial = new ConsolaUI(null);
                fuente.CategoriaSeleccionada = uiInicial.PedirCategoria();

                // 3. Ahora el motor se crea con la fuente ya configurada
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