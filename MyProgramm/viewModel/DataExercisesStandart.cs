using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgramm.Model;
using System.ComponentModel;
using MyProgramm.View;
using System.Windows;

namespace MyProgramm.viewModel
{
    public class DataExercisesStandart : INotifyPropertyChanged
    {
        private List<exercises> ListExercises = new List<exercises>(DataWorker.LIST_1);

       // обновление Grid items (элементов)
        public List<exercises> listExercises
        {
            get
            {
                return mSubViewModels;
            }
        }
        private List<exercises> mSubViewModels = new List<exercises>();

        public DataExercisesStandart()
        {
            foreach (exercises exe in ListExercises)
            {
                listExercises.Add(exe);
            }
        }

        // Свойстав открытия окон
        #region
        private RelayCommand openWinExercises;

        public RelayCommand OpenWinExercises
            {
                get 
                {
                return openWinExercises ?? new RelayCommand(obj =>
                    {
                        OpenWindowAddExercises();
                    }
                    );
                }
            }
        // Заготовка под удаление элемента но пока хз как обратиться к кнопке
        private RelayCommand DelItem;

        public RelayCommand delItem
        {
            get
            {
                return DelItem ?? new RelayCommand(obj =>
                {
                    MessageBox.Show("uuuups");
                }
                    );
            }
        }
        #endregion
        //Методы открытия окон
        #region
        private void OpenWindowAddExercises()
        {
            WindowAddExercises win = new WindowAddExercises();
            win.Owner = Application.Current.MainWindow;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }
        #endregion

        //передача в информации об обновлении в интерфейс 
        public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string PropertyName)
    {
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
    }

    }
}
