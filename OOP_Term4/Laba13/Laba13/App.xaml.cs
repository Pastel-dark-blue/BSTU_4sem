using Laba13.Model;
using Laba13.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Laba13
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Student> students = new List<Student>();
            List<StudSub> studSubs = new List<StudSub>();
            List<Subject> subjects = new List<Subject>();

            using (UniverDBModel db=new UniverDBModel())
            {
                students = db.Student.ToList();
                studSubs = db.StudSub.ToList();
                subjects = db.Subject.ToList();
            }

            StudentView newWin = new StudentView();
            MainViewModel vmodel = new MainViewModel(students, studSubs, subjects);
            newWin.DataContext = vmodel;
            newWin.Show();
        }
    }
}
