using MyProgramm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgramm.viewModel
{
    class UppDateWindowsElement
    {
        //Обновление значений листа с meinWindows
        public static void UpdateListData()
        {
            var listExercises = DataWorker.AllListExercisesDB();
            MainWindow.Allexercisesvies.ItemsSource = null;
            MainWindow.Allexercisesvies.Items.Clear();
            MainWindow.Allexercisesvies.ItemsSource = listExercises;
            MainWindow.Allexercisesvies.Items.Refresh();
        }
    }
}
