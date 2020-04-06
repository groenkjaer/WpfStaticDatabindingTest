using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStaticDatabindingTest
{
    public sealed class StaticHelper : INotifyPropertyChanged //singleton class
    {
        private static StaticHelper instance = null;
        private static readonly object padlock = new object();
        private string staticString;

        public string StaticString 
        { 
            get { return staticString; } 
            set 
            {
                staticString = value;
                RaisePropertyChanged("StaticString");
            } 
        }

        StaticHelper() //closed
        {
        }

        public static StaticHelper Instance //threadsafe
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StaticHelper();
                    }
                    return instance;
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
