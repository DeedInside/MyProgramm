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
using MyProgramm.viewModel;

namespace MyProgramm.View
{
    /// <summary>
    /// Логика взаимодействия для WindowEditingExercisesElement.xaml
    /// </summary>
    public partial class WindowEditingExercisesElement : Window
    {
        public static Image ImageWinEdition;
        public WindowEditingExercisesElement()
        {
            InitializeComponent();
            //DataContext = DataExercisesStandart;
            ImageWinEdition = ImageWinXamlEdition;
        }
    }
}
