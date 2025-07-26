# CarBrands API (.NET 8)

Este es un proyecto API REST desarrollado con **.NET 8** que permite gestionar marcas de autos (Car Brands). La aplicación está estructurada en múltiples capas para promover una separación de responsabilidades clara y un mantenimiento escalable. Ha sido dockerizado y desplegado exitosamente en Railway.

🔗 **API en producción:**  
[https://carbrandsapi-production.up.railway.app/swagger/index.html](https://carbrandsapi-production.up.railway.app/swagger/index.html)

---

## 🧪 Tests

Se desarrollaron pruebas unitarias utilizando `xUnit` y `FluentAssertions` para asegurar la correcta funcionalidad de:

- Validaciones de entrada con `FluentValidation`.
- Servicios y lógica de negocio.
- Controladores usando mocks para evitar acceso real a base de datos.

> Para ejecutar los tests localmente:

```bash
dotnet test
```

---

## 🗂️ Estructura del Proyecto (N-Capas)

El proyecto está dividido siguiendo el patrón **N-Layer Architecture**:

```
MarcasAutosApi/
│
├── Controllers/          # Define los endpoints HTTP
├── Data/                 # Configuración del DbContext (Entity Framework)
├── Entities/             # Entidades del dominio (Modelos)
├── Dtos/                 # Objetos de transferencia de datos
├── Mappers/              # Configuración de AutoMapper
├── Repositories/         # Acceso a datos (Interfaz + Implementaciones)
├── Services/             # Lógica de negocio
├── Utils/
│   ├── Validators/       # Validadores de FluentValidation
│   └── Interfaces/       # Interfaces comunes
└── Program.cs            # Configuración principal de la aplicación
```

---

## 🐳 Dockerización

Se incluyó un `Dockerfile` que permite levantar la aplicación en un contenedor de forma rápida. El build se hace con la siguiente instrucción:

```bash
docker build -t carbrands-api .
docker run -d -p 5160:5160 carbrands-api
```

> Railway se encargó del despliegue automático usando esta configuración.

---

## 🔗 Railway + PostgreSQL

Se utilizó [**Railway**](https://railway.app) como plataforma de despliegue, incluyendo la base de datos **PostgreSQL**.

- En producción, la **cadena de conexión (ConnectionString)** debe configurarse manualmente en `appsettings.json` o como **variable de entorno**.
- Por motivos de seguridad, el archivo `appsettings.json` fue removido del repositorio.

---

## ⚙️ Ejemplo de `appsettings.json`

A continuación, un ejemplo de cómo configurar el archivo `appsettings.json` para correr la aplicación localmente con PostgreSQL. Puedes usar una base de datos local de PostgreSQL o una instancia en Railway, según prefieras:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=your-host.proxy.rlwy.net;Port=your-port;Database=your-database;Username=your-username;Password=your-password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

☝️ Importante: Este archivo no debe subirse al repositorio si contiene credenciales reales.
Para producción se recomienda usar variables de entorno, por ejemplo:

`ConnectionStrings__DefaultConnection`

---

## 🛠️ Migraciones

Se utilizaron migraciones de Entity Framework Core para crear la base de datos y sus tablas:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 🔁 Endpoints disponibles

### 🔸 POST - Crear una marca

```bash
curl -X POST https://carbrandsapi-production.up.railway.app/api/CarBrands  -H "Content-Type: application/json"  -d '{
   "name": "Honda"
 }'
```

### 🔸 GET - Listar todas las marcas

```bash
curl -X GET https://carbrandsapi-production.up.railway.app/api/CarBrands
```

---

## ✅ Requisitos

- .NET 8 SDK
- Docker (opcional para contenedores)
- Railway CLI (opcional)
- PostgreSQL (en local o remoto)

---

## 📌 Notas adicionales

- El proyecto usa **AutoMapper** para mapear entre entidades y DTOs.
- Todas las validaciones de entrada están implementadas con `FluentValidation`.
