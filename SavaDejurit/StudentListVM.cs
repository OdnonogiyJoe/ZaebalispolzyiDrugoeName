using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SavaDejurit
{
    public class StudentListVM: MvvmNotify, IPageVM
    {
        Model model;
        public ObservableCollection<Student> Students { get; set; }
        public MvvmCommand CreateStudent { get; set; }
        public MvvmCommand RemoveStudent { get; set; }
        public MvvmCommand SaveStudent { get; set; }
        public MvvmCommand VisitLog { get; set; }
        public MvvmCommand MarkDate { get; set; }

        public Student SelectedStudent {
            get => model.SelectedStudent;
            set
            {
                model.SelectedStudent = value;
                if (value != null)
                    SelectedStudentCopy = new Student { FirstName = value.FirstName, LastName = value.LastName, FatherName = value.FatherName, VisitLog = value.VisitLog };
                NotifyPropertyChanged("SelectedStudent");
                NotifyPropertyChanged("SelectedStudentCopy");
            }
        }
        public Student SelectedStudentCopy { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            Students = new ObservableCollection<Student>(model.GetStudents());
            VisitLog = new MvvmCommand(
                () => Pages.ChangePageTo(PageType.VisitList),
                () => SelectedStudent != null);
            CreateStudent = new MvvmCommand(
                () => model.CreateStudent(),
                () => true);
            RemoveStudent = new MvvmCommand(
                () => model.RemoveStudent(SelectedStudent),
                () => SelectedStudent != null);
            SaveStudent = new MvvmCommand(
                () => model.SaveStudent(SelectedStudent, SelectedStudentCopy),
                () => SelectedStudent != null);
            VisitLog = new MvvmCommand(
                () =>
                {
                    model.SelectedStudent = SelectedStudent;
                    Pages.ChangePageTo(PageType.VisitList);
                },
                () => SelectedStudent != null);
            MarkDate = new MvvmCommand(
                () => model.MarkDate(SelectedStudent),
                () => SelectedStudent != null);

            model.StudentsChanged += Model_StudentsChanged;
        }

        private void Model_StudentsChanged(object sender, System.EventArgs e)
        {
            Students = new ObservableCollection<Student>(model.GetStudents());
            NotifyPropertyChanged("Clients");
        }

    }
}
