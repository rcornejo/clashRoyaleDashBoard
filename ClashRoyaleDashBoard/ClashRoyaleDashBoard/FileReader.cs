using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleDashBoard
{
    static class FileReader
    {
        static string path = Environment.CurrentDirectory;
        static string fileName = "token.txt";
        public static string readToken() {
            string token = String.Empty;

            // Read the file as one string.
            token = System.IO.File.ReadAllText(string.Format("{0}\\{1}",path,fileName));
            return token;
        }
    }
}
