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
            bool FileExist = false;

            string tmp;



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
                else
                {
                    FileExist = true;
                }
            }


            if (!FileExist)
            {
                tmp = String.Empty;

                Console.WriteLine("Please enter keys");

                Console.Write("AToken : ");
                tmp = Console.ReadLine();

                tmp += ',';

                Console.Write(Environment.NewLine + "ASecret : ");
                tmp += Console.ReadLine();

                tmp += ',';

                Console.Write(Environment.NewLine + "Ckey : ");
                tmp += Console.ReadLine();

                tmp += ',';

                Console.Write(Environment.NewLine + "CSecret : ");
                tmp += Console.ReadLine();

                FileIO fw = new FileIO(EnviromentStruct.SetFile, FileIO.Mode.Write);

                fw.Write(tmp);

                fw.Close();

                tmp = null;


            }


            FileIO fr = new FileIO(EnviromentStruct.SetFile, FileIO.Mode.Read);

            tmp = fr.Read();

            fr.Close();

            TwitterSharp.TwitterSharp twitterSharp = new TwitterSharp.TwitterSharp(tmp.Split(',')[0], tmp.Split(',')[1], tmp.Split(',')[2], tmp.Split(',')[3]);
            

            twitterSharp.Authentication();


            tmp = null;


        
            TwitterSharp.TwitterSharp.Follower follower = new TwitterSharp.TwitterSharp.Follower();

            follower.Followers();



            FileIO fileIO ;

            string[] arrayTmp = new string[6];

            for (int i = 0; i < follower.FollowerCount; i++)
            {
                for(int j = 0; j < 6; j++)
                    arrayTmp[j] =  null;

                tmp = null;



                arrayTmp = follower.FollowerSt(0);

                if (!FileIO.Exists("ディレクトリの場所" + arrayTmp[5] + ".txt"))
                    FileIO.Create("ディレクトリの場所" + arrayTmp[5] + ".txt");

                //追加書き込み

                tmp = arrayTmp[0] + " " + arrayTmp[1] + " " + arrayTmp[2] + " " + arrayTmp[3] + " " + arrayTmp[4] + " " + arrayTmp[5];
          
                fileIO = new FileIO(arrayTmp[5] + ".txt", FileIO.Mode.Write);
                fileIO.Write(tmp);
                fr.Close();
              
                   
            }



        }
    
      


        private class EnviromentStruct
        {
            public static readonly string SetPath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Twitter";
            public static readonly string SetFile = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Twitter\app.conf";
        }
    }
    
}
