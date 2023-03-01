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


namespace RAA_WPF_Skills_View_Renumber
{
    /// <summary>
    /// Interaction logic for MyForm2.xaml
    /// </summary>
    public partial class MyForm2 : Window
    {
        public MyForm2(List<string> results)
        {
            InitializeComponent();

            foreach (string curResult in results)
            {
                lbxElements.Items.Add(curResult);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
