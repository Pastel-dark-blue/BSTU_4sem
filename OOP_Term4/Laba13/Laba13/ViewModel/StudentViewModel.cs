using Laba13.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Laba13.ViewModel
{
    // Для уведомления системы об изменениях свойств модель StudentViewModel реализует интерфейс INotifyPropertyChanged.

    public class StudentViewModel : ViewModelBase
    {
        public Student _student;

        public StudentViewModel(Student student)
        {
            _student = student;
        }

        public string Fio
        {
            get { return _student.Fio; }
            set
            {
                _student.Fio = value;
                OnPropertyChanged("Fio");
                
            }
        }

        public string Faculty
        {
            get { return _student.Faculty; }
            set
            {
                _student.Faculty = value;
                OnPropertyChanged("Faculty");
            }
        }

        public string Spec
        {
            get { return _student.Spec; }
            set
            {
                _student.Spec = value;
                OnPropertyChanged("Spec");
            }
        }

        public int? Group_
        {
            get { return _student.Group_; }
            set
            {
                _student.Group_ = value;
                OnPropertyChanged("Group_");
            }
        }

        public int? Subgroup
        {
            get { return _student.Subgroup; }
            set
            {
                _student.Subgroup = value;
                OnPropertyChanged("Subgroup");
            }
        }

        public int? Course
        {
            get { return _student.Course; }
            set
            {
                _student.Course = value;
                OnPropertyChanged("Course");
            }
        }
    }
}
