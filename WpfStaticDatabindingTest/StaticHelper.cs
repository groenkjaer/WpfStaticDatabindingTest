using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStaticDatabindingTest
{
    public sealed class StaticHelper : INotifyPropertyChanged//singleton
    {
        private static StaticHelper instance = null;
        private static readonly object padlock = new object();
        private static Foo g_Current = new Foo();
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

        public static StaticHelper Instance
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

        public static Foo Current
        {
            get { return g_Current; }
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

    public class Foo : INotifyPropertyChanged
    {
        private string singletonString;

        public string SingletonString
        {
            get { return singletonString; }
            set
            {
                if (singletonString != value)
                {
                    singletonString = value;
                    RaisePropertyChanged("SingletonString");
                }
            }
        }

        public Foo()
        {
            SingletonString = "Doodoo";
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
