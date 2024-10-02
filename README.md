TaskManagementApp:

Aplicación básica para gestionar tareas.

Requisitos:
1. Front:
   -Node.js
   -npm o yarn
2. Back:
   -.net sdk
   -sql server(express)

Instalacion:
1. Clonar el repositorio
2. Configurar el Front
   -npm install
   -npm start
3. Configurar el Back
   -dotnet restore(instala las dependencias de NuGet)
4. Configurar la base de datos
   -crear la bd : TaskManagement
   -crear las tablas con el script
   NOTA:El proyecto incluye un archivo appsettings.json que contiene la cadena de conexión encriptada bajo la clave DefaultConnection(LA CADENA DE CONEXION PERSONAL ESTA ENCRIPTADA)
5. Las rutas estan protegidas con Bearer Token:
   -para usar swagger y evitar error 401 no autorizado se debe colocar la clave: Bearer mi_token_secreto

Librerías Utilizadas
-Frontend:
  -React (sin librerías adicionales)
-Backend:
  -Microsoft.AspNetCore.Authentication.JwtBearer
  -EntityFrameworkCore
  -EntityFrameworkCore.SqlServer
