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
using BaseConverter;



namespace BaseConverter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            InitializeComboBox();
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
        }

        public void InitializeComboBox() {
            ComboBox1.Items.Add("Decimal");
            ComboBox1.Items.Add("Binary");
            ComboBox1.Items.Add("Hexadecimal");
            ComboBox1.Items.Add("Octal");
            ComboBox2.Items.Add("Decimal");
            ComboBox2.Items.Add("Binary");
            ComboBox2.Items.Add("Hexadecimal");
            ComboBox2.Items.Add("Octal");
            ComboBox1.Text = "Decimal";
            ComboBox2.Text = "Decimal";
        }

        private void SwapButton_Click(object sender, RoutedEventArgs e) {
            Object aux = ComboBox1.SelectedItem;
            ComboBox1.SelectedItem = ComboBox2.SelectedItem;
            ComboBox2.SelectedItem = aux;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e) {

            if(ComboBox1.SelectedItem.ToString() == "Decimal") {
                ulong n;
                WarningText.Text = "";

                try {
                    n = Convert.ToUInt64(TextBox1.Text.ToString());
                }
                catch(FormatException) {
                    WarningText.Text = "Error! Invalid number.";
                    return;
                }
                catch(OverflowException) {
                    WarningText.Text = "Error! Type a smaller number.";
                    return;
                }

                if(ComboBox2.SelectedItem.ToString() == "Binary") {
                    string result = "";

                    result = BaseConverter.Dec2Bin(TextBox1.Text.ToString());

                    TextBox2.Text = result;
                }

                else if(ComboBox2.SelectedItem.ToString() == "Hexadecimal") {
                    string result;

                    result = BaseConverter.Dec2Hex(TextBox1.Text.ToString());
                    TextBox2.Text = result;
                }

                else if(ComboBox2.SelectedItem.ToString() == "Octal") {
                    // Dec2Oct
                }

                else {
                    TextBox2.Text = TextBox1.Text;
                }
            }

            else if(ComboBox1.SelectedItem.ToString() == "Binary") {

                if (!BaseConverter.IsBinary(TextBox1.Text.ToString())) {
                    WarningText.Text = "Error! Invalid number.";
                    return;
                }

                if(ComboBox2.SelectedItem.ToString() == "Decimal") {
                    string result = "";

                    result = BaseConverter.Bin2Dec(TextBox1.Text.ToString());

                    TextBox2.Text = result;
                }

                else if(ComboBox2.SelectedItem.ToString() == "Hexadecimal") {

                }

                else if(ComboBox2.SelectedItem.ToString() == "Octal") {

                }

                else {
                    TextBox2.Text = TextBox1.Text;
                }
            }

            else if(ComboBox1.SelectedItem.ToString() == "Hexadecimal") {

                if(ComboBox2.SelectedItem.ToString() == "Binary") {

                }

                else if(ComboBox2.SelectedItem.ToString() == "Decimal") {

                }

                else if(ComboBox2.SelectedItem.ToString() == "Octal") {

                }

                else {
                    TextBox2.Text = TextBox1.Text;
                }
            }

            else if(ComboBox1.SelectedItem.ToString() == "Octal") {

                if(ComboBox2.SelectedItem.ToString() == "Binary") {

                }

                else if(ComboBox2.SelectedItem.ToString() == "Decimal") {

                }

                else if(ComboBox2.SelectedItem.ToString() == "Hexadecimal") {

                }

                else {
                    TextBox2.Text = TextBox1.Text;
                }
            }
        }
    }
}
