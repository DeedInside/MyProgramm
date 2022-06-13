using MyProgramm.Model.DataBase;
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
        //Возвращение всей бд
        public static List<exercises> AllListExercisesDB()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var ret = db.Exercisesdb.ToList();
                return ret;
            }
        }

        //создание полной записи
        public static void CreateListExercisesDB(string name, string discription, string image)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                exercises newExercises = new exercises { NameExer = name, Description = discription, ImageName = image };
                db.Exercisesdb.Add(newExercises);
                db.SaveChanges();
            }
        }

        //Удаление записи
        public static void ListExercisesDB(exercises exer)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Exercisesdb.Remove(exer);
                db.SaveChanges();
            }
        }

        static public List<exercises> LIST_1 = new List<exercises>()
        {
            new exercises("Жим", "жим штанги лежа", "C:\\Users\\loy4f\\Source\\Repos\\MyProgramm1.1\\MyProgramm\\Model\\Image\\bench_press.gif"),
            new exercises("Жим1", "жим штанги лежа1", "C:\\Users\\loy4f\\Source\\Repos\\MyProgramm1.1\\MyProgramm\\Model\\Image\\bench_press.gif")
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

        static public void CreateListData(string name, string discription, string image)
        {
            LIST_1.Add(new exercises(name, discription, image));
            
            
        }
    }
}
