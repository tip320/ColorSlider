using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorSlider {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        #region EVENTS
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte red = (byte)sldRed.Value;
            byte grn = (byte)sldGreen.Value;
            byte blu = (byte)sldBlue.Value;
            byte alp = (byte)sldAlpha.Value;
            
            if (txtRed != null) {
                txtRed.Text = red.ToString();
            }//end if

            if (txtGreen != null) {
                txtGreen.Text = grn.ToString();
            }//end if

            if (txtBlue != null) {
                txtBlue.Text = blu.ToString();
            }//end if

            if (txtAlpha != null) {
                txtAlpha.Text = alp.ToString();
            }//end if

            UpdateRectangle(red, grn, blu, alp);

            UpdateLabels();

        }//end event

        private void textbox_TextChanged(object sender, TextChangedEventArgs e) {

            byte red;
            byte grn;
            byte blu;   
            byte alp;

            if (txtRed != null) {
                byte.TryParse(txtRed.Text, out red);
                sldRed.Value = red;
            }//end if

            if (txtGreen != null) {
                byte.TryParse (txtGreen.Text, out grn);
                sldGreen.Value = grn;
            }//end if

            if (txtBlue != null) {
                byte.TryParse (txtBlue.Text, out blu);
                sldBlue.Value = blu;
            }//end if

            if (txtAlpha != null) {
                byte.TryParse (txtAlpha.Text, out alp);
                sldAlpha.Value = alp;
            }//end if

        }//end event
        #endregion

        #region FUNCTIONS/METHODS
        private void UpdateRectangle(byte red, byte green, byte blue, byte alpha) {
            Color brushColor = Color.FromArgb(alpha, red, green, blue);

            SolidColorBrush brush = new SolidColorBrush(brushColor);    

            rctColor.Fill = brush;
        }//end function

        private void UpdateLabels() {

            SolidColorBrush tempBrush = (SolidColorBrush)rctColor.Fill;

            Color brushColor =   tempBrush.Color;

            byte alp = brushColor.A;
            byte red = brushColor.R;
            byte grn = brushColor.G;
            byte blu = brushColor.B;

            string binaryString = $"{Convert.ToString(alp, 2).PadLeft(8, '0')} {Convert.ToString(red, 2).PadLeft(8, '0')} {Convert.ToString(grn, 2).PadLeft(8, '0')} {Convert.ToString(blu, 2).PadLeft(8, '0')}";

            if (lblBinary != null) {
                lblBinary.Content = binaryString;
            }//end if

        }//end function


        #endregion

    }//end class
}//end namespace
