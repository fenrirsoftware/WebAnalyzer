# Google Search Console ve DA/PA API Verilerini Excel'e Aktarma

Bu proje, Google Search Console ve DA (Domain Authority) / PA (Page Authority) API'lerinden veri alarak bu verileri Excel dosyasına aktaran bir uygulamadır.

## Google Search Console Nedir?

Google Search Console, web sitesi sahiplerinin Google arama sonuçlarındaki performanslarını izlemelerine, optimize etmelerine ve sorunlarını çözmelerine yardımcı olan ücretsiz bir araçtır. Bu araç sayesinde:

- Web sitenizin Google'daki görünürlüğünü artırabilirsiniz.
- Tıklama oranlarını, konum bilgilerini ve diğer SEO verilerini analiz edebilirsiniz.
- Hatalı sayfaları ve indeksleme problemlerini tespit edebilirsiniz.

Daha fazla bilgi için [Google Search Console](https://search.google.com/search-console) sayfasını ziyaret edebilirsiniz.

## DA/PA Nedir?

Domain Authority (DA) ve Page Authority (PA), Moz tarafından geliştirilen, bir alan adının veya belirli bir sayfanın arama motorlarındaki sıralama potansiyelini değerlendiren metriklerdir:

- **Domain Authority (DA)**: Bir alan adının genel otoritesini ifade eder. 0 ile 100 arasında bir puan alır. Daha yüksek bir puan, daha iyi bir sıralama potansiyelini gösterir.
- **Page Authority (PA)**: Belirli bir web sayfasının sıralama potansiyelini ölçer. DA gibi 0 ile 100 arasında bir puan alır.

Bu metrikler, SEO çalışmalarında rakip analizi yapmak ve web sitesi performansını değerlendirmek için kullanılır.

Daha fazla bilgi için [Moz Web Sitesi](https://moz.com) adresine göz atabilirsiniz.

## DevExpress Gereksinimi

Bu proje, kullanıcı arayüzü ve veri yönetimi için **DevExpress** bileşenlerini kullanmaktadır. DevExpress, gelişmiş bir UI/UX deneyimi sunan, yüksek performanslı ve özelleştirilebilir araç setidir.

### DevExpress Avantajları:

- Güçlü grid ve veri görselleştirme araçları.
- Kullanıcı dostu ve özelleştirilebilir arayüz bileşenleri.
- .NET Framework ile tam uyumluluk.

DevExpress bileşenlerini kullanmak için [DevExpress Web Sitesi](https://www.devexpress.com/) üzerinden gerekli lisans ve yüklemeleri yapabilirsiniz.

## Proje Görselleri

![Proje Ekran Görüntüsü](/project_screenshot.png)

## Kullanım

1. Gerekli API anahtarlarını alın:
   - **Google Search Console API**: [Google Search Console API Documentation](https://developers.google.com/webmaster-tools/search-console-api)
   - **Moz API**: [Moz API Documentation](https://moz.com/products/api)

2. Projeyi yerel ortamınıza klonlayın:
   ```bash
   git clone https://github.com/ozhanyildirim/Google-Search-Console-DA-PA-API.git
