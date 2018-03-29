using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitteranalyze
{
    internal partial class FileIO
    {
        private StreamWriter _streamWriter;

        private StreamReader _streamReader;

        internal FileIO(string FilePath,Enum FileMode)
        {
            switch(FileMode)
            {
                case Mode.Write:
                    _streamWriter = new StreamWriter(FilePath, true, Encoding.UTF8);
                    break;

                case Mode.Read:
                    _streamReader = new StreamReader(FilePath, Encoding.UTF8);
                    break;
            }
        }

        public static void Create(string FilePath)
        {
            using (var fc = File.Create(FilePath))
            {
                fc.Dispose();
            }
        }

        public static bool Exists(string FilePath)
        {
            if (File.Exists(FilePath))
                return true;

            return false;
        }




        //Write and Read

        public void Write(string Str)
        {
            if (_streamWriter == null)
                return;

            _streamWriter.Write(Str);
        }

        public string Read()
        {
            if (_streamReader == null)
                return null;

            return _streamReader.ReadToEnd();
        }

        public void Close()
        {
            _streamWriter.Close();
            _streamReader.Close();
        }
    }
}
