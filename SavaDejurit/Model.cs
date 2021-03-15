using System;
using System.Collections.Generic;
using System.Text;

namespace SavaDejurit
{
    public class Model
    {
        StudentEdit studentEdit = new StudentEdit();
        Student selectedStudent;

        public event EventHandler StudentsChanged;
        public event EventHandler SelectedStudentChanged;
        public Student SelectedStudent
        {
            get => selectedStudent;
            set { selectedStudent = value; SelectedStudentChanged?.Invoke(this, null); }
        }
        public List<Student> GetStudents()
        {
            return studentEdit.Students;
        }

        internal void CreateStudent()
        {
            studentEdit.Add();
            StudentsChanged?.Invoke(this, null);
        }

        internal void RemoveStudent(Student student)
        {
            studentEdit.Remove(student);
            StudentsChanged?.Invoke(this, null);
        }

        internal void SaveStudent(Student original, Student copy)
        {
            studentEdit.SaveStudent(original, copy);
            StudentsChanged?.Invoke(this, null);
        }

        internal void MarkDate(Student student)
        {
            studentEdit.MarkDate(student);
        }
    }
}
