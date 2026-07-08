# 🎬📚 Mi Watchlist

Aplicación web para llevar el control de series, películas, libros, manga y cómics pendientes por ver/leer. Permite agregar títulos, clasificarlos, llevar un rango o avance de capítulos, y ver el progreso general de tu lista — todo con modo oscuro/claro.

Corre 100% en el navegador — no necesita servidor ni base de datos externa. Todos los datos se guardan localmente en el `localStorage` del navegador.

---

## ✨ Funcionalidades actuales

### Navegación
- Navbar superior para cambiar entre la sección **Series/Películas** y **Libros/Manga/Cómics**, cada una con su propio diseño.
- Botón de **modo oscuro/claro** (☀️/🌙), con la preferencia guardada en `localStorage`.

### 🎬 Series y Películas
- Barra de progreso general, ponderada por capítulos vistos y películas vistas (no solo por ítems completos).
- Filtros: Todo / Solo series / Solo películas.
- Toggle **"Compactar completos"**: oculta las series/películas ya terminadas de la grilla principal y las muestra como una lista compacta de solo título, para no saturar la vista.
- Agregar/Editar: título, portada (URL), tipo, y para series un **rango de capítulos** pendientes (ej. del 1169 al 1170) en vez de listar todo desde el capítulo 1 — ideal para series muy largas.
- Checklist de capítulos dentro del rango definido; para películas, checkbox simple de "Vista".
- Eliminar con confirmación previa.

### 📚 Libros, Manga y Cómics
- Diseño de **lista** (distinto al de Series), con portada tipo lomo de libro.
- Seguimiento por **stepper** (−/+) del capítulo/tomo actual, en vez de checklist — pensado para lecturas donde vas avanzando de forma continua.
- Barra de progreso individual por título (si defines una meta de capítulo/tomo).
- Filtros por tipo: Libro / Manga / Cómic.
- Agregar/Editar y Eliminar con confirmación, igual que en Series.

### Persistencia
- Todo se guarda en `localStorage` vía JS interop — no se pierde al recargar la página, pero **es exclusivo del navegador/dispositivo donde lo usas**. Series/Películas y Libros/Manga/Cómics se guardan bajo claves separadas.

---

## 🛠️ Tecnología

- [Blazor WebAssembly](https://learn.microsoft.com/aspnet/core/blazor/) (.NET 8)
- C# + Razor Components
- `localStorage` del navegador para persistencia (sin backend)
- CSS puro con variables (sin frameworks externos) — permite el modo oscuro/claro

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
│   ├── WatchlistItem.cs         # Serie/pelicula: rango de capitulos, checklist, etc.
│   └── LibroItem.cs             # Libro/manga/comic: capitulo actual, meta, etc.
├── Services/
│   ├── LocalStorageService.cs   # Guarda/lee Series y Peliculas (clave "watchlist-items")
│   └── LibraryStorageService.cs # Guarda/lee Libros/Manga/Comics (clave "library-items")
├── Pages/
│   ├── Home.razor               # Inicio: Series y Peliculas
│   ├── AddItem.razor            # Agregar/editar Serie o Pelicula
│   ├── Libros.razor             # Inicio: Libros, Manga y Comics
│   └── AgregarLibro.razor       # Agregar/editar Libro, Manga o Comic
├── Shared/
│   └── MainLayout.razor         # Navbar + boton de tema oscuro/claro
├── wwwroot/
│   ├── css/app.css              # Estilos con variables de tema
│   └── js/theme.js              # JS interop para el tema oscuro/claro
└── Program.cs
```

---

## 🚀 Roadmap — próximos pasos

### Corto plazo
- [ ] Subir portada como archivo local (base64) en vez de solo URL.
- [ ] Ordenar/buscar dentro de la lista.
- [ ] Recordar el filtro activo y el estado de "compactar completos" entre sesiones.

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
- [ ] Estadísticas (ej. cuántas series/libros completaste este mes).
- [ ] Notas personales por título (ej. "dejé de ver en el capítulo X porque...").
- [ ] Exportar/importar la watchlist como archivo JSON (respaldo manual mientras no haya cuentas).

---

## 👤 Autor
Diego Alberto Aranda Gonzalez — Proyecto Personal, Ingeniería en Computación Inteligente.