
using AutoMapper;

using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Controls;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using WpfApp3.Models;
using Spire.Pdf;
using PDFFilePrint;
using static WpfApp3.Components.Customer;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WpfApp3.Components
{
    public class StudentCMPBase : ComponentBase
    {
        [Parameter]
        public List<string> ListOfString { get; set; }
        //[ParameterAttribute]
        //public string? ChildData { get; set; } 
        [Parameter] public EventCallback<StudentModel> EventCallBackProperty { get; set; }
        public StudentModel StudentModelObj { get; set; } = new StudentModel();

        //[Inject]
        //public IMapper Mapper { get; set; }
        public async Task GQLAsync()
        {
            GraphQLHttpClient _graphqlClient =
               new GraphQLHttpClient("https://graphqlv2.jmmtest.xyz/graphql", new NewtonsoftJsonSerializer());
            _graphqlClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjllODJhOGJiLTUwNWYtNGYwNS04Nzc5LWNkNjlmNmMwYTNjMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsInRlbmFudCI6Imh5c2FiYXQiLCJleHAiOjE2NTkzNTUxODksImlzcyI6Imh0dHBzOi8vZ3JhcGhxbC5qbW10ZXN0Lnh5eiIsImF1ZCI6Imh0dHBzOi8vZ2FycGhxbC5qbW10ZXN0Lnh5eiJ9.H21eSWeb54lgVTC6f73LC7fQen6CMxVhxzd_xQVdtBQ");

            //    GraphQLRequest _fetchCountriesQuery = new GraphQLRequest
            //    {
            //        Query = @"
            //                query {
            //                  customers {
            //                    nodes{
            //                      nameEnglish 
            //                      contact
            //                    }
            //                  }
            //                }
            //"
            //    };
            GraphQLRequest _fetchCountriesQuery = new GraphQLRequest
            {
                Query = @"
                        query{
                            myPermissions
                        }
                "
            };

            var fetchQuery = await _graphqlClient.SendQueryAsync<JsonObject>(_fetchCountriesQuery);
        }



        protected async Task HandleValidSubmit()
        {
            var obj = StudentModelObj;
            await GQLAsync();
            await EventCallBackProperty.InvokeAsync(StudentModelObj);
        }


     public void evo()
        {
            
        }
        public void htmlrenderBY_PDFSharp()
        {//pdfsharp htmlrender working with only A4


            PDF_FILE_PRINT.f2();
            return;

            //Customer.asd();
            //return;

            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Encoding srcEncoding = Encoding.GetEncoding(1251);
            //var config = new PdfGenerateConfig();
            //config.PageOrientation = PageOrientation.Landscape;
            //config.ManualPageSize = new PdfSharp.Drawing.XSize(572, 226);

            //string html = $"";
            //PdfSharp.Pdf.PdfDocument pdfDoc = PdfGenerator.GeneratePdf(" <img src='data:image/jpeg;base64,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'/>" +
            //    "<h1>safasd</h1>", config);
            //pdfDoc.Save("document.pdf");
            //PdfFilePrinter printer = new PdfFilePrinter("document.pdf","Microsoft Print to PDF");
            //PdfFilePrinter.AdobeReaderPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";
            //printer.Print();


            //var doc = new  Spire.Pdf.PdfDocument();
            //doc.LoadFromFile("document.pdf");

            //// Print all pages of a document using the default printer
            //doc.Print();

            //PdfFilePrinter pdfFilePrinter = new PdfFilePrinter("document.pdf", "Microsoft Print to PDF");
            //pdfFilePrinter.Print();
            //PrintDialog pDialog = new PrintDialog();
            //PrintDocument printDoc = new PrintDocument();
            //printDoc.

            //printDoc.DocumentName = ("document.pdf");

            ////if (pDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDoc.PrinterSettings = pDialog.PrinterSettings;
            //    pDialog.Document = printDoc;

            //    var settingsValid = printDoc.PrinterSettings.IsValid;
            //}
            //if (settingsValid)
            //{
            //    PrintPreviewDialog p = new PrintPreviewDialog();
            //    p.Document = printDoc;
            //    try
            //    {
            //        var r = p.ShowDialog();
            //        printDoc.Print();
            //    }
            //    }
        }

        public void PSPDFKitPrint()
        {
            //Sdk.InitializeTrial();
            //var fileProvider = new FileDataProvider("Sample.pdf");
            //var document = new Document(fileProvider);
            //var dc=document.GetPage(0);
            //var dc2=dc.GetTextLines();

            //List<string> asd= new List<string>();
            //foreach (var item in dc2)
            //{
            //    if (item.GetText().Contains("d with a trial vers"))
            //    {
            //        dc2.Remove(item);
            //        break;
            //    }

            //    //asd.Add(item.GetText());
            //    //var x= item.GetText();
            //}
            //document.Save(new DocumentSaveOptions());
            //var x2= 9;

        }
        //public void iron()
        //{
        //    var Renderer = new IronPdf.ChromePdfRenderer();
        //    // Create a PDF from a HTML string using C#
        //    using var pdf = Renderer.RenderHtmlAsPdf("<h1>Hello World</h1>");
        //    // Export to a file or Stream
        //    pdf.SaveAs("output.pdf");
        //}

        public void printUsingSyncFusionWaterMark()
        {
            //HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

            //BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //float width = 800;
            //float height = 1000;

            ////Set the BlinkBinaries folder path.
            //blinkConverterSettings.BlinkPath = @"BlinkBinariesWindows";
            //blinkConverterSettings.PdfPageSize = new SizeF(width,height);
            ////Assign Blink converter settings to HTML converter.
            //htmlConverter.ConverterSettings = blinkConverterSettings;

            ////Convert HTML string to PDF.
            //PdfDocument document = htmlConverter.Convert("<h1 style=' color:green;'>Hello world</h1>", "");
            //FileStream fileStream = new FileStream("Sample.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            ////Save and close the PDF document .
            //document.Save(fileStream);
            //document.Close(true);
            //fileStream.Close();

            //string fileIN = @"Sample.pdf";
            //string fileOUT = @"Sample_O.pdf";
            //if (File.Exists(fileIN))
            //{
            //    string[] data = File.ReadAllLines(fileIN);
            //    foreach (string line in data)
            //        if (!line.Equals("my line to remove"))
            //            File.AppendAllText(fileOUT, line);

            //    File.Delete(fileIN);
            //    File.Move(fileOUT, fileIN);
            //}
            //PrintDialog printDlg = new PrintDialog();
            ////FlowDocument doc = CreateFlowDocument(CurrentSelected);
            ////doc.Name = "FlowDoc";
            ////IDocumentPaginatorSource idpSource = doc;
            ////printDlg.PrintDocument(x, "Hello WPF Printing.");
            //PrintDocument p = new PrintDocument();
            //p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            //{
            //    e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

            //};
            //try
            //{
            //    p.Print();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Exception Occured While Printing", ex);
            //}
        }

        public async Task JSREPORTAsync()
        {
            //    var rs = new ReportingService("https://0.0.0.0");
            //    var f = await rs.RenderAsync(new RenderRequest
            //    {
            //        Template = new Template()
            //        {
            //            Content = "Helo world",
            //            Engine = Engine.Handlebars,
            //            Recipe = Recipe.ChromePdf,
            //            Chrome = new Chrome
            //            {
            //                MarginTop = "2cm"
            //            },
            //            PdfOperations = new List<PdfOperation>()
            //{
            //    new PdfOperation()
            //    {
            //        Type = PdfOperationType.Merge,
            //        Template = new Template
            //        {
            //            Content = "header",
            //            Engine = Engine.None,
            //            Recipe = Recipe.ChromePdf
            //        }
            //    }
            //}
            //        }
            //    });

        }
    }

}
