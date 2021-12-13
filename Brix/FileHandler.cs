using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Brix
{
    class FileHandler
    {

        public static void Write(string fileName, IEnumerable<string> words)
        {
            var path = @"C:\" + fileName;
            File.AppendAllLines(path, words);
        }

        public static IEnumerable<string> Read(string fileName, string path = @"C:\")
        {
            var file = File.ReadAllLines(path + fileName);
            return file;
        }

    }
}