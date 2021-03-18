using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavaDejurit
{
    public class CleanersListVM : MvvmNotify, IPageVM
    {
        Random randomm = new Random();
        Model model;
        public MvvmCommand Return { get; set; }
        public MvvmCommand Random { get; set; }
        public void SetModel(Model model)
        {
            this.model = model;
            Return = new MvvmCommand(() => Pages.ChangePageTo(PageType.StudentList), () => true);
            Random = new MvvmCommand( () => 
        }
        public void GetRandom()
        {
            var random = new Random();
            var questions = new List<string>
            int index = random.Next(questions.Count);
            Console.WriteLine(questions[index]);
        }
    }
}
