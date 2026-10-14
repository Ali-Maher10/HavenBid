# Globo — Houses & Bids

Globo is a full-stack house-listing application ("Providing houses all over the world"). Users can browse houses, view details, add / edit / delete listings, and place bids on a house.

- **Backend:** ASP.NET Core **Minimal API** (.NET 8) + Entity Framework Core + SQLite
- **Frontend:** React 18 + TypeScript + Vite + React Query + Bootstrap

---

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [API Reference](#api-reference)
- [Data Model](#data-model)
- [Database & Migrations](#database--migrations)
- [Frontend Overview](#frontend-overview)
- [Available Scripts](#available-scripts)
- [Troubleshooting](#troubleshooting)

---

## Features

- List all houses with address, country, price and photo
- House detail page with description and bid history
- Add, edit and delete houses (with image upload, compressed and stored as Base64)
- Place bids on a house
- Server-side validation (MiniValidation) with RFC 7807 problem details surfaced in the UI
- Swagger / OpenAPI UI in development
- Seeded sample data (10 houses, with SVG photos in `ReactWeb/public/houses`)

## Tech Stack

### Backend (`Api/`)

| Concern | Technology |
| --- | --- |
| Framework | ASP.NET Core Minimal API, .NET 8 |
| ORM | Entity Framework Core 8.0.11 |
| Database | SQLite (`Microsoft.EntityFrameworkCore.Sqlite`) |
| Validation | [MiniValidation](https://github.com/DamianEdwards/MiniValidation) 0.10.0 |
| API docs | Swashbuckle.AspNetCore 6.6.2 (Swagger UI) |
| Pattern | Repository pattern + DTO records |

### Frontend (`ReactWeb/`)

| Concern | Technology |
| --- | --- |
| UI | React 18, TypeScript 5.6 |
| Build tool | Vite 5 (SWC plugin) |
| Routing | react-router-dom 6 |
| Data fetching | TanStack React Query 5 + Axios |
| Styling | Bootstrap 5 |
| Image handling | browser-image-compression |
| Linting | ESLint 9 + typescript-eslint |

## Project Structure

```
globo/
├── Api/                          # .NET 8 Minimal API
│   ├── Program.cs                # Service registration, middleware, endpoint mapping
│   ├── WebApplicationHouseExtension.cs   # /houses endpoints
│   ├── WebApplicationBidExtensions.cs    # /house/{id}/bids endpoints
│   ├── Data/                     # DbContext, entities, repositories, seed data
│   ├── Dtos/                     # Request/response records (HouseDto, HouseDetailDto, BidDto)
│   ├── Migrations/               # EF Core migrations
│   └── Properties/launchSettings.json
└── ReactWeb/                     # React + Vite SPA
    ├── public/houses/            # Sample house SVGs
    └── src/
        ├── main/                 # App shell, Header, routing
        ├── house/                # HouseList, HouseDetail, HouseAdd, HouseEdit, HouseForm
        ├── bids/                 # Bids component
        ├── hooks/                # React Query hooks (HouseHooks, BidHooks)
        ├── types/                # House, Bid, Problem types
        └── config.ts             # API base URL + currency formatter
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) 18+ and npm
- EF Core CLI tool (for the database):
  ```bash
  dotnet tool install --global dotnet-ef
  ```
- Trust the ASP.NET Core HTTPS dev certificate (the API runs on HTTPS):
  ```bash
  dotnet dev-certs https --trust
  ```

## Getting Started

### 1. Clone

```bash
git clone <your-repo-url>
cd globo
```

### 2. Run the API

```bash
cd Api
dotnet restore
dotnet ef database update     # creates houses.db and applies migrations + seed data
dotnet run
```

The API listens on **https://localhost:4000** and opens Swagger UI at `https://localhost:4000/swagger` (Development environment).

### 3. Run the frontend

In a second terminal:

```bash
cd ReactWeb
npm install
npm run dev
```

The app is served at **http://localhost:3000**.

> The ports matter: Vite is pinned to `3000` (`strictPort`) and the API's CORS policy only allows `http://localhost:3000`.

## Configuration

| Setting | Location | Default |
| --- | --- | --- |
| API URL | `Api/Properties/launchSettings.json` | `https://localhost:4000` |
| Allowed CORS origin | `Api/Program.cs` (`UseCors`) | `http://localhost:3000` |
| Frontend → API base URL | `ReactWeb/src/config.ts` (`baseApiUrl`) | `https://localhost:4000` |
| Frontend dev port | `ReactWeb/vite.config.ts` | `3000` |
| SQLite file | `Api/Data/HouseDbContext.cs` | `<LocalApplicationData>/houses.db` (on Windows: `%LOCALAPPDATA%\houses.db`) |

When deploying, update the CORS origin and `baseApiUrl` to your real hosts.

## API Reference

All endpoints are defined with Minimal API `MapGet` / `MapPost` / `MapPut` / `MapDelete`. Errors use RFC 7807 problem details (`404` not found, `400` validation).

### Houses

| Method | Route | Description | Success | Errors |
| --- | --- | --- | --- | --- |
| GET | `/houses` | List all houses (`HouseDto[]`) | 200 | — |
| GET | `/house/{houseId}` | Get a house (`HouseDetailDto`) | 200 | 404 |
| POST | `/houses` | Create a house | 201 + `Location: /house/{id}` | 400 validation |
| PUT | `/houses` | Update a house (id in body) | 200 | 400 validation, 404 |
| DELETE | `/houses/{houseId}` | Delete a house | 200 | 404 |

### Bids

| Method | Route | Description | Success | Errors |
| --- | --- | --- | --- | --- |
| GET | `/house/{houseId}/bids` | List bids for a house (`BidDto[]`) | 200 | 404 house not found |
| POST | `/house/{houseId}/bids` | Place a bid | 201 | 400 (route/body `houseId` mismatch or validation) |

### Example requests

```bash
# List houses
curl -k https://localhost:4000/houses

# Create a house
curl -k -X POST https://localhost:4000/houses \
  -H "Content-Type: application/json" \
  -d '{"id":0,"address":"12 Palm St","country":"Egypt","price":250000,"description":"Sea view","photo":null}'

# Place a bid
curl -k -X POST https://localhost:4000/house/1/bids \
  -H "Content-Type: application/json" \
  -d '{"id":0,"houseId":1,"bidder":"Ali","amount":260000}'
```

### DTOs

```csharp
record HouseDto(int Id, string? Address, string? Country, int Price, string? Photo);
record HouseDetailDto(int Id, [Required] string? Address, [Required] string? Country,
                      int Price, string? Description, string? Photo);
record BidDto(int Id, int HouseId, [Required] string? Bidder, int Amount);
```

## Data Model

```
HouseEntity 1 ───── * BidEntity
```

| HouseEntity | Type |
| --- | --- |
| Id | int (PK) |
| Address | string? |
| Country | string? |
| Description | string? |
| Price | int |
| Photo | string? (Base64 / URL) |

| BidEntity | Type |
| --- | --- |
| Id | int (PK) |
| HouseId | int (FK → House) |
| Bidder | string |
| Amount | int |

The `DbContext` uses `NoTracking` queries by default and seeds data through `SeedData.Seed`.

## Database & Migrations

Existing migrations: `initial`, `bids`, `moreHouses`.

```bash
cd Api

# Apply migrations
dotnet ef database update

# Add a new migration after changing entities
dotnet ef migrations add <MigrationName>

# Reset the database
dotnet ef database drop
dotnet ef database update
```

## Frontend Overview

| Route | Component | Purpose |
| --- | --- | --- |
| `/` | `HouseList` | Browse all houses |
| `/house/:id` | `HouseDetail` | Details + bids |
| `/house/add` | `HouseAdd` | Create a house |
| `/house/edit/:id` | `HouseEdit` | Edit a house |

Data access goes through React Query hooks in `src/hooks` (`useFetchHouses`, `useFetchHouse`, `useAddHouse`, `useUpdateHouse`, `useDeleteHouse`, and bid equivalents). Mutations invalidate the relevant query keys and navigate on success. API validation errors are rendered by `ValidationSummary`.

## Available Scripts

From `ReactWeb/`:

| Command | Description |
| --- | --- |
| `npm run dev` | Start the Vite dev server on port 3000 |
| `npm run build` | Type-check (`tsc -b`) and build for production |
| `npm run preview` | Preview the production build |
| `npm run lint` | Run ESLint |

From `Api/`:

| Command | Description |
| --- | --- |
| `dotnet run` | Run the API |
| `dotnet watch run` | Run with hot reload |
| `dotnet build` | Build the API |

## Troubleshooting

- **CORS errors in the browser** — make sure the frontend runs on `http://localhost:3000`, or update the origin in `Api/Program.cs`.
- **`no such table: Houses`** — run `dotnet ef database update` from `Api/`.
- **Certificate / HTTPS errors** — run `dotnet dev-certs https --trust`.
- **Port 3000 already in use** — Vite uses `strictPort`, so it fails instead of picking another port. Free the port or change it (and the CORS origin).
- **Frontend can't reach the API** — verify `baseApiUrl` in `ReactWeb/src/config.ts` matches the API URL.

## License

Add your license here.
