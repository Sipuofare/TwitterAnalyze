using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;


namespace Twitteranalyze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("" + Environment.NewLine + "" + Environment.NewLine);

            if (!FileIO.DirectoryGroup.Exists(EnviromentStruct.SetPath))
            {

                try
                {
                    FileIO.DirectoryGroup.MkDir(EnviromentStruct.SetPath); FileIO.Create(EnviromentStruct.SetFile);
                    FileIO.Create(EnviromentStruct.SetFile);
                }
                catch
                {
                    Console.WriteLine("error");
                    return;
                }

            }
            else
            {
                if (!FileIO.Exists(EnviromentStruct.SetFile))
                    try
                    {
                        FileIO.Create(EnviromentStruct.SetFile);
                    }
                    catch
                    {
                        Console.WriteLine("error");
                        return;
                    }
            }








        }
    
      


        private class EnviromentStruct
        {
            public static readonly string SetPath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Twitter";
            public static readonly string SetFile = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Twitter\app.conf";
        }
    }
    
}
