using Laba13.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba13.ViewModel
{
    public class SubjectViewModel : ViewModelBase
    {
        public Subject _subject;

        public SubjectViewModel(Subject subject)
        {
            _subject = subject;
        }

        public string Subject1
        {
            get { return _subject.Subject1; }
            set
            {
                _subject.Subject1 = value;
                OnPropertyChanged("Subject1");
            }
        }
    }
}
