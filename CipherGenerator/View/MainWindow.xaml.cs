using System.Windows;
using CipherGenerator.ViewModel;

namespace CipherGenerator.View
{
    public partial class MainWindow  : Window
    {
        public MainWindow()
        {
            DataContext = new CipherViewModel();
           
            InitializeComponent();
        }
    }
}