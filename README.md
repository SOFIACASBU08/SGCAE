# SGCAE - Sistema de Gestión y Control de Acceso de Empleados

## Descripción

SGCAE es una API REST desarrollada con ASP.NET Core para gestionar empleados, credenciales, puntos de acceso y registros de entradas y salidas. El sistema permite validar los intentos de acceso y consultar el historial mediante filtros y paginación.

## Tecnologías utilizadas

- C#
- ASP.NET Core Web API
- .NET 10
- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS
- Entity Framework Core
- SQL Server Express
- Git y GitHub

## Estructura del proyecto

- **SGCAE.API:** expone los endpoints de la API REST.
- **SGCAE.Application:** contiene los casos de uso y la lógica de aplicación.
- **SGCAE.Domain:** contiene las entidades y reglas del dominio.
- **SGCAE.Infrastructure:** implementa el acceso a datos y los repositorios.

## Funcionalidades

- Gestión de empleados: registrar, consultar, actualizar y desactivar.
- Gestión de credenciales: asignar, consultar, bloquear y revocar.
- Gestión de puntos de acceso: registrar, consultar y desactivar.
- Registro de entradas y salidas, incluyendo intentos rechazados.
- Consulta del historial de accesos con filtros y paginación.

## Requisitos previos

- .NET SDK 10.
- SQL Server Express.
- Visual Studio Code o un editor compatible.

## Configuración

1. Clonar el repositorio.
2. Configurar la cadena de conexión a SQL Server en `SGCAE.API/appsettings.json`.
3. Verificar que la base de datos `SGCAE_DB` exista y que el usuario tenga permisos de acceso.
4. Aplicar las migraciones de Entity Framework Core si todavía no se han aplicado.

## Ejecución

Desde la carpeta raíz del proyecto, ejecutar:

```powershell
dotnet restore
dotnet build
dotnet run --project SGCAE.API
```

La API estará disponible en la dirección local indicada por la terminal. Si Swagger está habilitado, se puede utilizar para probar los endpoints.

## Repositorio

https://github.com/SOFIACASBU08/SGCAE
