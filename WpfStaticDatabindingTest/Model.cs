using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WpfStaticDatabindingTest
{
    public class MyModel : INotifyPropertyChanged
    {
        private string myProp;

        public string MyProp
        {
            get { return myProp; }
            set
            {
                if (myProp != value)
                {
                    myProp = value;
                    StaticHelper.Current.SingletonString = value;
                    RaisePropertyChanged("MyProp");
                }
            }
        }

        public MyModel()
        {
            MyProp = StaticHelper.Current.SingletonString;

            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StaticHelper.Instance.StaticString = "No more doodoo";
            MyProp = StaticHelper.Instance.StaticString;
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
