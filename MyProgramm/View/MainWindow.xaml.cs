using System.Windows;
using System.Windows.Controls;
using MyProgramm.Model;

namespace MyProgramm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView Allexercisesvies;
        public MainWindow()
        {

            InitializeComponent();
            Allexercisesvies = ListViesMain;
        }
    }
}
