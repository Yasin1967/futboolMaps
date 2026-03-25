# ⚽ FootballMaps Türkiye
Türkiye'deki futbol takımlarını ve şehir bilgilerini interaktif bir harita üzerinde sunan modern bir web uygulaması.

🚀 **Proje Durumu: Hafta 5 Tamamlandı**
Proje, 10 haftalık geliştirme planının ilk 5 haftasını başarıyla geride bırakmış; temel altyapı, veritabanı şeması ve premium harita arayüzü modülleri devreye alınmıştır.

---

## 🛠️ Teknik Özellikler
- **Backend:** .NET 8, ASP.NET Core MVC, EF Core 
- **Veritabanı:** Microsoft SQL Server / LocalDB
- **Harita & GIS:** Leaflet.js & OpenStreetMap (CartoDB Dark Matter)
- **Frontend:** Bootstrap 5, CSS3, Vanilla JavaScript, AJAX

---

## 📂 Proje Dokümantasyonu (Haftalık Raporlar)
Her haftanın detaylı raporuna aşağıdaki bağlantılardan ulaşabilirsiniz:

| Hafta | Rapor İçeriği | Format |
| :--- | :--- | :--- |
| **Hafta 1** | [Proje Kurulumu & Veritabanı Giriş](./Raporlar/hafta-1-raporu.md) | .md |
| **Hafta 2** | [Veritabanı Altyapısı & EF Core Yapılandırması](./Raporlar/hafta-2-raporu.md) | .md |
| **Hafta 3** | [Veri Seeding & Takım Asset Yönetimi](./Raporlar/hafta-3-raporu.md) | .md |
| **Hafta 4** | [AJAX API & Arka Plan Aracı Mantığı](./Raporlar/hafta-4-raporu.md) | .md |
| **Hafta 5** | [Premium Harita Entegrasyonu & Mobil Tasarım](./Raporlar/hafta-5-raporu.md) | .md |
| **Hafta 6** | [6. hafta hedefi olan şehir detay sayfasının dashboard mimarisi ile tasarlanması ve Bootstrap entegrasyonu başarıyla tamamlanmıştır.](./Raporlar/hafta-6-raporu.md) | .md |

---

## 👨‍💻 Geliştirme Notları (Hafta 5)
Hafta 5 kapsamında projenin görsel ve fonksiyonel kalitesini artıracak şu adımlar atılmıştır:
- **Premium Arayüz:** Navigasyon ve harita tasarımı modern bir karanlık temaya taşındı.
- **Harita Entegrasyonu:** Gerçek coğrafi koordinatlar (Lat/Lon) ile Leaflet.js entegre edildi.
- **Mobil Uyumluluk:** Responsive tasarım ile telefonlarda dikey düzen optimize edildi.

---

## 🚀 Çalıştırma Talimatları
1. Depoyu klonlayın.
2. `dotnet ef database update` ile veritabanını oluşturun.
3. `dotnet run` ile çalıştırın.
