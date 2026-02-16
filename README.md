# FileAnalyzerWinForm

.NET Framework kullanılarak geliştirilmiş, metin tabanlı dosyaları analiz eden modüler WinForm uygulaması.

## Özellikler:
- **Kullanıcı Yönetimi:**
	- Kullanıcı giriş sistemi
	- Yeni kullanıcı oluşturma ve listeleme
- **Birden fazla metin formatını destekler (desteklenen metin formatları çoğaltılabilecek mimari ile geliştirilmiştir).**
- **Desteklenen Metin Formatları:**
	- .txt
	- docx
	- .pdf
- **Kelime Analizi:**
	- Toplam farklı kelime analizi
	- Tekrar eden kelimeler ve sayıları
		- Bağlaçlar tekrar eden kelime sayısına dahil değildir.
- **Noktalama İşaretleri Analizi:**
	- Tüm noktalama işaretleri sayılır ve her birinin kaç kez kullanıldığı raporlanır.
- **Export to Excel seçeneği ile yapılan analiz excel üzerine aktarılabilir.**
- **Hata Yönetimi ve Loglama:**
	- Alınan hatalar Logs dosyasına kaydedilir.

## Mimari:
- **Core:** Arayüzlerin bulunduğu katmandır (IFileReader,Ilogger burada bulunur).
	- **Abstractions:** IFileReader,ILogger, IExcelService gibi arayüzler burada bulunur.
	- **Enums:** Sabit veri yapıları, dosya tipleri burada tanımlanır.
	- **Extensions:** Mevcut yapılara yeni özellikler kazandıran yardımcı metodların yazıldığı alan.
- **Model:** Nesnelerin tanımlandığı katmandır (AnalysisResult burada bulunur, analiz sonuçlarını tutar).
- **Services:** Dosya ve dış kaynaklı işlemlerin yönetildiği katman.
	- **FileReaders:** Dosya okuma işlemlerinin yapıldığı sınıf. Okunması istenilen dosya formatına göre genişletilebilir.
	- **Logging:** Loglama işlemlerinin yapıldığı sınıf.
	- **FileReader:** Dosya tiplerinin analiz edildiği sınıf.
	- **ExcelService:** Analiz edilen çıktıların excel formatına aktarıldığı sınıf.
- **View:** Kullanıcı arayüzlerinin ve işlemlerinin bulunduğu sınıf.
- **Business:** İş mantığının ve hesaplamaların bulunduğu katmandır.
	

## Kullanılan Teknolojiler:
- .NET Framework 4.8
- C# Windows Form
- **NuGet paketleri:**
	- DocumentFormat.OpenXML https://github.com/dotnet/Open-XML-SDK (Word Dosyaları)
	- PdfPig https://www.nuget.org/packages/PdfPig/ (PDF Dosyaları)
	- EPPlus https://github.com/EPPlusSoftware/EPPlus (Excel Dosyaları)

## Kurulum:
- Repoyu klonlayın
	 `git clone https://github.com/Omercanonen/FileAnalyzerWinForm`
- Projeyi Visual Studio 2022 ile açın
- Gerekli NuGet paketlerini indirin
- Projeyi başlatın

## Klasör Yapısı:
```
FileAnalyzerWinForm/
├── Business/
│   ├── AuthService.cs
│   └── TextAnalyzer.cs
├── Core/
│   ├── Abstractions/
│   │   ├── IExcelService.cs
│   │   ├── IFileReader.cs
│   │   └── ILogger.cs
│   ├── Enums/
│   │   └── FileType.cs
│   └── Extensions/
│       └── EnumExtensions.cs
├── Model/
│   ├── AnalysisResult.cs
│   └── User.cs
├── Services/
│   ├── FileReaders/
│   │   ├── DocxFileReader.cs
│   │   ├── PdfFileReader.cs
│   │   └── TxtFileReader.cs
│   ├── Logging/
│   │   └── FileLogger.cs
│   ├── ExcelService.cs
│   └── FileReader.cs
├── View/
│   ├── Pages/
│   │   ├── AddAccount.cs
│   │   └── FileAnalyzer.cs
│   ├── Login.cs
│   └── MainForm.cs
└── Program.cs
```
