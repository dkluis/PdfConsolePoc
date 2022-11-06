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
            doc.LoadFromFile(@"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/SampleForm-1.pdf");

            var formWidget = doc.Form as PdfFormWidget;
            for (var i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                var field = formWidget.FieldsWidget.List[i] as PdfField;
                switch (field)
                {
                    case PdfTextBoxFieldWidget textBoxField:
                    {
                        Console.Write($"BEFORE -> Name: {textBoxField.Name}, Contents: {textBoxField.Text} =======> ");
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
                        Console.Write($"BEFORE -> Name: {comboBoxField.Name}, Contents: {comboBoxField.SelectedValue} =======> ");
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
                
                doc.SaveToFile(@"C:/Users/Dick Kluis/Documents/Repos/PdfConsolePoc/Saved-SampleForm-1.pdf");
            }
        }
    }
}