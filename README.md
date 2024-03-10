# Requisitos previos
Asegúrate de tener instalado lo siguiente:
- .NET Core SDK (versión 8.0.101 o superior).
- Node.js (versión 20.11.1 o superior).
- Visual Studio 2022 con las cargas de trabajo adecuadas para desarrollar aplicaciones web ASP.Net Core.
# Iniciar el servidor de la Web API
1. Es necesario tener instalado Mysql.
2. Se debe configurar el archivo appsettings.json del proyecto *To-Dos_App.API* en modificando el ConnectionString "DefaultConnection" para comunicarse con la base de datos.
3. Se debe ejecutar el proyecto *To-Dos_App.API* en un entorno de desarrollo.
# Iniciar el servidor de la UI
1. Se debe configurar el archivo vit.config utilizando como target del proxy en las configuraciones del server el proveido por el servidor levantado.
2. Se debe ejecutar una terminal en la dirección del proyecto *To-Dos_App.UI*.
3. Ejecutar en la terminal el comando npm install todomvc-app-css.
5. Ejecutar en la terminal el comando: npm run dev.
6. Abrir en el navegador la dirección proveída en la terminal.
