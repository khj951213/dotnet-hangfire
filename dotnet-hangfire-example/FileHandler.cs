using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_hangfire_example
{
    public class FileHandler
    {
        public FileHandler() { }

        public void CreateFile()
        {
            try
            {
                using FileStream fs = File.Create("./test.txt");
                var info = new UTF8Encoding(true).GetBytes("Hello from hangfire");
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
