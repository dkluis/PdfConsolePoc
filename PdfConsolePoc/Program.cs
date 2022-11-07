using System;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace PdfConsolePoc
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var doc = new PdfDocument();
            const string pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/E6-coupon-template.pdf";
            //const string pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/SampleForm-1.pdf";
            //const string pdfPath = @"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/E6-coupon 5N43-LHA5-EK4J-8AKW.pdf";
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
            }
        }
    }
}