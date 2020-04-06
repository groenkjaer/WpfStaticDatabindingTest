using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStaticDatabindingTest
{
    public class AnotherModel : INotifyPropertyChanged
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
