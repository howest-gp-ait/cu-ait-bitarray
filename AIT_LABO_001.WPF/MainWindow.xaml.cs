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
using System.Collections;

namespace AIT_LABO_001.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for(int i = 0; i <= 255; i++)
            {
                cmbByte.Items.Add(i);
            }
            cmbByte.SelectedIndex = 0;
        }
        private void ChkBit_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            byte selectedBit = byte.Parse(chk.Content.ToString());

            TextBox txt = (TextBox)this.FindName("txtBit" + selectedBit.ToString());
            txt.Text = "1";
            setByteVoorstelling();
        }

        private void ChkBit_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            byte selectedBit = byte.Parse(chk.Content.ToString());

            TextBox txt = (TextBox)this.FindName("txtBit" + selectedBit.ToString());
            txt.Text = "0";
            setByteVoorstelling();

        }

        private void CmbByte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!cmbByte.IsLoaded) return;

            byte waarde = byte.Parse(cmbByte.SelectedItem.ToString());
            BitArray bitlijst = new BitArray(new byte[] { waarde });
            for (int i = 0; i <= 7; i++)
            {
               ((CheckBox)this.FindName("ChkBit" + i.ToString())).IsChecked = bitlijst[i];
            }

        }

        private void setByteVoorstelling()
        {
            BitArray bitlijst = new BitArray(8);
            // alternatief voor bovenstaande : 
            //BitArray bitlijst = new BitArray(new byte[] { 0 });
            for (int i = 0; i <= 7; i++)
            {
                bitlijst[i] = (bool)((CheckBox)this.FindName("ChkBit" + i.ToString())).IsChecked;
                // alternatief voor bovenstaande : 
                //if (((CheckBox)this.FindName("ChkBit" + i.ToString())).IsChecked == true)
                //    bitlijst[i] = true;
                //else
                //    bitlijst[i] = false;

            }

            int retourwaarde = 0;
            if (bitlijst.Get(0)) retourwaarde++;
            if (bitlijst.Get(1)) retourwaarde += 2;
            if (bitlijst.Get(2)) retourwaarde += 4;
            if (bitlijst.Get(3)) retourwaarde += 8;
            if (bitlijst.Get(4)) retourwaarde += 16;
            if (bitlijst.Get(5)) retourwaarde += 32;
            if (bitlijst.Get(6)) retourwaarde += 64;
            if (bitlijst.Get(7)) retourwaarde += 128;
            cmbByte.SelectedItem = retourwaarde;

        }



    }

}
