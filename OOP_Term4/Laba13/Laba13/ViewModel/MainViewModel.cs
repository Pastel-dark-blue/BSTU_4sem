using Laba13.Commands;
using Laba13.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba13.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public ObservableCollection<StudSubViewModel> StudSubList;
        public ObservableCollection<SubjectViewModel> SubjectsList;

        private StudentViewModel selectedStudent;
        public StudentViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                SelectedStudStudSubList = null;
                SelectedStudSubjectsList = null;
                NewMark = "";
                OnPropertyChanged("selectedStudent");
            }
        }

        private SubjectViewModel selectedSubject;
        public SubjectViewModel SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                SelectedStudSubMarksList = null;
                SelectedStudSubMissedHours = null;
                OnPropertyChanged("selectedSubject");
            }
        }

        private string newMark;
        public string NewMark
        {
            get { return newMark; }
            set
            {
                newMark = value;
                OnPropertyChanged("NewMark");
            }
        }

        // взаимосвязь между таблицей студентов и предметов, записи о выбранном из списка студенте
        public ObservableCollection<StudSubViewModel> selectedStudStudSubList;
        public ObservableCollection<StudSubViewModel> SelectedStudStudSubList
        {
            get { return selectedStudStudSubList; }
            set
            {
                //IEnumerable<StudSubViewModel> selectedStudSub = null;
                if (SelectedStudent != null && StudSubList != null) 
                {
                    var selectedStudSub = from ss in StudSubList
                                      where ss._studSub.StudId == SelectedStudent._student.Id
                                      select ss;

                    selectedStudStudSubList = new ObservableCollection<StudSubViewModel>(selectedStudSub);
                    
                    OnPropertyChanged("selectedStudStudSubList");
                }
            }
        }


        //public ObservableCollection<SubjectViewModel> SubjectsList { get; set; }

        private ObservableCollection<SubjectViewModel> selectedStudSubjectsList;
        public ObservableCollection<SubjectViewModel> SelectedStudSubjectsList
        {
            get { return selectedStudSubjectsList; }
            set
            {
                if (SubjectsList != null)
                {
                    var selectedSubs = (from s in SubjectsList
                                       from ss in SelectedStudStudSubList
                                       where s._subject.Id == ss._studSub.SubId
                                       select s._subject).Distinct();

                    if(selectedSubs != null)
                        selectedStudSubjectsList = new ObservableCollection<SubjectViewModel>(selectedSubs.Select(s => new SubjectViewModel(s)));
                    else
                        selectedStudSubjectsList = null;
                    
                    OnPropertyChanged("selectedStudSubjectsList");
                }
            }
        }

        private ObservableCollection<StudSubViewModel> selectedStudSubMarksList;
        public ObservableCollection<StudSubViewModel> SelectedStudSubMarksList
        {
            get { return selectedStudSubMarksList; }
            set
            {
                if (SubjectsList != null && selectedStudSubjectsList != null) 
                {
                    var selectedSubMarks = from s in SelectedStudStudSubList
                                           where SelectedSubject._subject.Id == s._studSub.SubId &&
                                                    s._studSub.Mark != null
                                           select s._studSub;

                    if (selectedSubMarks != null)
                        selectedStudSubMarksList = new ObservableCollection<StudSubViewModel>(selectedSubMarks.Select(s => new StudSubViewModel(s)));
                    else
                        selectedStudSubMarksList = null;

                    OnPropertyChanged("SelectedStudSubMarksList");
                }
            }
        }

        private string selectedStudSubMissedHours;
        public string SelectedStudSubMissedHours
        {
            get { return selectedStudSubMissedHours; }
            set
            {
                if (SubjectsList != null && selectedStudSubjectsList != null && value == null) 
                {
                    var selectedSubMissedHours =   from s in SelectedStudStudSubList
                                                   where SelectedSubject._subject.Id == s._studSub.SubId
                                                   select s._studSub;

                    if (selectedSubMissedHours != null) 
                    {
                        var missedHours = new List<StudSubViewModel>(selectedSubMissedHours.Select(s => new StudSubViewModel(s)));
                        if (missedHours.Count != 0) 
                            selectedStudSubMissedHours = missedHours[missedHours.Count - 1]._studSub.MissedHours.ToString();
                        else
                            selectedStudSubMissedHours = null;
                    }
                    else
                    {
                        selectedStudSubMissedHours = null;
                    }

                    OnPropertyChanged("SelectedStudSubMissedHours");
                }
                else
                {
                    selectedStudSubMissedHours = value;
                }
            }
        }


        public ObservableCollection<StudentViewModel> StudentsList { get; set; }

        public MainViewModel(List<Student> _students, List<StudSub> _studMarks, List<Subject> _subjects)
        {
            StudentsList = new ObservableCollection<StudentViewModel>(_students.Select(s => new StudentViewModel(s)));
            StudSubList = new ObservableCollection<StudSubViewModel>(_studMarks.Select(sm => new StudSubViewModel(sm)));
            SubjectsList = new ObservableCollection<SubjectViewModel>(_subjects.Select(sub => new SubjectViewModel(sub)));
        }

        // команды
        private RelayCommand addMarkCommand;
        public RelayCommand AddMarkCommand
        {
            get {
                return addMarkCommand ??
                    (addMarkCommand = new RelayCommand(obj =>
                    {
                        if (obj.ToString() == "") MessageBox.Show("empty");
                        using (UniverDBModel db = new UniverDBModel())
                        {
                            StudSub newSS = new StudSub();
                            newSS.SubId = SelectedSubject._subject.Id;
                            newSS.StudId = selectedStudent._student.Id;
                            newSS.MissedHours = Int32.Parse(SelectedStudSubMissedHours);
                            newSS.Mark = Int32.Parse(obj.ToString());

                            db.StudSub.Add(newSS);
                            db.SaveChanges();

                            StudSubList = new ObservableCollection<StudSubViewModel>((db.StudSub.ToList()).Select(sm => new StudSubViewModel(sm)));
                            SelectedStudStudSubList = null;
                            SelectedStudSubMarksList = null;
                        }
                    },
                     // условие, при котором будет доступна команда
                     (obj) =>
                     {
                         if (obj != null && obj.ToString() != "" && SelectedSubject != null)
                             return true;
                         else
                             return false;
                     })); 
            }
        }


        private RelayCommand changeMissedHoursCommand;
        public RelayCommand ChangeMissedHoursCommand
        {
            get
            {
                return changeMissedHoursCommand ??
                    (changeMissedHoursCommand = new RelayCommand(obj =>
                    {
                        using (UniverDBModel db = new UniverDBModel())
                        {
                            StudSub newSS = new StudSub();
                            newSS.SubId = SelectedSubject._subject.Id;
                            newSS.StudId = selectedStudent._student.Id;
                            newSS.MissedHours = Int32.Parse(SelectedStudSubMissedHours);
                            newSS.Mark = null;

                            db.StudSub.Add(newSS);
                            db.SaveChanges();

                            StudSubList = new ObservableCollection<StudSubViewModel>((db.StudSub.ToList()).Select(sm => new StudSubViewModel(sm)));
                            SelectedStudStudSubList = null;
                            SelectedStudSubMissedHours = null;
                        }
                    }, (obj) =>
                        {
                            if (SelectedStudSubMissedHours != null && SelectedSubject != null)
                                return SelectedStudSubMissedHours.ToString() != "";
                            else 
                                return false;
                        })); 
            }
        }
    }
}