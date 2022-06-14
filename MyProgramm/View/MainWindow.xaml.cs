using System.Windows;
using System.Windows.Controls;
using MyProgramm.Model;
using MyProgramm.viewModel;

namespace MyProgramm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static ItemsControl Allexercisesvies;
        public static ListView Allexercisesvies;
        public MainWindow()
        {

            InitializeComponent();
            Allexercisesvies = ListViesMain;
        }
    }
}
