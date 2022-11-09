using System;
using System.IO;
// using Spire.Pdf;
// using Spire.Pdf.Fields;
// using Spire.Pdf.Widget;
using IronPdf;
using IronPdf.Editing;

namespace PdfConsolePoc
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            /*var doc = new PdfDocument();
            //const string pdfPath = @"C:\Users\Dick Kluis\Documents\Repos\PdfConsolePoc\E6-coupon QC58-ADA8-V6L5-FRRT.pdf";
            //const string pdfPath = @"C:\Users\Dick Kluis\Documents\Repos\PdfConsolePoc\BLANK-M7LW-coupon KE9C-XGVJ-MU51-PLW2.pdf";
            //const string pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/SampleForm-1.pdf";
            const string pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/pdf-x3-2002.pdf";
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"File {pdfPath} Does not Exist");
            }
            else
            {
                try
                {
                    var stream = File.OpenRead(pdfPath);
                    doc.LoadFromStream(stream);
                    //doc.LoadFromFile(pdfPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                var formWidget = doc.Form as PdfFormWidget;
                foreach (var t in formWidget.FieldsWidget.List)
                {
                    var field = t as PdfField;
                    switch (field)
                    {
                        case PdfTextBoxFieldWidget textBoxField:
                        {
                            Console.Write(
                                $"BEFORE -> Name: {textBoxField.Name}, Contents: {textBoxField.Text} =======> ");
                            switch (textBoxField.Name)
                            {
                                case "Given Name Text Box":
                                    textBoxField.Text = "Dick";
                                    break;
                                case "Family Name Text Box":
                                    textBoxField.Text = "Kluis";
                                    break;
                                case "House nr Text Box":
                                    textBoxField.Text = "3922";
                                    break;
                                case "Address 1 Text Box":
                                    textBoxField.Text = "Talah Dr.";
                                    break;
                                case "City Text Box":
                                    textBoxField.Text = "Amsterdam";
                                    break;
                                case "Postcode Text Box":
                                    textBoxField.Text = "34684";
                                    break;
                            }

                            Console.WriteLine($"AFTER: Contents: {textBoxField.Text}");
                            break;
                        }
                        case PdfCheckBoxWidgetFieldWidget checkBoxField:
                        {
                            var name = checkBoxField.Name;
                            var misc = checkBoxField.Checked;
                            Console.WriteLine($"Type: Check, Name: {name}, Combo: {misc}");
                            break;
                        }
                        case PdfListBoxWidgetFieldWidget listBoxField:
                        {
                            var name = listBoxField.Name;
                            var misc = listBoxField.Items;
                            Console.WriteLine($"Type: List, Name: {name}, Checked: {misc}");
                            break;
                        }
                        case PdfComboBoxWidgetFieldWidget comboBoxField:
                        {
                            Console.Write(
                                $"BEFORE -> Name: {comboBoxField.Name}, Contents: {comboBoxField.SelectedValue} =======> ");
                            switch (comboBoxField.Name)
                            {
                                case "Country Combo Box":
                                    comboBoxField.SelectedIndex = new[] {20};
                                    break;
                                case "Favourite Colour List Box":
                                    comboBoxField.SelectedIndex = new[] {5};
                                    break;
                            }

                            Console.WriteLine($"AFTER: Contents: {comboBoxField.SelectedValue}");
                            break;
                        }
                    }

                    doc.SaveToFile(@"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/Saved-E6-Voucher.pdf");
                }
            }*/
            
            License.LicenseKey = "IRONPDF.DICKKLUIS.29788-CE669610B2-FJ45X2-QPNP57AVVL4N-AUU2FPGH7DDR-CGAYIQHTPFMM-Y3I57Q6U2OJR-ZOGJ4GKVKDUV-ARM54Y-TMU4ODTVWYWIEA-DEPLOYMENT.TRIAL-G6S4MQ.TRIAL.EXPIRES.09.DEC.2022"; 
            var pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/pdf-x3-2002.pdf";
            //pdfPath = @"C:\Users\Dick Kluis\Documents\Repos\PdfConsolePoc\BLANK-M7LW-coupon KE9C-XGVJ-MU51-PLW2.pdf";
            pdfPath = @"C:\Users\Dick Kluis\Documents\Repos\PdfConsolePoc\E6-coupon QC58-ADA8-V6L5-FRRT.pdf";
            //pdfPath = @"C:\Users\Dick Kluis\Documents\Repos\PdfConsolePoc\x1a-2001v1.3.pdf";
            //pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/SampleForm-1.pdf";
            var document = PdfDocument.FromFile(pdfPath);
            Console.WriteLine(document.Pages.Count);
            var form = document.Form;
            for (var i =0; i < form.Fields.Count; i++)
            {
                Console.WriteLine(form.Fields[i].Name);
            } 
            
            var PageIndex = 1;
            var oldTxt = "FRRT-V6L5-ADA8-QC58";
            var newTxt = "29 October 2023";
            
            document.ReplaceTextOnPage(0, oldTxt, newTxt);

            oldTxt = "29 January 2023";
            newTxt = "29 October 2024";
            
            document.ReplaceTextOnPage(0, oldTxt, newTxt);

            var stamp = new BarcodeStamper("Dick", BarcodeEncoding.QRCode);
            document.ApplyStamp(stamp, 0);
            
            var ForegroundStamp = new IronPdf.Editing.HtmlStamp() 
                { Html = "<h2 style='color:red'>Copyright 2020 IronPDF.com", 
                    Location = IronPdf.Editing.StampLocation.TopRight,
                    Width = 50, 
                    Height = 50, 
                    Opacity = 50, 
                    Rotation = -45, 
                    ZIndex = IronPdf.Editing.HtmlStamp.StampLayer.OnTopOfExistingPDFContent };
            document.StampHTML(ForegroundStamp);
            
            document.SaveAs(@"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/Just-Changed-It-Now.pdf");

        }
    }
}