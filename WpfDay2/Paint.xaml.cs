using DocumentFormat.OpenXml.InkML;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfDay2
{
    /// <summary>
    /// Interaction logic for Paint.xaml
    /// </summary>
    public partial class Paint : Window
    {
        public Paint()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
         switch(  ((RadioButton )sender).Content.ToString())
            {
                case"Red":
                    INKC.DefaultDrawingAttributes.Color = Colors.Red;
                    break;
                case "Green":
                    INKC.DefaultDrawingAttributes.Color = Colors.Green;
                    break;
                case "Blue":
                    INKC.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Ellipse":
                    INKC.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Ellipse;
                    break;
                case "Rectangle":
                    INKC.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
                    break;
                case "Small":

                    INKC.DefaultDrawingAttributes.Width = 5;
                    INKC.DefaultDrawingAttributes.Height = 5;
                    break;
                case "Normal":
                    INKC.DefaultDrawingAttributes.Width = 8;
                    INKC.DefaultDrawingAttributes.Height = 8;
                    break;
                case "Large":
                    INKC.DefaultDrawingAttributes.Width = 20;
                    INKC.DefaultDrawingAttributes.Height = 20;
                    break;
            }

           
        }

        private void ModeChecked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content.ToString())
            {
                case "Ink":
                    INKC.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select":
                    INKC.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Earse":
                    INKC.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "Earse by Stroke":
                    INKC.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

    
        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "isf files (*.isf)|*.isf";

            if (dialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dialog.FileName, FileMode.Create);
                INKC.Strokes.Save(fileStream);
                fileStream.Close();
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "isf files (*.isf)|*.isf";

            if (dialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open);
                INKC.Strokes = new StrokeCollection(fileStream);
                fileStream.Close();
            }
        }


        private void New(object sender, RoutedEventArgs e)
        {
            INKC.Strokes.Clear();

        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            INKC.CopySelection();   
        }

        private void Cut(object sender, RoutedEventArgs e)
        {
            INKC.CutSelection();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            INKC.Paste();
        }
    }
}
