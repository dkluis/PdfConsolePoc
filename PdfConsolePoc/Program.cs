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
                if (field is PdfTextBoxFieldWidget textBoxField)
                {
                    if (textBoxField.Name.Contains("Given"))
                    {
                        continue;
                    }
                    var name = textBoxField.Name;
                    var misc = textBoxField.Text;
                    Console.WriteLine($"Type: TextBox, Name: {name}, Text: {misc}");
                    textBoxField.Text = "Hello";
                    Console.WriteLine($"Type: Text, Name: {name}, Text: {textBoxField.Text}");

                }  
                else if (field is PdfCheckBoxWidgetFieldWidget checkBoxField)
                {
                    var name = checkBoxField.Name;
                    var misc = checkBoxField.Checked;
                    Console.WriteLine($"Type: Check, Name: {name}, Checked: {misc}");
                }
                else if (field is PdfListBoxWidgetFieldWidget listBoxField)
                {
                    var name = listBoxField.Name;
                    var misc = listBoxField.Items;
                    Console.WriteLine($"Type: List, Name: {name}, Checked: {misc}");
                }
                else if (field is PdfComboBoxWidgetFieldWidget comboBoxField)
                {
                    var name = comboBoxField.Name;
                    var misc = comboBoxField.SelectedValue;
                    Console.WriteLine($"Type: Combo, Name: {name}, Checked: {misc}");
                }
                //Console.WriteLine($"Field {i} : {formWidget.FieldsWidget.List[i]} with TextBox : {field.Name}");
            }
        }
    }
}