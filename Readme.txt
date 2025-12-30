# Prueba Técnica – Desarrollador .NET
**Autor:** Andrés Cifuentes  
**Tecnología:** .NET 8 – Blazor Web App – Razor Components

Este proyecto es una aplicación en .NET 8 usando Blazor Web App para la gestión básica de empleados. Implementa operaciones CRUD y está diseñada como prueba técnica, enfocada en código limpio, arquitectura desacoplada y buenas prácticas.

## Estructura de la solución

- **Components:** Razor Components y páginas (Empleados).  
- **Models:** Modelos de dominio.  
- **Interfaces:** Contratos de servicios:
  - `IEmpleados` → interfaz general para la capa de servicios.
  - `IEmpleadosDb` → interfaz específica para proveedores de base de datos.
  - `IEmpleadosMemory` → interfaz específica para proveedores en memoria.
- **Provider:** Implementaciones de las interfaces:
  - `EmpleadosDbProvider` → conexión a base de datos via EF Core.
  - `EmpleadosMemoryProvider` → datos en memoria para fallback.
  - `EmpleadosFallbackProvider` → gestiona automáticamente el fallback entre DB y memoria.

## Arquitectura y buenas prácticas

La UI consume los servicios mediante **inyección de dependencias**, evitando acoplar la presentación a la lógica de datos.  
Todas las operaciones son **asíncronas** y la capa de servicios está preparada para trabajar con cualquier proveedor de datos sin cambios en la capa de presentación.

El **Fallback Provider** permite:
- Priorizar la base de datos como fuente de información principal.
- Usar datos en memoria automáticamente cuando la base de datos no contiene registros o hay errores de conexión.
- Mantener la aplicación funcional en cualquier escenario de prueba o despliegue.

La separación de interfaces (`IEmpleadosDb`, `IEmpleadosMemory`) asegura que la arquitectura sigue el **Principio de Inversión de Dependencias (DIP)**, facilitando **testeo, extensibilidad y mantenibilidad**.

## Ejecución del proyecto

1. Abrir la solución en Visual Studio.  
2. Ejecutar la aplicación.  
3. Acceder a la ruta `/empleados` desde el navegador.

Esta implementación demuestra una **arquitectura limpia y desacoplada**, priorizando claridad, escalabilidad y buenas prácticas en .NET.
