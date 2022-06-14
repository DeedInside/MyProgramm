using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
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
        // загрузка изображения 
        public string NameImageLoad { get; set; }
        private RelayCommand LoadImage;

        public RelayCommand loadImage
        {
            get
            {
                return LoadImage ?? new RelayCommand(obj =>
                {
                    OpenFileDialog OpenFile = new OpenFileDialog();
                    if(OpenFile.ShowDialog() == true)
                    {
                        NameImageLoad = OpenFile.FileName;
                        Image_1 = NameImageLoad;
                        WindowAddExercises.ImageWin.Source = new BitmapImage(new Uri(NameImageLoad));
                    }
                }
                    );
            }
        }

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
            var listExercises = DataWorker.AllListExercisesDB(); //AllListData();
            MainWindow.Allexercisesvies.ItemsSource = null;
            MainWindow.Allexercisesvies.Items.Clear();
            MainWindow.Allexercisesvies.ItemsSource = listExercises;
            MainWindow.Allexercisesvies.Items.Refresh();
           // MainWindow.but
        }

        public string name_1 { get; set; }
        public string Dis_1 { get; set; }
        public string Image_1 { get; set; }
        public void Save()
        {
            DataWorker.CreateListExercisesDB(name_1, Dis_1, Image_1);
            //DataWorker.CreateListData(name_1,Dis_1,Image_1);
        }
        #endregion

    }
}
