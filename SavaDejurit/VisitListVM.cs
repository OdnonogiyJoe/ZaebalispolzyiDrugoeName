using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SavaDejurit
{
    internal class VisitListVM : MvvmNotify, IPageVM
    {
        Model model;
        public ObservableCollection<DateTime> Visits { get; set; } = new ObservableCollection<DateTime>();
        public string Title { get; set; }
        public MvvmCommand Back { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            Back = new MvvmCommand(() => Pages.ChangePageTo(PageType.StudentList), () => true);
            model.SelectedStudentChanged += Model_SelectedStudentChanged;
        }

        private void Model_SelectedStudentChanged(object sender, EventArgs e)
        {
            if (model.SelectedStudent != null)
            {
                Title = $"История дежурств студента {model.SelectedStudent.Name}";
                NotifyPropertyChanged("Title");
                Visits = new ObservableCollection<DateTime>(model.SelectedStudent.VisitLog);
                NotifyPropertyChanged("Visits");
            }
        }
    }
}
