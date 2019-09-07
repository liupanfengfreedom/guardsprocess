using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace guardsprocess
{
    class ProcessInfor
    {
      public  Process mprocess;
      public  string  apppath;
      public  string  parameter;
    }
    class Program
    {
        static void Main(string[] args)
        {          
            guardprocess(@"E:\VsProjects\Server\Server\bin\Release\Server.exe","",false);
            guardprocess(@"E:\VsProjects\LoginServerv1\LoginServer\bin\Release\LoginServer.exe", "", false);
            guardprocess(@"E:\VsProjects\deletebinaries\deletebinaries\bin\Release\deletebinaries.exe", "",true);
        }
        public static void guardprocess(string path,string Arguments,bool buseshellexecute=true) {
            Process p1 = Utility.CommandRun(path, Arguments, buseshellexecute);
            ProcessInfor pi1 = new ProcessInfor();
            pi1.mprocess = p1;
            pi1.apppath = path;
            pi1.parameter = Arguments;
            if (p1 != null)
            {
                Thread newThread = new Thread(Program.DoWork);
                newThread.Start(pi1);
            }
        }
        public static void DoWork(object p)
        {
            ProcessInfor p1 = (ProcessInfor)p;
            while (true)
            {
                Thread.Sleep(500);
                bool b = p1.mprocess.HasExited;
                if (b)
                {
                    Process p2 = Utility.CommandRun(p1.apppath, p1.parameter);
                    ProcessInfor pi1 = new ProcessInfor();
                    pi1.mprocess = p2;
                    pi1.apppath = p1.apppath;
                    pi1.parameter = p1.parameter;
                    if (p2 != null)
                    {
                        Thread newThread = new Thread(Program.DoWork);
                        newThread.Start(pi1);
                    }
                    break;
                }
            }
        }
    }
}
