### 1. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET CORE WEB

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto .net core de ASp.Net Core.
- Creamos una carpeta Models para meter la clase que queramos traernos de base de datos.
- Botón derecho sobre el proyecto / Agregar / Nuevo elemento con Scalffold. Seleccionamos Controlador de MVC con vistas...
- Se selecciona la clase y el DataContext si existe (si no, se crea uno nuevo)
- En appsettings.json metemos la cadena de conexión.
- Añadimos el enlace al menú en Shared/_Layout.cshtml

### 2. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET FRAMEWORK WEB (MVC)

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto WEB de ASP.Net FrameWork.
- Botón derecho sobre el proyecto / Agregar / Nuevo elemento. Elegimos datos ADO.Net Entity Data Model
- Seleccionamos EF Designer Data Base (también se puede seleccionar code first desde base de datos)
- Se indica la base de datos a la que conectar y se selecciona la tabla y demás elementos.
- Esto creará el edmx (tiene el modelo de datos) y el tt (contiene el dbContext).
- Botón derecho sobre el proyecto / Agregar / Nuevo elemento con Scalffold. Seleccionamos Controlador de MVC con vistas...
- Se selecciona la clase y el DataContext.
- Añadimos el enlace al menú en Shared/_Layout.cshtml

### 3. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET FRAMEWORK DE CONSOLA

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

### 4. COMO AÑADIR ENTITY FRAMEWORK A PROYECTO .NET CORE DE CONSOLA

**1. CON BASE DE DATOS YA EXISTENTE.**
Usamos la técnica **Data Base First**

- Creamos un proyecto de consola .Net Core
- Instalamos desde los paquetes Nuget: Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Tools, Microsoft.EntityFrameworkCore.SqlServer
- Se realiza el scaffolding indiando la base de datos desde la consola de paquetes:
scaffold-dbcontext "Server=gigabyte-sabre\sqlexpress;Database=pruebas;integrated security=True;" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models -context EFContext
- Ya se puede llamar al context generado desde el Program.cs

Para sobreescribir los cambios si se han realizado en base de datos, hay que lanzar:
scaffold-dbcontext "Server=gigabyte-sabre\sqlexpress;Database=pruebas;integrated security=True;" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models -context EFContext -force

Para usar el patrón de inyección de dependencia:
- Instalar desde Nuget: Microsoft.Extensions.Configuration y Microsoft.Extensions.Configuration.Json
- Editar el archivo del proyecto para que al compilar el proyecto especificar que el archivo json debe copiarse al al directorio de salida.

    <ItemGroup>
        <None Update="appsettings.json">
          <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        </None>
    </ItemGroup>
    
 - Usar este código:
 ```C#
    			var builder = new ConfigurationBuilder()
			  .SetBasePath(Directory.GetCurrentDirectory())
			  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfiguration configuration = builder.Build();

			var services = new ServiceCollection()
				.AddDbContext<EFContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("EFIntroContext")))
				.BuildServiceProvider();

			using (EFContext context = services.GetService<EFContext>())
			{
			 ....
			} ```


