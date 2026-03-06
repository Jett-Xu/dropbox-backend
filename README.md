# Dropbox Backend

這是一個基於 **.NET 10 Web API** 建置的後端專案，使用 **Entity Framework Core (EF Core)** 並整合 **PostgreSQL** 資料庫。這個專案作為類似 Dropbox 的雲端儲存應用程式的後端服務，提供對資料夾 (Folders)、最近使用的檔案 (Recent Files) 以及儲存空間狀態 (Storage Info) 的操作。

## 功能特色

- **RESTful 介面**：使用 ASP.NET Core 實作標準的 Web API。
- **PostgreSQL 整合**：透過 Npgsql.EntityFrameworkCore.PostgreSQL 連接實體資料庫。
- **資料庫初始化與種子資料**：利用 EF Core 的 `HasData` 方法，自動部署和載入初始測試資料。
- **依賴注入**：良好分層結構，以提升維護和擴充性。

## 專案資料夾架構與說明

本專案採用經典的 MVC 架構，以下是每個主要資料夾的意義與職責範圍：

- **`Controllers/` (控制器)**
  - **意義**：這裡是應用程式的「進入點」。負責接收前端 (Client) 的 HTTP 請求 (GET, POST, PUT, DELETE)，叫用後端邏輯與資料庫，並將結果回傳給用戶端。
  - **內容**：包含 `FoldersController`、`RecentFilesController`、`StorageController`、`NavigationController` 及 `UserProfileController`。

- **`Models/` (資料實體模型)**
  - **意義**：定義了應用程式中核心的資料結構與欄位。這些模型同時也會透過 Entity Framework Core 映射（對應）到 PostgreSQL 資料庫的真實在資料表 (Tables) 中。
  - **內容**：包含 `Folder.cs`、`RecentFile.cs`、`StorageInfo.cs`、`SharedUser.cs`、`NavigationItem.cs` 及 `UserProfile.cs`。

- **`Data/` (資料存放區/資料庫上下文)**
  - **意義**：扮演應用程式與資料庫溝通的橋樑。負責管理實體模型和資料庫之間的存取與變更追蹤。這裡同時設定了資料庫建立時的「種子資料 (Seed Data)」。
  - **內容**：包含 `AppDbContext.cs`。

- **`Properties/` (專案設定)**
  - **意義**：包含 .NET 專案的啟動設定檔。
  - **內容**：`launchSettings.json`，其中設定了專案在不同環境 (例如 Development) 啟動時所綁定的 Port 以及啟動的環境變數。

- **`Migrations/` (資料庫遷移記錄)** _(執行 `dotnet ef migrations add` 後產生)_
  - **意義**：Entity Framework Core 的資料庫版本控制。當你的 Models 結構變更時（例如新增欄位），EF Core 會在這裡生成 C# 檔案來紀錄這些變更，以利後續更新到實體的 PostgreSQL 資料庫結構。

## 環境設定與執行

### 1. 先決條件

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (用於運行 PostgreSQL)
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef`)

### 2. 資料庫環境建立 (Docker)

本專案配置了 `docker-compose.yml` 來快速啟動 PostgreSQL 16 測試資料庫環境。連線資訊已於 `appsettings.Development.json` 中配置妥當。

請確定電腦已安裝並開啟 Docker，於專案根目錄終端機執行：

```bash
docker compose up -d
```

### 3. 執行資料庫遷移與資料庫建立

當 Docker 容器啟動後，請執行以下 Entity Framework 指令來建立資料表和初始化預設的測試資料（種子資料）：

```bash
dotnet ef database update
```

### 4. 啟動專案

資料準備完畢後，即可啟動 .NET 後端：

```bash
dotnet run
```

專案啟動後，可以透過瀏覽器訪問 Scalar API 文件介面查看和測試所有 API 端點 (通常路徑為 `http://localhost:<port>/scalar/v1`)。

## 可用 API 列表

- **Folders (資料夾)**
  - `GET /api/Folders` - 取得所有資料夾
  - `GET /api/Folders/{id}` - 取得特定資料夾
  - `POST /api/Folders` - 新增資料夾
  - `PUT /api/Folders/{id}` - 更新資料夾
  - `DELETE /api/Folders/{id}` - 刪除資料夾
- **RecentFiles (最近檔案)**
  - `GET /api/RecentFiles` - 取得所有最近檔案
  - `GET /api/RecentFiles/{id}` - 取得特定檔案
  - `POST /api/RecentFiles` - 新增檔案
  - `PUT /api/RecentFiles/{id}` - 更新檔案
  - `DELETE /api/RecentFiles/{id}` - 刪除檔案
- **Storage (儲存空間)**
  - `GET /api/Storage` - 取得儲存空間資訊
  - `PUT /api/Storage` - 更新儲存空間資訊
- **Navigation (側邊選單)**
  - `GET /api/Navigation` - 取得所有左側選單項目
- **UserProfile (使用者資訊)**
  - `GET /api/UserProfile` - 取得目前使用者資訊
  - `PUT /api/UserProfile` - 更新使用者資訊
