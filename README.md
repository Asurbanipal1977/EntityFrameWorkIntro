### 1. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET CORE

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto .net core de ASp.Net Core.
- Creamos una carpeta Models para meter la clase que queramos trarernos de base de datos.
- Botón derecho sobre el proyecto / Agregar / Nuevo elemento con Scalffold. Seleccionamos Controlador de MVC con vistas...
- Se selecciona la clase y el DataContext si existe (si no, se crea uno nuevo)
- En appsettings.json metemos la cadena de conexión.
- Añadimos el enlace al menú en Shared/_Layout.cshtml
