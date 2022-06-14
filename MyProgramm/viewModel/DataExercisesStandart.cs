using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgramm.Model;
using System.ComponentModel;
using MyProgramm.View;
using System.Windows;
using System.Runtime.CompilerServices;

namespace MyProgramm.viewModel
{
    public class DataExercisesStandart : INotifyPropertyChanged
    {
        private List<exercises> ListExercises = new List<exercises>(DataWorker.AllListExercisesDB());

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

        private RelayCommand openWinEditionExercises;

        public RelayCommand OpenWinEditionExercises
        {
            get
            {
                return openWinExercises ?? new RelayCommand(obj =>
                {
                    OpenWindowEditingExercisesElement();
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
        private void OpenWindowEditingExercisesElement()
        {
            WindowEditingExercisesElement win = new WindowEditingExercisesElement();
            win.Owner = Application.Current.MainWindow;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }
        #endregion

        private exercises selectedItemOfList;
        public exercises SelectedItemOfList
        {
            get { return selectedItemOfList; }
            set
            {
                selectedItemOfList = value;
                OnPropertyChanged("SelectedItemOfList");
            }
        }

        // Удаление выделенного элемента из бд
        private RelayCommand DelItem;
        public RelayCommand delItem
        {
            get
            {
                return DelItem ??
                    (DelItem = new RelayCommand(obj =>
                    {
                        exercises exer = obj as exercises;
                        if (exer != null)
                            DataWorker.DeliteListExercisesDB(exer);
                        UppDateWindowsElement.UpdateListData();
                    },
                    (obj) => DataWorker.AllListExercisesDB().Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //передача в информации об обновлении в интерфейс 
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //передача в информации об обновлении в интерфейс 
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
