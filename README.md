# prueba_tecnica_RF-ToDo
# Bienvenidos
Esta prueba tecnica es un mini modulo/proyecto creado con .Net 7, utilizando Blazor en la App y la Api REST fue creada bajo la arquitectura clean archiquecture.

Un poco de la App: 
Blazor ofrece las siguientes ventajas:

°Interfaz de usuario dinámica y receptiva.
°Desarrollo de aplicaciones web con C# en lugar de JavaScript.
°Integración con el ecosistema .NET para un desarrollo más rápido y seguro.
°Capacidad para crear aplicaciones de una sola página (SPA) y aplicaciones web progresivas (PWA).

Configurar App:
-Por las prisas se dejo "hardcoreado" la url de la api para nuestro servicio HttpClient, este se deberá modificar ubicado en Program.cs dentro de la App.

<img width="664" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/eeea6188-9ac3-4424-9b81-4a220c733af9">

#Un poco de la Api:
<img width="240" alt="image" src="https://github.com/Riichhard97/prueba_tecnica_RF-ToDo/assets/62078290/d43df813-892a-4e23-969d-c135b69ac87a">
Estructura de api.

## Proyecto con Clean Architecture en ASP.NET 7
Aquí hemos implementado la arquitectura Clean Architecture. Esta arquitectura nos permite crear sistemas altamente mantenibles, testables y escalables.

## ¿Qué es Clean Architecture?
Clean Architecture es un enfoque de diseño de software que se centra en la separación de preocupaciones y la independencia de frameworks externos. Se basa en los principios SOLID y promueve la creación de sistemas altamente mantenibles, testables y escalables.

## Ventajas de Clean Architecture
Independencia de Frameworks: Los detalles de la infraestructura, como las bases de datos o los frameworks de UI, están separados de la lógica de negocio, lo que facilita la adaptación a cambios tecnológicos.

Testabilidad: La separación de capas permite escribir pruebas unitarias y de integración de forma más sencilla, ya que la lógica de negocio no está acoplada a la infraestructura.

Mantenibilidad: La arquitectura limpia fomenta la modularidad y la cohesión, lo que facilita la identificación y el mantenimiento de diferentes componentes del sistema.

Escalabilidad: Al tener una estructura bien definida y desacoplada, es más fácil escalar y extender la aplicación a medida que los requisitos cambian o crecen.

## Coleccion exportado endpoints PostMan.
Dentro de la carpeta "Coleccion para postman" viene la coleccion, con las variables configuradas y los endpoints existentes.

## Requerimientos para Ejecutar la API
- Antes de ejecutar la API, asegúrate de tener PostgreSQL instalado y una base de datos vacía.
- Instalar el SDK de .NET 7: Asegúrate de tener instalado el SDK de .NET 5 en tu máquina. Puedes descargarlo desde el sitio web oficial de .NET.
- Los siguientes pasos tambien incluye utilizar Visual Studio, de preferencia tenerlo instalado.
## Pasos para Ejecutar la API:
Abrir el Proyecto: Abre la solución de tu proyecto ASP.NET Core 5 en tu entorno de desarrollo favorito, como Visual Studio.

### Configuración de la API:
Revisa y ajusta el archivo appsettings.Development.json para configurar las variables de conexión a la base de datos ### ConnectionStrings.APP.
<img width="868" alt="image" src="https://github.com/Riichhard97/prueba_tecnica/assets/62078290/70fad1d4-c6b2-4687-8dc9-148260dd3147">

Ejecutar este comando posicionados en persistence. 
Esto aplicara las migraciones a nuestra base de datos:
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


