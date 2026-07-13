# 🎬📚📊 Mi Watchlist

Aplicación web para llevar el control de series, películas, libros, manga y cómics pendientes por ver/leer. Permite agregar títulos, clasificarlos, llevar un rango o avance de capítulos, ver el progreso general de tu lista, y ahora también revisar estadísticas con gráficas — todo con modo oscuro/claro.

Los datos ya **no viven solo en el navegador**: hay un backend real (ASP.NET Core Web API + SQLite) que los guarda de forma persistente. La primera vez que corras la app, cualquier dato que tuvieras en `localStorage` se migra automáticamente al backend, sin borrarse (queda de respaldo).

---

## ✨ Funcionalidades actuales

### Navegación
- Navbar superior con tres pestañas: **Series/Películas**, **Libros/Manga/Cómics** y **Estadísticas**, cada una con su propio diseño.
- Botón de **modo oscuro/claro**, con la preferencia guardada en `localStorage`.

### 🎬 Series y Películas
- Barra de progreso general, ponderada por capítulos vistos y películas vistas.
- Filtros: Todo / Solo series / Solo películas / **En progreso** (ni sin empezar, ni terminado).
- Búsqueda por título en tiempo real.
- Orden: más recientes, más antiguos, **más avanzados primero**, título A-Z, título Z-A.
- Toggle **"Compactar completos"**: oculta lo ya terminado de la grilla principal.
- El filtro, la búsqueda, el orden y "compactar completos" se recuerdan entre sesiones.
- Agregar/Editar: título, portada (URL), tipo, y para series un **rango de capítulos** pendientes (ej. del 1169 al 1170) — ideal para series muy largas.
- Checklist de capítulos dentro del rango; para películas, checkbox de "Vista" con diseño propio.
- Eliminar con confirmación previa.

### 📚 Libros, Manga y Cómics
- Diseño de **lista**, con portada tipo lomo de libro.
- Seguimiento por **stepper** (−/+) del capítulo/tomo actual.
- Barra de progreso individual por título (si defines una meta de capítulo/tomo).
- Filtros por tipo + **En progreso**, búsqueda por título y orden (incluyendo **más avanzados primero**) — mismo comportamiento que en Series, con sus propias preferencias guardadas por separado.

### 📊 Estadísticas
- 4 tarjetas de resumen: títulos totales, completados, en progreso, sin empezar (combinando ambas secciones).
- 2 gráficas de dona: progreso general de Series/Películas y de Libros/Manga/Cómics.
- 1 gráfica de barras: distribución de tu colección por tipo (Series, Películas, Libros, Manga, Cómics).
- Construidas con SVG puro (componentes `DonutChart.razor` y `BarChart.razor`, reutilizables), sin librerías externas de gráficas.

### Interfaz
- Íconos SVG (Heroicons + un ícono propio para "chart") en vez de emojis, en un componente `Icon.razor` reutilizable.
- Inputs de formularios con estilo propio, estado de foco visible, y buen contraste tanto en modo oscuro como claro.

### Persistencia
- **Backend real**: ASP.NET Core Web API + Entity Framework Core + SQLite (`watchlist.db`).
- La app migra automáticamente los datos viejos de `localStorage` al backend la primera vez que corre (sin borrar el respaldo local).
- Las preferencias de interfaz (filtro/orden/búsqueda/compactar) siguen viviendo en `localStorage` — son por dispositivo, no datos que deban sincronizarse.

---

## 🛠️ Tecnología

**Frontend**
- [Blazor WebAssembly](https://learn.microsoft.com/aspnet/core/blazor/) (.NET 8)
- C# + Razor Components
- CSS modular con variables (design tokens) — ver estructura abajo
- Gráficas SVG hechas a mano (sin dependencias de charting)

**Backend**
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core + SQLite
- CORS abierto para desarrollo local (sin autenticación todavía)

---

## ▶️ Cómo correrlo localmente

Requiere el [.NET SDK 8.0](https://dotnet.microsoft.com/download). Se necesitan **dos terminales abiertas al mismo tiempo**.

**Terminal 1 — Backend:**
```bash
cd WatchlistApi
dotnet restore
dotnet run
```
Debe quedar escuchando en `http://localhost:5250`. La base de datos `watchlist.db` se crea sola la primera vez.

**Terminal 2 — Frontend:**
```bash
cd WatchlistApp_Proyect
dotnet restore
dotnet watch run
```
Abre en el navegador la URL que muestre la terminal (ej. `http://localhost:5224`).

> ⚠️ Si el backend no está corriendo, el frontend va a fallar al cargar los datos (error de red/CORS en la consola del navegador).

---

## 📁 Estructura del proyecto (monorepo)

```
Watchlist/                       ← raíz del repo (.git aquí)
├── WatchlistApp_Proyect/        ← Frontend (Blazor WebAssembly)
│   ├── Models/
│   │   ├── WatchlistItem.cs
│   │   └── LibroItem.cs
│   ├── Services/
│   │   ├── LocalStorageService.cs    # habla con el backend + migra localStorage
│   │   └── LibraryStorageService.cs
│   ├── Pages/
│   │   ├── Home.razor                # busqueda, orden (incl. avance), preferencias
│   │   ├── AddItem.razor
│   │   ├── Libros.razor              # busqueda, orden (incl. avance), preferencias
│   │   ├── AgregarLibro.razor
│   │   └── Estadisticas.razor        # tarjetas + graficas de dona y barras
│   ├── Shared/
│   │   ├── MainLayout.razor          # navbar con las 3 pestañas
│   │   ├── Icon.razor
│   │   ├── DonutChart.razor          # componente reutilizable
│   │   └── BarChart.razor            # componente reutilizable
│   └── wwwroot/
│       ├── css/
│       │   ├── app.css               # solo @import de los modulos de abajo
│       │   ├── tokens.css            # colores, espaciado, radios
│       │   ├── base.css              # reset, body, iconos
│       │   ├── layout.css            # navbar, main, headers
│       │   ├── buttons.css           # botones, filtros, barra de progreso
│       │   ├── forms.css             # inputs de AddItem.razor y AgregarLibro.razor
│       │   ├── cards.css             # grilla/tarjetas (solo Home.razor)
│       │   ├── checklist.css         # checkbox "Vista" y episodios (solo Home.razor)
│       │   ├── libros.css            # diseño de lista (solo seccion Libros)
│       │   └── estadisticas.css      # tarjetas, dona y barras (solo Estadisticas.razor)
│       └── js/theme.js
│
└── WatchlistApi/                ← Backend (ASP.NET Core Web API)
    ├── Models/
    │   ├── WatchlistItemEntity.cs
    │   └── LibroItemEntity.cs
    ├── Data/
    │   └── AppDbContext.cs
    ├── Controllers/
    │   ├── WatchlistController.cs
    │   └── LibrosController.cs
    ├── Program.cs
    └── watchlist.db              # se genera solo, no se sube al repo (.gitignore)
```

---

## 🚀 Roadmap — próximos pasos

### Corto plazo
- [ ] Subir portada como archivo local (base64) en vez de solo URL.
- [ ] Agregar más gráficas a Estadísticas (ej. títulos agregados por mes, top de series más avanzadas).

### Publicar el backend y el frontend (acceso público)
- [ ] Publicar el **backend** en un hosting que soporte ASP.NET Core (Azure App Service, Render, Railway, etc.).
- [ ] Publicar el **frontend** en GitHub Pages o Azure Static Web Apps, apuntando su `HttpClient` a la URL pública del backend.
- [ ] Restringir el CORS del backend a la URL real del frontend publicado (ahora mismo abierto con `AllowAnyOrigin`, válido solo para desarrollo local).
- [ ] Evaluar si SQLite sigue siendo suficiente o conviene PostgreSQL/Azure SQL según el hosting elegido.

### Login y sincronización entre dispositivos
- [ ] Sistema de **autenticación** (ASP.NET Core Identity, o login con Google/GitHub vía OAuth).
- [ ] Relacionar cada `WatchlistItemEntity`/`LibroItemEntity` con un usuario (`UserId`).
- [ ] Cada usuario autenticado ve solo su propia watchlist.
- [ ] Proteger los endpoints del backend (hoy son públicos).

### Otras ideas a futuro
- [ ] Notas personales por título.
- [ ] Exportar/importar la watchlist como JSON (respaldo manual mientras no haya cuentas).

---

## 👤 Autor
Diego Alberto Aranda Gonzalez — proyecto personal, Ingeniería en Computación Inteligente, UAA.