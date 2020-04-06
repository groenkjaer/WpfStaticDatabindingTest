using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStaticDatabindingTest
{
    public class ViewModelSHIET : INotifyPropertyChanged
    {
        public MyModel Model { get; set; }
        public string StaticProperty
        {
            get { return StaticHelper.Instance.StaticString; }
            set
            {
                if (StaticHelper.Instance.StaticString != value)
                {
                    StaticHelper.Instance.StaticString = value;
                    RaisePropertyChanged("StaticProperty");
                }
            }
        }

        public ViewModelSHIET()
        {
            //Model = new MyModel();
            StaticProperty = "Hehe";
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StaticProperty = "HOHO";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
