# Dropbox Backend

這是一個基於 **.NET 10 Web API** 建置的後端專案，使用 **Entity Framework Core (EF Core)** 並整合 **PostgreSQL** 資料庫。這個專案作為類似 Dropbox 的雲端儲存應用程式的後端服務，提供對資料夾 (Folders)、最近使用的檔案 (Recent Files) 以及儲存空間狀態 (Storage Info) 的操作。

## 功能特色

- **RESTful 介面**：使用 ASP.NET Core 實作標準的 Web API。
- **PostgreSQL 整合**：透過 Npgsql.EntityFrameworkCore.PostgreSQL 連接實體資料庫。
- **外部資料 JSON 種子化**：啟動時自動讀取外部的 `seed-data.json` 載入初始測試資料，避免 `AppDbContext` 變得冗長難以維護。
- **DDD / Clean Architecture**：遵循領域驅動設計與 Clean Architecture，實作嚴謹的單向依賴分層結構，從根本上解決高耦合問題。

## 專案架構 (單向依賴: UI -> Application -> Domain -> Infrastructure)

- **`Controllers/` (展示層 / WebAPI)**
  - **意義**：應用程式的「進入點」。只有一個極度單純的任務：接收 HTTP 請求 (GET, POST, PUT, DELETE)，將工作委託給 Application 層的 Services，然後回傳 DTO 給前端。絕對不會在此存取資料庫。
  - **內容**：包含 `FoldersController`、`RecentFilesController` 等。

- **`Application/` (應用層)**
  - **意義**：核心系統功能與使用案例。
  - **內容**：
    - `DTOs/` (Data Transfer Objects)：與外部交換資料的格式合約，每一種實體皆有獨立檔案 (如 `FolderDto.cs`) 歸納管理。
    - `Interfaces/`：包含了業務權責操作的介面合約 (如 `IFolderService` 等)，與定義基礎設施實作的合約 (如 `IFolderRepository` 等)。
    - `Services/`：核心邏輯的實作，依循單一職責原則獨立成多個檔案 (如 `FolderService.cs` 等)，在這裡完成資料交換並呼叫 `IRepository` 從 DB 獲取資料。

- **`Domain/` (領域層)**
  - **意義**：系統的核心，包含商業邏輯與最小資料單位，保持純淨，不會依賴任何框架或資料庫的細節。
  - **內容**：包含 `Entities/` (如獨立成檔的 `Folder.cs`, `SharedUser.cs`, `RecentFile.cs` 等)。

- **`Infrastructure/` (基礎設施層)**
  - **意義**：負責所有外部依賴工作，例如資料庫實作。
  - **內容**：
    - `Data/AppDbContext.cs`：EF Core 與資料庫溝通的媒介。
    - `Repositories/`：實踐 `Application/Interfaces` 裡頭設定的 `IRepository` 介面，依主體獨立封裝具體的資料庫操作 (如 `FolderRepository.cs` 等)。
    - `Seed/DbSeeder.cs` 與 `seed-data.json`：專案啟動時自動運行的資料庫起始資料設定機制。

- **`Migrations/` (資料庫遷移記錄)**
  - Entity Framework Core 的資料庫版本控制。

## 環境設定與執行

### 1. 先決條件

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (用於運行 PostgreSQL)
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef`)

### 2. 資料庫環境建立 (Docker)

本專案配置了 `docker-compose.yml` 來快速啟動 PostgreSQL 16。
請確定電腦已安裝並開啟 Docker，於專案根目錄終端機執行：

```bash
docker compose up -d
```

### 3. 資料庫更新與套用

當 Docker 容器啟動後，請執行以下 Entity Framework 指令來建立資料表：

```bash
dotnet ef database update
```

_(注意：預設假資料已經不再寫死於 Migration 當中，而是改由應用程式啟動時從 `seed-data.json` 自動進行 Seed。)_

### 4. 啟動專案

資料準備完畢後，即可啟動 .NET 後端：

```bash
dotnet run
```

專案啟動後（第一次啟動時，若資料庫為空，系統會自動載入 `seed-data.json` 裡的預設資料），可以透過瀏覽器訪問 Scalar API 文件介面查看和測試所有 API 端點 (通常路徑為 `http://localhost:<port>/scalar/v1`)。

## 可用 API 列表

- **Folders (資料夾)**
  - `GET /api/Folders` - 取得所有資料夾
  - `DELETE /api/Folders/{id}` - 刪除資料夾
- **RecentFiles (最近檔案)**
  - `GET /api/RecentFiles` - 取得所有最近檔案
  - `DELETE /api/RecentFiles/{id}` - 刪除檔案
- **Storage (儲存空間)**
  - `GET /api/Storage` - 取得儲存空間資訊
- **Navigation (側邊選單)**
  - `GET /api/Navigation` - 取得所有左側選單項目
- **UserProfile (使用者資訊)**
  - `GET /api/UserProfile` - 取得目前使用者資訊
