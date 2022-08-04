using Laba13.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba13.ViewModel
{
    public class StudSubViewModel : ViewModelBase
    {
        public StudSub _studSub;

        public StudSubViewModel(StudSub studSub)
        {
            _studSub = studSub;
        }

        public int? Mark
        {
            get { return _studSub.Mark; }
            set
            {
                //int num;
                //if (Int32.TryParse(value.ToString(), out num) || value == null)
                //{
                    _studSub.Mark = value;
                    OnPropertyChanged("Mark");
                //}
                //else
                //{
                //    MessageBox.Show("Проверьте правильность введенных данных");
                //}
            }
        }

        public int? MissedHours
        {
            get { return _studSub.MissedHours; }
            set
            {
                //int num;
                //if (Int32.TryParse(value.ToString(), out num) || value == null)
                //{
                    _studSub.MissedHours = value;
                    OnPropertyChanged("MissedHours");
                //}
                //else
                //{
                //    MessageBox.Show("Проверьте правильность введенных данных");
                //}
            }
        }

    }
}
