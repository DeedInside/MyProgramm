using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MyProgramm.Model;
using MyProgramm.View;

namespace MyProgramm.viewModel
{
    class CreateDataExercises : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #region
        private RelayCommand SaveAndCloseWin;

        public RelayCommand saveAndCloseWin
        {
            get
            {
                return SaveAndCloseWin ?? new RelayCommand(obj =>
                {
                    Window qwe = obj as Window;
                    Save();
                    UpdateListData();
                    qwe.Close();
                }
                    );
            }
        }
        #endregion
        //Сохранение данных и закрытие окна
        #region


        private void UpdateAllData()
        {
            UpdateListData();
        }
        //Обновление значений листа с meinWindows
        private void UpdateListData()
        {
            var listExercises = DataWorker.AllListData();
            MainWindow.Allexercisesvies.ItemsSource = null;
            MainWindow.Allexercisesvies.Items.Clear();
            MainWindow.Allexercisesvies.ItemsSource = listExercises;
            MainWindow.Allexercisesvies.Items.Refresh();
        }

        public string name_1 { get; set; }
        public string Dis_1 { get; set; }
        public string Image_1 { get; set; }
        public void Save()
        {
            DataWorker.CreateListData(name_1,Dis_1,Image_1);
        }
        #endregion

    }
}
