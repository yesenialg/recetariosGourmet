# Introducción
Este backend tiene persistencia de recetas y recetarios en una base de datos en sqlite. Se crea con el proposito de explicar el funcionamiento de la inyección de dependencias en la clase de Enfasis(Deuda Técnica) - UdeM

# Funcionamiento de la Api
1.	En la carpeta Gourmet lanzar los siguientes dos comandos para la creación de la base de datos
- dotnet ef migrations add < nombreDeLaMigracion >
- dotnet ef database update
2.	En la carpeta recetariosGourmet 
- dotnet build
3.	Correr la app

# Inyección de dependencias
Se utiliza el IServiceCollection en el archivo GourmetApi/Extensions/ServiceExtensions.cs donde se crean los Transient de las clases a crear:
- RecetarioRepository
- RecetaRepository
- RecetarioService
- RecetaService