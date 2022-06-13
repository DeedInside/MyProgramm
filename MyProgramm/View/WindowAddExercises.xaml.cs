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

namespace MyProgramm.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAddExercises.xaml
    /// </summary>
    public partial class WindowAddExercises : Window
    {
        public static Image ImageWin;
        public WindowAddExercises()
        {
            InitializeComponent();
            ImageWin = ImageWinXaml;
        }
    }
}
