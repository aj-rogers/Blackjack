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
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for AcePopUp.xaml
    /// </summary>
    public partial class AcePopUp : Window
    {
        public AcePopUp()
        {
            InitializeComponent();
        }

        private void bEleven_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.playerScore += 11;
            this.Close();
        }

        private void bOne_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.playerScore += 1;
            this.Close();
        }
    }
}
