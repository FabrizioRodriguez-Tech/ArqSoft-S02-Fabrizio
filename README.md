# ArqSoft-S02-Fabrizio

## Análisis de principios SOLID

| Situación | Principio SOLID violado | Explicación |
|---|---|---|
| `Juego` controla turnos, tablero, mensajes y palabras | **SRP (Single Responsibility Principle)** | La clase tiene demasiadas responsabilidades en una sola clase. |
| Las palabras están hardcodeadas en el constructor | **DIP (Dependency Inversion Principle)** | `Juego` depende directamente de una lista concreta de palabras en lugar de una abstracción. |
| Para agregar otro juego habría que modificar `Juego` | **OCP (Open/Closed Principle)** | La clase no está preparada para extender funcionalidades sin modificar el código existente. |