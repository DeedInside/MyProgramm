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
using System.IO;

namespace MyProgramm.viewModel
{
    public class DataExercisesStandart : INotifyPropertyChanged
    {
        private List<exercises> ListExercises = new List<exercises>(DataWorker.AllListExercisesDB());

        //обновление Grid items(элементов)
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
                    InterfaseReload();
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
                InterfaseReload();
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
                        { 
                            DataWorker.DeliteListExercisesDB(exer);
                        }    
                        UppDateWindowsElement.UpdateListData();
                    },
                    (obj) => DataWorker.AllListExercisesDB().Count > 0));
            }
        }
        private string selectedName;
        public string SelectedName
        {
            get 
            { 
                return selectedName; 
            } 
            set
            {
                selectedName = value;
                OnPropertyChanged("selectedName");
            }
        }
        private string selectedDiscription;
        public string SelectedDiscription
        {
            get
            {
                return selectedDiscription;
            }
            set
            {
                selectedDiscription = value;
                OnPropertyChanged("selectedDiscription");
            }
        }
        private string selectedImage;
        public string SelectedImage
        {
            get
            {
                return selectedImage;
            }
            set
            {
                selectedImage = value;
                OnPropertyChanged("selectedImage");
            }
        }

        public void  InterfaseReload()
        {
            SelectedName = (string)selectedItemOfList.NameExer;
            SelectedDiscription = (string)selectedItemOfList.Description;
            SelectedImage = (string)selectedItemOfList.ImageName;
        }
        private RelayCommand editioiExer;
        public RelayCommand EditioiExer
        {
            get
            {
                return editioiExer ?? new RelayCommand(obj =>
                    {
                        Window win = obj as Window;
                        exercises exer = obj as exercises;
                        if (selectedItemOfList != null)
                        {
                            MessageBox.Show(SelectedName);
                            //DataWorker.EditingExercisesDB(selectedItemOfList, exer.NameExer, exer.Description, exer.ImageName);
                        }
                       // UppDateWindowsElement.UpdateListData();
                    }
                    );
            } 
        }
        //интерфейс методы 
        #region
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
        #endregion
    }
}
