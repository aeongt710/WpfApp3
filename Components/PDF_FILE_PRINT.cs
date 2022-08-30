using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFFilePrint;
using PdfiumViewer;

namespace WpfApp3.Components
{
    public class PDF_FILE_PRINT
    {
       public static void f1()
        {
            var asd = new PDFFilePrint.FilePrint();

            //asd.PleasePrint("document.pdf", "document2.pdf");

            //{Width = 226 Height = 572}
            PdfDocument document = PdfDocument.Load("document.pdf");
            
            using System.Drawing.Printing.PrintDocument printDocument = document.CreatePrintDocument();
            printDocument.PrinterSettings = new System.Drawing.Printing.PrinterSettings() { PrinterName= "HP LaserJet MFP M227-M231" };
            printDocument.DefaultPageSettings = 
                new System.Drawing.Printing.PageSettings(printDocument.PrinterSettings) { 
                    Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0),
                    PaperSize = new System.Drawing.Printing.PaperSize("Custom", 226, 572) ,
                    PaperSource = new System.Drawing.Printing.PaperSource() { SourceName="c1"}
                };
            //printDocument.PrinterSettings = printerSettings;
            //printDocument.DefaultPageSettings = pageSettings;
            printDocument.PrintController = new System.Drawing.Printing.StandardPrintController();
            printDocument.Print();
        }

        public static void f2()
        {
            //{ Width = 226 Height = 572}
            PdfDocument document = PdfDocument.Load("document.pdf");
            using System.Drawing.Printing.PrintDocument pd = document.CreatePrintDocument();
            PrintController printController = new StandardPrintController();
            pd.PrintController = printController;
            pd.PrinterSettings.PrinterName = "HP LaserJet MFP M227-M231"; //Printer Name
            //pd.PrinterSettings.Copies = Convert.ToInt16(printqty);
            pd.DefaultPageSettings.Landscape = false;
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            //pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            
        }
    }
}
