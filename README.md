# ArqSoft-S02-Fabrizio

## Análisis de principios SOLID

| Situación | Principio SOLID violado | Explicación |
|---|---|---|
| `Juego` controla turnos, tablero, mensajes y palabras | **SRP (Single Responsibility Principle)** | La clase tiene demasiadas responsabilidades en una sola clase. |
| Las palabras están hardcodeadas en el constructor | **DIP (Dependency Inversion Principle)** | `Juego` depende directamente de una lista concreta de palabras en lugar de una abstracción. |
| Para agregar otro juego habría que modificar `Juego` | **OCP (Open/Closed Principle)** | La clase no está preparada para extender funcionalidades sin modificar el código existente. |

## Juego del Ahorcado (C# Console Application)
Esta aplicación es un sistema de gestión y ejecución del juego del "Ahorcado" desarrollado en C#, con un fuerte enfoque en la arquitectura de software, la inversión de dependencias y la escalabilidad de datos.

Descripción Técnica
El proyecto implementa una separación clara entre la lógica de control del juego y el almacenamiento de datos, permitiendo que el sistema sea robusto frente a cambios en la fuente de información de las palabras. Se han aplicado principios de Clean Code para asegurar que cada clase tenga una responsabilidad única.

Características Implementadas
   *  Desacoplamiento de Datos: Uso de interfaces para la inyección de repositorios de palabras.

   *  Experiencia de Usuario: Sistema inteligente de validación de entradas y lógica de pistas automática.

   *  Modularidad Temática: Capacidad de inyectar diferentes categorías de palabras desde el punto de entrada de la aplicación.

Historial de Commits
1.  **`feat: initial commit - estructura base`**
    *   Configuración del entorno en .NET y creación del esqueleto de clases principal.
2.  **`feat: lógica de MotorAhorcado y renderizado UI`**
    *   Desarrollo de los algoritmos de validación de letras y dibujo del ahorcado en consola.
3.  **`refactor: inversión de dependencias con IRepositorioPalabra`**
    *   Implementación de la interfaz de repositorio para desacoplar la lógica de negocio de la fuente de datos.
4.  **`feat: validación de entradas y sistema de pistas`**
    *   Lógica para evitar la pérdida de intentos con letras ya usadas y activación de pistas automáticas al alcanzar los 3 intentos.
5.  **`feat: integración de categorías (Arquitectura, POO, .NET)`**
    *   Capacidad de seleccionar temáticas antes de iniciar, inyectando la configuración desde `Program.cs`.
6. **`feat: integración de categorías (Arquitectura, POO, .NET)`**
   * Se agregó un menú donde es posible elegir la categoría de palabras al jugar.

Finalización de la tarea con la capacidad de seleccionar la temática de las palabras antes de iniciar la partida, inyectando la configuración desde el punto de entrada del programa (Program.cs).

## Continuación del Desarrollo: Juego de la Viborita

Tras la implementación del sistema de categorías en el Ahorcado, el proyecto se expandió para incluir el juego de la **Viborita**, aplicando la misma rigurosidad arquitectónica para gestionar el movimiento en tiempo real y la renderización dinámica.

#### Clases e Interfaces Incorporadas
*   **`IMotorJuego`**: Interfaz de arquitectura creada para estandarizar el comportamiento de los motores de juego, permitiendo una gestión uniforme de los estados de victoria o derrota.
*   **`MotorViborita`**: Clase encargada de la lógica de negocio. Gestiona el estado de la serpiente (coordenadas de la cabeza y el cuerpo), la generación aleatoria de comida, el crecimiento al consumir puntos y la detección de colisiones fatales.
*   **`ConsolaUIViborita`**: Clase dedicada exclusivamente a la representación visual. Se encarga de limpiar y redibujar el tablero en cada "frame", posicionando los caracteres que representan a la serpiente y el objetivo en la consola.

#### Integración en `Program.cs`
Se actualizó el punto de entrada principal para permitir la selección dinámica del juego.

### Rama y commit
Se hizo una rama exclusicamente para el juego de la viborita, separando así el programa únicamente con todo el juego del ahorcado y otro con la adición del juego de la Víbora. El último commit de dicha rama es con el objetivo de hacer push a todo el proyecto con el nuevo juego añadido.

## Claúsula de IA
Se usó la IA para guía y correción del código durante el proceso ya que al pegar el código no tenía la misma sintáxis a la del PDF de la tarea.
