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

       
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            NewRecipe newRec = new NewRecipe();
            this.Close();
            newRec.Show();

        }

        //exit button
        private void ListViewItem2_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("App wil now close");
            this.Close();

        }//end of exit button method

        
        private void ListViewItem3_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
