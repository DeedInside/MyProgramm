using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyProgramm.Model
{
    /// <summary>
    /// Класс описание упражнения и его свойств 
    /// </summary>
    public class exercises : INotifyPropertyChanged
    {
        //id упражнения
        public int Id { get; set; }
        // Наименование упражнения
        private string nameExer;
        public string NameExer
        {
            get { return nameExer; }
            set
            {
                nameExer = value;
                OnPropertyChanged("nameExer");
            }
        }
        // описание упражнения
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("description");
            }
        }

        // Имя изображения к упражнению
        private string imageName { get; set; }
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                OnPropertyChanged("imageName");
            }
        }

        public exercises()
        {
            
        }
       
        public exercises(string nameExer, string description, string imageName)
        {
            NameExer = nameExer;
            Description = description;
            ImageName = imageName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

