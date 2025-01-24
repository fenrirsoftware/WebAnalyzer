using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.SearchConsole.v1;
using Google.Apis.SearchConsole.v1.Data;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Font = System.Drawing.Font;
using Color = System.Drawing.Color;

namespace DXApplication6
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] Uygulama başlatıldı.\n");
        }

        XtraUserControl CreateUserControl(string text)
        {
            XtraUserControl result = new XtraUserControl();
            result.Name = text.ToLower() + "UserControl";
            result.Text = text;
            LabelControl label = new LabelControl();
            label.Parent = result;
            label.Appearance.Font = new Font("Tahoma", 25.25F);
            label.Appearance.ForeColor = Color.Gray;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.AutoSizeMode = LabelAutoSizeMode.None;
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            label.Text = text;
            return result;
        }

       
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalyzeDomain(richTextBox1, checkedListBoxControl1);
        }

        string gunsay;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] scopes = { SearchConsoleService.Scope.Webmasters };
            string credentialsPath = "credentials.json";  //dosyayı sen koyacan unutma len 

            try
            {
                UserCredential credential;
                using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        scopes,
                        "user",
                        System.Threading.CancellationToken.None).Result;
                }

                var service = new SearchConsoleService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Search Console API C#"
                });

                var sitesResponse = service.Sites.List().Execute();
                if (sitesResponse.SiteEntry == null || sitesResponse.SiteEntry.Count == 0)
                {
                    MessageBox.Show("Kullanıcının erişim izni olan hiçbir site bulunamadı.");
                    return;
                }

                foreach (var site in sitesResponse.SiteEntry)
                {
                    checkedListBoxControl1.Items.Add(site.SiteUrl);
                }
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"API Hatası: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || checkedListBoxControl1.CheckedItems.Count != 1 || (comboBox2.SelectedItem == null || string.IsNullOrWhiteSpace(comboBox2.Text)))
            {
                AppendToRichTextBox(richTextBox1, "[WARNING] Gerekli alanlar doldurulmadı.", true);
                MessageBox.Show("Lütfen gerekli alanları doldurunuz.");
                return;
            }

            AppendToRichTextBox(richTextBox1, "[INFO] Uygulama başlatıldı.", true);

            string[] scopes = { SearchConsoleService.Scope.Webmasters };
            string credentialsPath = "credentials.json";

            try
            {
                AppendToRichTextBox(richTextBox1, "[INFO] Kimlik doğrulama için gerekli dosya okunuyor.", true);

                UserCredential credential;
                using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        scopes,
                        "user",
                        System.Threading.CancellationToken.None).Result;
                }

                AppendToRichTextBox(richTextBox1, "[INFO] API hizmeti başlatılıyor.", true);

                var service = new SearchConsoleService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Search Console API C# Example"
                });

                if (checkedListBoxControl1.CheckedItems.Count != 1)
                {
                    AppendToRichTextBox(richTextBox1, "[WARNING] Birden fazla site seçildi.", true);
                    MessageBox.Show("Lütfen yalnızca bir site seçin.");
                    return;
                }

                string selectedSite = checkedListBoxControl1.CheckedItems[0].ToString();
                AppendToRichTextBox(richTextBox1, $"[INFO] Seçilen site: {selectedSite}", true);

                string gunsay = comboBox2.SelectedItem.ToString();
                int gunSayisi = Convert.ToInt32(gunsay);

                var request = new SearchAnalyticsQueryRequest
                {
                    StartDate = DateTime.UtcNow.AddDays(-gunSayisi).ToString("yyyy-MM-dd"),
                    EndDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                    Dimensions = new[] { "query" }
                };

                AppendToRichTextBox(richTextBox1, $"[INFO] Performans verileri sorgulanıyor: {selectedSite}", true);

                var response = service.Searchanalytics.Query(request, selectedSite).Execute();

                string performanceData = "";
                if (response.Rows != null)
                {
                    foreach (var row in response.Rows)
                    {
                        performanceData += $"Sorgu: {row.Keys[0]}, Tıklamalar: {row.Clicks}, Gösterimler: {row.Impressions}\n";
                    }
                    AppendToRichTextBox(richTextBox1, "[INFO] Performans verileri başarıyla alındı.", true);
                }
                else
                {
                    AppendToRichTextBox(richTextBox1, "[WARNING] Seçilen site için veri bulunamadı.", true);
                }

             
                var domainResults = AnalyzeDomain(richTextBox1, checkedListBoxControl1);

                if (domainResults.domain != null) 
                {
                    var (domain, domainAsEntered, mozLinks, mozPA, mozDA, mozRank, majesticLinks, majesticRefDomains, majesticTF) = domainResults;

                    string domainFileName = $"domain_analysis_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    string domainFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), domainFileName);
                    CreateDomainExcelFile(domainFilePath, domain, domainAsEntered, mozLinks, mozPA, mozDA, mozRank, majesticLinks, majesticRefDomains, majesticTF);

                    // Create Excel file for Google data
                    string performanceFileName = $"google_performance_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    string performanceFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), performanceFileName);
                    CreatePerformanceExcelFile(performanceFilePath, performanceData);

                    AppendToRichTextBox(richTextBox1, $"[INFO] Domain analizi Excel dosyası oluşturuldu: {domainFileName}", true);
                    AppendToRichTextBox(richTextBox1, $"[INFO] Google performans verileri Excel dosyası oluşturuldu: {performanceFileName}", true);
                    MessageBox.Show($"Domain analizi ve Google performans verileri Excel dosyaları oluşturuldu.", "Dosyalar Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AppendToRichTextBox(richTextBox1, "[ERROR] Domain analizi başarısız oldu.", false);
                }
            }
            catch (Google.GoogleApiException ex)
            {
                AppendToRichTextBox(richTextBox1, $"[ERROR] API Hatası: {ex.Message}", false);
                MessageBox.Show($"API Hatası: {ex.Message}");
            }
            catch (Exception ex)
            {
                AppendToRichTextBox(richTextBox1, $"[ERROR] Beklenmeyen bir hata oluştu: {ex.Message}", false);
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}");
            }
        }

        private void CreateDomainExcelFile(string filePath, string domain, string domainAsEntered, string mozLinks, string mozPA, string mozDA, string mozRank, string majesticLinks, string majesticRefDomains, string majesticTF)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Add headers
                Row headerRow = new Row();
                headerRow.Append(
                    ConstructCell("Metric"),
                    ConstructCell("Value")
                );
                sheetData.AppendChild(headerRow);

                // Add domain metrics
                Cell[] cells =
                {
                    ConstructCell("Domain"), ConstructCell(domain),
                    ConstructCell("Domain As Entered"), ConstructCell(domainAsEntered),
                    ConstructCell("Moz Links"), ConstructCell(mozLinks),
                    ConstructCell("Moz PA"), ConstructCell(mozPA),
                    ConstructCell("Moz DA"), ConstructCell(mozDA),
                    ConstructCell("Moz Rank"), ConstructCell(mozRank),
                    ConstructCell("Majestic Links"), ConstructCell(majesticLinks),
                    ConstructCell("Majestic Ref Domains"), ConstructCell(majesticRefDomains),
                    ConstructCell("Majestic TF"), ConstructCell(majesticTF)
                };

                for (int i = 0; i < cells.Length; i += 2)
                {
                    Row newRow = new Row();
                    newRow.Append(cells[i], cells[i + 1]);
                    sheetData.AppendChild(newRow);
                }

                workbookPart.Workbook.Save();
            }
        }

        private void CreatePerformanceExcelFile(string filePath, string performanceData)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Add headers
                Row headerRow = new Row();
                headerRow.Append(
                    ConstructCell("Query"),
                    ConstructCell("Clicks"),
                    ConstructCell("Impressions")
                );
                sheetData.AppendChild(headerRow);

                // Add Google Search Console data
                if (!string.IsNullOrEmpty(performanceData))
                {
                    var performanceRows = performanceData.Split('\n');
                    foreach (var rowData in performanceRows)
                    {
                        if (!string.IsNullOrEmpty(rowData))
                        {
                            var cellsData = rowData.Split(new[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                            if (cellsData.Length == 6) // 
                            {
                                Row perfRow = new Row();
                                perfRow.Append(
                                    ConstructCell(cellsData[1].Trim()), // Query
                                    ConstructCell(cellsData[3].Trim()), // Clicks
                                    ConstructCell(cellsData[5].Trim())  // Impressions
                                );
                                sheetData.AppendChild(perfRow);
                            }
                        }
                    }
                }

                workbookPart.Workbook.Save();
            }
        }

        private static Cell ConstructCell(string value)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = CellValues.String
            };
        }

        public static (string domain, string domainAsEntered, string mozLinks, string mozPA, string mozDA, string mozRank, string majesticLinks, string majesticRefDomains, string majesticTF) AnalyzeDomain(RichTextBox richTextBox1, CheckedListBoxControl checkedListBox1)
        {
            try
            {
                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    AppendToRichTextBox(richTextBox1, "[ERROR] Lütfen analiz için bir domain seçin.", false);
                    return (null, null, null, null, null, null, null, null, null);
                }

                var selectedDomain = checkedListBox1.CheckedItems[0].ToString();

                if (Uri.TryCreate(selectedDomain, UriKind.Absolute, out var uri))
                {
                    selectedDomain = uri.Host;
                    if (!selectedDomain.StartsWith("www."))
                    {
                        selectedDomain = "www." + selectedDomain;
                    }
                }
                else
                {
                    AppendToRichTextBox(richTextBox1, "[ERROR] Geçersiz bir domain formatı.", false);
                    return (null, null, null, null, null, null, null, null, null);
                }

                AppendToRichTextBox(richTextBox1, $"[INFO] Düzeltilmiş domain: {selectedDomain}", true);

                var requestUri = $"https://domain-metrics-check.p.rapidapi.com/domain-metrics/{selectedDomain}/";

                AppendToRichTextBox(richTextBox1, "[INFO] HTTP istemcisi oluşturuluyor...", true);

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri),
                    Headers =
                    {
                        { "x-rapidapi-key", "api key" },
                        { "x-rapidapi-host", "domain-metrics-check.p.rapidapi.com" },
                    },
                };

                AppendToRichTextBox(richTextBox1, "[INFO] HTTP isteği gönderiliyor...", true);

                var response = client.Send(request);
                response.EnsureSuccessStatusCode();

                AppendToRichTextBox(richTextBox1, "[INFO] HTTP isteği başarılı bir şekilde gönderildi.", true);

                var body = response.Content.ReadAsStringAsync().Result;

                AppendToRichTextBox(richTextBox1, "[INFO] JSON yanıt işleniyor...", true);

                var jsonDocument = JsonDocument.Parse(body);
                var root = jsonDocument.RootElement;

                string domain = root.GetProperty("domain").GetString();
                string domainAsEntered = root.GetProperty("domainAsEntered").GetString();
                string mozLinks = root.GetProperty("mozLinks").GetString();
                string mozPA = root.GetProperty("mozPA").GetString();
                string mozDA = root.GetProperty("mozDA").GetString();
                string mozRank = root.GetProperty("mozRank").GetString();
                string majesticLinks = root.GetProperty("majesticLinks").GetString();
                string majesticRefDomains = root.GetProperty("majesticRefDomains").GetString();
                string majesticTF = root.GetProperty("majesticTF").GetString();

                var message = $"Domain: {domain}\n" +
                              $"Domain As Entered: {domainAsEntered}\n" +
                              $"Moz Links: {mozLinks}\n" +
                              $"Moz PA: {mozPA}\n" +
                              $"Moz DA: {mozDA}\n" +
                              $"Moz Rank: {mozRank}\n" +
                              $"Majestic Links: {majesticLinks}\n" +
                              $"Majestic Ref Domains: {majesticRefDomains}\n" +
                              $"Majestic TF: {majesticTF}\n";

                AppendToRichTextBox(richTextBox1, "[SUCCESS] Analiz tamamlandı. Sonuçlar alındı.", true);

                MessageBox.Show(message, "Domain Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return (domain, domainAsEntered, mozLinks, mozPA, mozDA, mozRank, majesticLinks, majesticRefDomains, majesticTF);
            }
            catch (Exception ex)
            {
                AppendToRichTextBox(richTextBox1, $"[ERROR] Bir hata oluştu: {ex.Message}", false);
                return (null, null, null, null, null, null, null, null, null);
            }
        }

        private static void AppendToRichTextBox(RichTextBox richTextBox, string message, bool isInfo)
        {
            Color color;

            if (message.StartsWith("[INFO]"))
                color = Color.Blue;
            else if (message.StartsWith("[WARNING]"))
                color = Color.Orange;
            else if (message.StartsWith("[ERROR]"))
                color = Color.Red;
            else if (message.StartsWith("[SUCCESS]"))
                color = Color.Green;
            else
                color = Color.Black;

            string timestamp = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ";
            string formattedMessage = timestamp + message;

            int start = richTextBox.TextLength;
            richTextBox.AppendText(formattedMessage + Environment.NewLine);
            richTextBox.SelectionStart = start;
            richTextBox.SelectionLength = formattedMessage.Length;
            richTextBox.SelectionColor = color;
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionColor = richTextBox.ForeColor;
        }
    }
}