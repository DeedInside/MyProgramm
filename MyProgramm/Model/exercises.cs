using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgramm.Model
{
    /// <summary>
    /// Класс описание упражнения и его свойств 
    /// </summary>
    public class exercises
    {
        //id упражнения
        public int Id { get; set; }
        // Наименование упражнения
        public string NameExer { get; set; }
        // описание упражнения
        public string Description { get; set; }
        // Имя изображения к упражнению
        public string ImageName { get; set; }
        public exercises() { }

        public exercises(string nameExer, string description, string imageName)
        {
            NameExer = nameExer;
            Description = description;
            ImageName = imageName;
        }
    }
}
