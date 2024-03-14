# Prueba Tecnica RF-ToDo

## Bienvenidos

Esta prueba técnica consiste en un mini módulo/proyecto creado con .Net 7, utilizando Blazor en la App y la API REST fue desarrollada bajo la arquitectura Clean Architecture.

### Un poco de la App: 

Blazor ofrece las siguientes ventajas:

- Interfaz de usuario dinámica y receptiva.
- Desarrollo de aplicaciones web con C# en lugar de JavaScript.
- Integración con el ecosistema .NET para un desarrollo más rápido y seguro.
- Capacidad para crear aplicaciones de una sola página (SPA) y aplicaciones web progresivas (PWA).

### Configurar la App:

Debido a las prisas, la URL de la API para nuestro servicio HttpClient se dejó "hardcodeada" y deberá modificarse ubicada en `Program.cs` dentro de la App.

![Configuración de la URL de la API](https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/eeea6188-9ac3-4424-9b81-4a220c733af9)

### Un poco de la Api:

![Estructura de la API](https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/d43df813-892a-4e23-969d-c135b69ac87a)

Aquí hemos implementado la arquitectura Clean Architecture. Esta arquitectura nos permite crear sistemas altamente mantenibles, testables y escalables.

## Requerimientos para Ejecutar la API

- Antes de ejecutar la API, asegúrate de tener PostgreSQL instalado y una base de datos vacía.
- Instala el SDK de .NET 7 desde el sitio web oficial de .NET.
- Se recomienda tener Visual Studio instalado para facilitar el desarrollo.

## Pasos para Ejecutar la API:

1. Abre la solución en tu entorno de desarrollo preferido, como Visual Studio.
2. Configura las variables de conexión a la base de datos en el archivo `appsettings.Development.json` en la sección `ConnectionStrings.APP`.
   
    ![Configuración de la Base de Datos](https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/70fad1d4-c6b2-4687-8dc9-148260dd3147)

3. Ejecuta el siguiente comando en la terminal desde la carpeta `persistence` para aplicar las migraciones a la base de datos:
   ```bash
   dotnet ef database update --context CoreDbContext --startup-project ../API


#Capturas
A continuacion se mostrarán algunas capturas de pantalla:


<img width="200" alt="Captura de pantalla 2024-03-14 034023" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/18e3c99e-0ee2-4622-a360-9f0ce5b6ff69">
Imagen 1: Listado de metas.

<img width="635" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/bc0c25ad-132d-4fae-91f8-592e70bf062f">
Imagen 2: Listado de Tareas.

<img width="215" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/ecf9dcd4-fafe-4055-8eb3-fa349258e41d">
Imagen 3: Modal para agregar nuevas metas.

<img width="205" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/ea48c17b-0075-4094-ac18-a5f281a7d4da">
Imagen 4: Modal para editar metas.

<img width="203" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/fb461108-11f7-4c3a-b5a0-10c5c92e21e9">
Imagen 5: Mensajes de confirmacion.

<img width="201" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/fdf63e4d-b870-4deb-9639-b16e0e1cd16a">
Imagen 5: Mensajes de advertencia.


