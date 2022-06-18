using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private string NamePatch = @"C:\Users\loy4f\Source\Repos\MyProgramm_1.4\MyProgramm\Model\Image\";
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
                    UpdateAllData();
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
            UppDateWindowsElement.UpdateListData();
        }
        //Обновление значений листа с meinWindows

        public string name_1 { get; set; }
        public string Dis_1 { get; set; }
        public string Image_1 { get; set; }
        public void Save()
        {
            //сохранение изображения
            FileInfo fileInf = new FileInfo(Image_1);
            Image_1 = NamePatch + fileInf.Name;
            fileInf.CopyTo(Image_1, true);

            DataWorker.CreateListExercisesDB(name_1, Dis_1, Image_1);
        }
        #endregion

    }
}
