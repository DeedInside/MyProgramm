using MyProgramm.viewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgramm.Model
{
    public class DataWorker : INotifyPropertyChanged
    {
        static public List<exercises> LIST_1 = new List<exercises>()
        {
            new exercises("Жим", "жим штанги лежа", "путь изображения"),
            new exercises("Жим1", "жим штанги лежа1", "путь изображения1"),
            new exercises("Жим2", "жим штанги лежа2", "путь изображения2"),
            new exercises("Жим3", "жим штанги лежа3", "путь изображения3"),
            new exercises("Жим4", "жим штанги лежа4", "путь изображения4")
        };

        public List<exercises> lis
        {
            get { return LIST_1; }
            set
            {
                LIST_1 = value;
                NotifyPropertyChanged("ListExercises");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public static List<exercises> AllListData()
        {
            return LIST_1;
        }

        //List<exercises> Exercises = new List<exercises>();
        static public void CreateListData(string name, string discription, string image)
        {
            LIST_1.Add(new exercises(name, discription, image));
            
            
        }
    }
}
