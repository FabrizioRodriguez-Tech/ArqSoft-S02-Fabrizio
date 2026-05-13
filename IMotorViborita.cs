using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class MotorViborita : IMotorJuego
    {
        // --- Tamaño del tablero ---
        public int Ancho { get; } = 20;
        public int Alto { get; } = 15;

        // --- Estado del juego ---
        private readonly LinkedList<(int x, int y)> _cuerpo = new();
        private (int x, int y) _direccion = (1, 0); // Empieza moviéndose a la derecha
        private (int x, int y) _comida;
        private bool _perdido = false;

        // --- Propiedades ---
        public int Puntos { get; private set; } = 0;
        public IEnumerable<(int x, int y)> Cuerpo => _cuerpo;
        public (int x, int y) Comida => _comida;

        // --- Constructor ---
        public MotorViborita()
        {
            // Víbora inicial en el centro con 3 segmentos
            _cuerpo.AddFirst((Ancho / 2, Alto / 2));
            _cuerpo.AddFirst((Ancho / 2 + 1, Alto / 2));
            _cuerpo.AddFirst((Ancho / 2 + 2, Alto / 2));

            GenerarComida();
        }

        // --- Métodos Públicos ---
        public void CambiarDireccion(ConsoleKey tecla)
        {
            _direccion = tecla switch
            {
                ConsoleKey.UpArrow when _direccion.y != 1 => (0, -1),
                ConsoleKey.DownArrow when _direccion.y != -1 => (0, 1),
                ConsoleKey.LeftArrow when _direccion.x != 1 => (-1, 0),
                ConsoleKey.RightArrow when _direccion.x != -1 => (1, 0),
                _ => _direccion
            };
        }

        public void Avanzar()
        {
            if (_perdido) return;

            var cabeza = _cuerpo.First!.Value;
            var nuevaPosicion = (x: cabeza.x + _direccion.x,
                                 y: cabeza.y + _direccion.y);

            // 1. Colisión con paredes
            if (nuevaPosicion.x < 0 || nuevaPosicion.x >= Ancho ||
                nuevaPosicion.y < 0 || nuevaPosicion.y >= Alto)
            {
                _perdido = true;
                return;
            }

            // 2. Colisión con sí misma
            if (_cuerpo.Contains(nuevaPosicion))
            {
                _perdido = true;
                return;
            }

            // 3. Mover la cabeza
            _cuerpo.AddFirst(nuevaPosicion);

            // 4. Lógica de alimentación
            if (nuevaPosicion == _comida)
            {
                Puntos++;
                GenerarComida();
                // Al no remover el último, la víbora crece
            }
            else
            {
                _cuerpo.RemoveLast(); // Movimiento normal
            }
        }

        public bool Ganado() => Puntos >= 10;

        public bool Perdido() => _perdido;

        // --- Métodos Privados ---
        private void GenerarComida()
        {
            Random random = new Random();
            do
            {
                _comida = (random.Next(Ancho), random.Next(Alto));
            }
            while (_cuerpo.Contains(_comida));
        }
    }
}