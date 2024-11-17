using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAPIs.Models
{
    internal class BitcoinModel
    {
        //restSharp can not deseialize Property1, because it doesn't exist in the json response!
        /*
            public class Rootobject
            {
                public Class1[] Property1 { get; set; }
            }

            public class Class1
            {
        */
        public string title { get; set; }
        public string url { get; set; }
        public string source { get; set; }
    }

}
