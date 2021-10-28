### 1. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET CORE

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto .net core de ASp.Net Core.
- Creamos una carpeta Models para meter la clase que queramos trarernos de base de datos.
- Botón derecho sobre el proyecto / Agregar / Nuevo elemento con Scalffold. Seleccionamos Controlador de MVC con vistas...
- Se selecciona la clase y el DataContext si existe (si no, se crea uno nuevo)
- En appsettings.json metemos la cadena de conexión.
- Añadimos el enlace al menú en Shared/_Layout.cshtml

### 2. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET FRAMEWORK

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto de consola .Net Framework
- Botón derecho sobre el proyecto / Agregar / Nuevo elemento. Elegimos datos ADO.Net Entity Data Model
- Seleccionamos EF Designer Data Base (también se puede seleccionar code first desde base de datos)
- Se indica la base de datos a la que conectar y se selecciona la tabla y demás elementos.
- Esto creará el edmx (tiene el modelo de datos) y el tt (contiene el dbContext).

Para actualizar el modelo si cambia en la base de datos:
- Se abre el edmx, botón derecho y actualizar desde base de datos.
- En edmx se pulsa el botón derecho y "Ejecutar herramienta personalizada"
- en el .tt se le da a "Ejecutar herramienta personalizada"

### 3. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET CORE

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto de consola .Net Core
- Instalamos desde los paquetes Nuget: Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Tools, Microsoft.EntityFrameworkCore.SqlServer
- Se realiza el scaffolding indiando la base de datos desde la consola de paquetes:
scaffold-dbcontext "Server=gigabyte-sabre\sqlexpress;Database=pruebas;integrated security=True;" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models -context EFContext
- Ya se puede llamar al context generado desde el Program.cs

