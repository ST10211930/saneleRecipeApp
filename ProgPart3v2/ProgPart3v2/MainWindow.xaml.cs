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

namespace ProgPart3v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //new recipe button
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }//end of new recipe button method 

        //recipe book button
        private void ListViewItem2_Selected(object sender, RoutedEventArgs e)
        {

        }//end of recipe book button method

        //exit button
        private void ListViewItem3_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("App wil now close");
            this.Close();
        }//end of exit button method
    }
}
