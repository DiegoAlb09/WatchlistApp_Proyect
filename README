# 🎬 Mi Watchlist

Aplicación web para llevar el control de series y películas pendientes por ver. Permite agregar títulos, clasificarlos como serie o película, llevar un rango de capítulos pendientes (útil para series muy largas) y ver el progreso general de tu lista.

Corre 100% en el navegador — no necesita servidor ni base de datos externa. Todos los datos se guardan localmente en el `localStorage` del navegador.

---

## ✨ Funcionalidades actuales

- **Pantalla de inicio**
  - Barra de progreso general, ponderada por capítulos vistos y películas vistas (no solo por ítems completos).
  - Filtros: Todo / Solo series / Solo películas.
  - Tarjetas con portada, título, tipo de contenido y estado de avance.
- **Agregar / Editar**
  - Título, portada (URL de imagen), tipo (serie/película).
  - Para series: rango de capítulos pendientes (ej. del 1169 al 1170), en vez de listar todos los capítulos desde el 1 — ideal para series muy largas.
  - Validación de que el rango sea válido.
- **Checklist de capítulos**
  - Cada capítulo del rango se marca individualmente como visto.
  - Para películas, un checkbox simple de "Vista".
- **Eliminar**
  - Con confirmación antes de borrar, para evitar borrados accidentales.
- **Persistencia**
  - Todo se guarda en `localStorage` vía JS interop — no se pierde al recargar la página, pero **es exclusivo del navegador/dispositivo donde lo usas**.

---

## 🛠️ Tecnología

- [Blazor WebAssembly](https://learn.microsoft.com/aspnet/core/blazor/) (.NET 8)
- C# + Razor Components
- `localStorage` del navegador para persistencia (sin backend)
- CSS puro (sin frameworks externos)

---

## ▶️ Cómo correrlo localmente

Requiere el [.NET SDK 8.0](https://dotnet.microsoft.com/download).

```bash
dotnet restore
dotnet watch run
```

Abre en el navegador la URL que muestre la terminal (ej. `http://localhost:5231`).

---

## 📁 Estructura del proyecto

```
WatchlistApp/
├── Models/
│   └── WatchlistItem.cs        # Modelo de datos (serie/pelicula, rango de capitulos, etc.)
├── Services/
│   └── LocalStorageService.cs  # Guarda/lee la watchlist en localStorage
├── Pages/
│   ├── Home.razor              # Pantalla de inicio (lista, progreso, filtros)
│   └── AddItem.razor           # Pantalla de agregar/editar
├── wwwroot/
│   └── css/app.css
└── Program.cs
```

---

## 🚀 Roadmap — próximos pasos

### Corto plazo
- [ ] Subir portada como archivo local (base64) en vez de solo URL.
- [ ] Barra de progreso individual por serie (no solo la general).
- [ ] Ordenar/buscar dentro de la lista.

### Publicar la página (acceso público)
Actualmente el proyecto solo corre en `localhost`. Para que otras personas puedan usarlo desde internet:
- [ ] Publicar como sitio estático en **GitHub Pages** (Blazor WASM es 100% estático, se puede alojar gratis ahí).
- [ ] Alternativa: desplegar en **Azure Static Web Apps** (tiene un tier gratuito y soporta Blazor WASM directamente).
- [ ] Configurar el `base href` en `index.html` según la ruta del deploy (necesario para que las rutas funcionen en GitHub Pages).

### Login y sincronización entre dispositivos
Hoy la watchlist vive solo en el `localStorage` de un navegador — si abres la app en el celular o en otra computadora, no vas a ver la misma lista. Para resolver esto se necesita un cambio de arquitectura más grande:
- [ ] Agregar un **backend** (ej. ASP.NET Core Web API) con una base de datos real (SQLite, PostgreSQL, o Azure SQL) en vez de `localStorage`.
- [ ] Sistema de **autenticación** (login) — opciones a evaluar:
  - ASP.NET Core Identity (email + contraseña, todo dentro del mismo ecosistema .NET).
  - Login con Google/GitHub (OAuth), más rápido de implementar y sin manejar contraseñas.
- [ ] Cada usuario autenticado ve solo su propia watchlist, guardada en el servidor.
- [ ] Migrar los datos que ya existen en `localStorage` a la cuenta del usuario la primera vez que inicie sesión (para no perder lo que ya tenía).
- [ ] Esto implica pasar de una app 100% estática a una con backend — ya no bastaría con GitHub Pages, se necesitaría un hosting que soporte el servidor (Azure App Service, Render, Railway, etc.).

### Otras ideas a futuro
- [ ] Modo oscuro/claro (actualmente solo hay tema oscuro).
- [ ] Estadísticas (ej. cuántas series completaste este mes).
- [ ] Notas personales por título (ej. "dejé de ver en el capítulo X porque...").

---

## 👤 Autor
Diego Alberto Aranda Gonzalez — proyecto personal, Ingeniería en Computación Inteligente.