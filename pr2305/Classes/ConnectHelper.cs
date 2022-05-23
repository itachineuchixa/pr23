using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pr2305.Classes
{
    class ConnectHelper
    {
        public static List<Workers> worker = new List<Workers>();
        public static string fileName;


        public static void SaveListToFile(string filename)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
            foreach (Workers st in worker)
            {
                streamWriter.WriteLine(st.ToString());
            }
            streamWriter.Close();
        }
    }
}
