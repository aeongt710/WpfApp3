using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Components
{
    public class SelectPDF
    {
        //public static void PrintPDF(string[] args)
        //{
        //    // instantiate PDF printer class
        //    PdfPrinter printer = new PdfPrinter();

        //    // load file to print
        //    printer.Load(@"Test.pdf");

        //    // set event handlers for before/after printing of each page
        //    printer.BeforePagePrinting += Printer_BeforePagePrinting;
        //    printer.AfterPagePrinting += Printer_AfterPagePrinting;

        //    // set first page to be printed (default value 1)
        //    printer.StartPageNumber = 1;

        //    // set the last page to be printed 
        //    // (default value 0 - all pages are printed, starting with first page specified)
        //    printer.EndPageNumber = 0;

        //    // set color space
        //    printer.ColorSpace = PdfRasterizerColorSpace.RGB;

        //    // set silent printing
        //    printer.ShowPrintProgress = false;

        //    // the document name to display (for example, in a print status dialog box or printer queue) while printing the document
        //    printer.DocumentName = "DocumentPrinted.pdf";

        //    // select printer
        //    printer.PrinterSettings.PrinterName = "Adobe PDF";

        //    // set page size (specify paper size name, width and height in points)
        //    printer.PageSettings.PaperSize = new PaperSize("A4", 826, 1169);

        //    // set page orientation (default Portrait)
        //    printer.PageSettings.Landscape = false;

        //    // set margins
        //    printer.PageSettings.Margins = new Margins(0, 0, 0, 0);

        //    // print PDF document
        //    printer.Print();
        //}

        //// this is called before each page printing
        //private static void Printer_BeforePagePrinting(object sender, PdfPrinterBeforePagePrintingEventArgs args)
        //{
        //    Console.WriteLine("Preparing to print page " + args.PageNumber + ": " + args.PageSize.Width + "x" + args.PageSize.Height);

        //    // cancel printing process before starting printing page 3
        //    if (args.PageNumber == 3)
        //    {
        //        args.Cancel = true;
        //        Console.WriteLine("Canceled before printing page " + args.PageNumber);
        //    }
        //}

        //// this is call after each page printing
        //private static void Printer_AfterPagePrinting(object sender, PdfPrinterAfterPagePrintingEventArgs args)
        //{
        //    Console.WriteLine("Printed page " + args.PageNumber);
        //}
    }
}
