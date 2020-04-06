using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStaticDatabindingTest
{
    public class SecondViewModel
    {
        public MyModel Model { get; set; }

        public SecondViewModel()
        {
            Model = new MyModel();
        }
    }
}
