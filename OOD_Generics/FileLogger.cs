using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public class FileLogger
    {
        public void LogError(Exception ex, string filePath, string errorLocation)
        {
            using StreamWriter w = new StreamWriter(filePath);
            w.WriteLine($"{ex.Message} {ex.GetType().Name}");
        }
    }
}
