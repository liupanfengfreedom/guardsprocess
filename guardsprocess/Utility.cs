using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace guardsprocess
{
    class Utility
    {
        static string path = @"C:\Program Files\Epic Games\UE_4.22\Engine\Build\BatchFiles\RunUAT.bat";
        static string Arguments = "BuildCookRun -project=D:\\ueprojecttest/MyProject/MyProject.uproject  -noP4 -platform=Android -clientconfig=Development -serverconfig=Development -cook -allmaps -stage -pak -archive";

        public static Process CommandRun(string exe, string arguments,bool buseshellexecute=true)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    FileName = exe,
                    Arguments = arguments,
                    UseShellExecute = buseshellexecute,//true mean can launch .bat file
                };
                Process p = Process.Start(info);
                //p.WaitForExit();
                return p;
            }
            catch (Exception e)
            {
                // Log.Error(e);
            }
            finally
            {
              
            }
            return null;
        }
    }
}
