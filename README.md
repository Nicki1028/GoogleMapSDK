# Cross-Platform Google Maps SDK for .NET

## 簡介

專為 .NET 應用程式打造的模組化 Google Maps SDK，透過 API 抽象層、Core 共用邏輯與 MVP 架構，實現 WinForms 與 WPF 的跨平台元件重用與功能擴充。

## 架構圖
<img width="1323" height="506" alt="截圖 2026-06-03 13 33 19" src="https://github.com/user-attachments/assets/cb679cdc-9fc0-4077-8f19-11696c865e7f" />

---

## 模組結構

| 模組 | 角色 |
|------|------|
| **GoogleMapSDK.API** | 主控台，定義對外服務介面（Geocoding、PlaceSearch、Direction 等） |
| **GoogleMapSDK.UI.Contract** | 介面合約庫，定義 View/Presenter 的抽象介面 |
| **GoogleMapSDK.Core** | 核心實作，實作各 Presenter 與 Overlay 邏輯 |
| **GoogleMapSDK.UI.WinForm** | WinForm 平台的 View 實作 |
| **GoogleMapSDK.UI.WPF** | WPF 平台的 View 實作 |

---

## ✨ 專案亮點

- 自行設計模組化 **Google Maps SDK**，將 Google Maps API 封裝於統一抽象層，簡化地圖功能整合。
- 採用分層架構，將 **API、Core、UI Contract** 與平台實作分離，提升系統可維護性與擴充性。
- 整合 **MVP 架構**，將 View 與 Presenter 解耦，使商業邏輯可跨不同 UI Framework 重複使用。
- 同時支援 **WinForms** 與 **WPF**，共用相同 Core 邏輯與 Presenter，降低跨平台開發成本。
- 建立可重用的 **UI Contract**（View、Presenter、Service、Overlay），提供一致的元件擴充模型。



