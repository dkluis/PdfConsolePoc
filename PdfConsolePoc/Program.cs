using System;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace PdfConsolePoc
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"/Users/dick/Desktop/SampleForm-1.pdf");

            var formWidget = doc.Form as PdfFormWidget;
            for (var i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                var field = formWidget.FieldsWidget.List[i] as PdfField;
                Console.WriteLine($"Field {i} : {formWidget.FieldsWidget.List[i]} with TextBox : {field.Name}");
            }
        }
    }
}