using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing.Printing;
using PdfiumViewer;

namespace WpfApp3.Components
{
    public class Customer
    {
        public string nameEnglish { get; set; }
        public string contact { get; set; }

        public static void asd()
        {

            //var file = File.ReadAllBytes("document.pdf");
            //var printQueue = LocalPrintServer.GetDefaultPrintQueue();
            ////System.Drawing.Printing.PrinterSettings.InstalledPrinters

            //using (var job = printQueue.AddJob())
            //using (var stream = job.JobStream)
            //{

            //    stream.Write(file, 0, file.Length-1);
            //}
            string Pdf = @"document.pdf";


            // Configure printing properties required for this report
            string printer = "";                // Default printer
            PaperSize paperSize = null;         // Default paper size
            PaperSource paperSource =null;     // Default paper source
            int orientation = 0;                // Portrait
            Duplex duplex = Duplex.Vertical;    // Duplex - long edge
            short copies = 0;                   // Default = single copy
            int fromPage = 0;                   // From first page
            int toPage = 0;                     // To last page


            // Print report without any user intervention
            PrintPDF(Pdf, printer, paperSize, paperSource, orientation, duplex, copies, fromPage, toPage);
        }
        private static void PrintPDF(string filename, string printer, PaperSize paperSize, PaperSource paperSource, int orientation, Duplex duplex, short copies, int fromPage, int toPage)
        {
            using (var document = PdfDocument.Load(filename))
            {
                using (var pd = document.CreatePrintDocument())
                {
                    // Create the printer settings for our printer
                    //if (printer.Length > 0)
                    //    pd.PrinterSettings.PrinterName = printer;


                    //if (paperSize != null)
                    //    pd.DefaultPageSettings.PaperSize = paperSize;


                    //if (paperSource != null)
                    //    pd.DefaultPageSettings.PaperSource = paperSource;


                    //pd.DefaultPageSettings.Landscape = (orientation > 0);


                    //pd.PrinterSettings.Duplex = duplex;


                    //if (copies > 0)
                    //    pd.PrinterSettings.Copies = copies;


                    //if (fromPage > 0)
                    //    pd.PrinterSettings.FromPage = fromPage;


                    //if (toPage > 0)
                    //    pd.PrinterSettings.ToPage = toPage;
                    //pd.DefaultPageSettings.PaperSize =new PaperSize() { RawKind = R.A4 };
                    pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 226, 572);
                    pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                    pd.PrinterSettings.PrinterName = "HP LaserJet MFP M227-M231";
                    pd.PrintController = new StandardPrintController();
                    pd.Print();
                }
            }

        }

        public class GraphQL
        {
            public List<Customer> nodes { get; set; }
        }
        public class GraphQL2
        {
            public GraphQL customers { get; set; }
        }

        public class data  //for premissions
        {
            public List<string> myPermissions { get; set; }
        }
    }
    
}
