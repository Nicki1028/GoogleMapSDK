### 架構圖：
<img width="1323" height="506" alt="截圖 2026-06-03 13 33 19" src="https://github.com/user-attachments/assets/cb679cdc-9fc0-4077-8f19-11696c865e7f" />

這是一個採用 MVP（Model-View-Presenter）+ 分層架構 的 Google Map SDK，分為以下幾個模組：

---

### 模組結構

| 模組 | 角色 |
|------|------|
| **GoogleMapSDK.API** | 主控台，定義對外服務介面（Geocoding、PlaceSearch、Direction 等） |
| **GoogleMapSDK.UI.Contract** | 介面合約庫，定義 View/Presenter 的抽象介面 |
| **GoogleMapSDK.Core** | 核心實作，實作各 Presenter 與 Overlay 邏輯 |
| **GoogleMapSDK.UI.WinForm** | WinForm 平台的 View 實作 |
| **GoogleMapSDK.UI.WPF** | WPF 平台的 View 實作 |

---

### 核心設計概念

1. **Contract 層隔離**：View 與 Presenter 都依賴抽象介面，互不直接相依，便於測試與替換 UI 平台。

2. **多平台共用 Core**：WinForm 和 WPF 共用同一套 Presenter 邏輯，只需各自實作 View。

3. **Overlay 機制**：透過 `IOverlay / IOverlayService` 抽象地圖覆蓋層，`MapOverlay` 為實作。

4. **功能群組清晰**：依 AutoComplete、Review、Photo 三大功能各自有獨立的 View/Presenter。

---

