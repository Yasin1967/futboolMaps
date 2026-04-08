# ⚽ FootballMaps Türkiye
Türkiye'deki futbol takımlarını ve şehir bilgilerini interaktif bir harita üzerinde sunan modern bir web uygulaması.

🚀 **Proje Durumu: Hafta 7 Tamamlandı**
Proje, 10 haftalık geliştirme planının 7. haftasını başarıyla geride bırakmıştır. Temel altyapı, veritabanı, premium harita arayüzü, şehir/takım detay sayfaları ve admin paneli modülleri devreye alınmıştır.

---

## 🛠️ Teknik Özellikler
- **Backend:** .NET 8, ASP.NET Core MVC, EF Core
- **Kimlik Doğrulama:** ASP.NET Identity (Role-Based Authorization)
- **Veritabanı:** Microsoft SQL Server / LocalDB
- **Harita & GIS:** Leaflet.js & OpenStreetMap (CartoDB Dark Matter)
- **Frontend:** Bootstrap 5, CSS3, Vanilla JavaScript, AJAX

---

## 🗺️ Öne Çıkan Özellikler
- 🗺️ **İnteraktif Harita:** Leaflet.js ile gerçek koordinatlar üzerinde şehir işaretçileri
- 🎨 **Premium Tema:** Glassmorphism efektli karanlık mod arayüz
- 🏙️ **Şehir Detay Sayfası:** Tarihçe, kültür, yemek ve doğal güzellikler kartları
- ⚽ **Takım Detay Sayfası:** Logo, kuruluş yılı, tarihçe ve başarılar
- 🔐 **Admin Paneli:** Güvenli giriş sistemi ile şehir, takım ve lig CRUD yönetimi
- 📤 **Logo Yükleme:** Admin panelinden takım logosu dosya yükleme
- 📍 **Otomatik Koordinat:** 81 il için plaka koduna göre otomatik harita konumlandırma
- 📱 **Mobil Uyumluluk:** Responsive tasarım ile tüm cihazlarda kusursuz deneyim

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
| **Hafta 6** | [Şehir Detay Sayfası & Dashboard Mimarisi](./Raporlar/hafta-6-raporu.md) | .md |
| **Hafta 7** | [Admin Paneli & Kimlik Doğrulama Sistemi](./Raporlar/hafta-7-raporu.md) | .md |

---

## 👨‍💻 Geliştirme Notları (Hafta 7)
Hafta 7 kapsamında projeye güvenlik ve veri yönetim katmanı eklenmiştir:
- **ASP.NET Identity:** Rol tabanlı yetkilendirme sistemi entegre edildi (Admin rolü).
- **Admin Paneli:** Şehir, takım ve lig kayıtları için tam CRUD (Oluştur, Oku, Güncelle, Sil) desteği getirildi.
- **Giriş Sistemi:** Glassmorphism efektli Login sayfası ve otomatik admin kullanıcı oluşturma.
- **Logo Yükleme:** Takım oluşturma/düzenlemede dosya yükleme sistemi eklendi.
- **Koordinat Yardımcısı:** 81 ilin koordinatlarını içeren `CityCoordinateHelper` ile yeni eklenen şehirler otomatik olarak haritaya yerleştiriliyor.
- **Takım Detay:** Takım bilgilerini detaylı gösteren yeni sayfa eklendi.

---

