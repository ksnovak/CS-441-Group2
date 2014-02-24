using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MathDrillGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //These 3 are static variables so that I can use them throughout the program. The userlist will be XML, but there must be a better way than this for the other 2.
        public static List<User> users = new List<User>();
        public static int currentUserIndex; //Who is logged in
        public static int targetUser; //For the admin, this is who to generate problems for.

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Directory.CreateDirectory(@"c:\users\public\MathDrills\ProblemSets"); //Make sure there is a directory into which to save the problems

            Application.Run(new LoginForm());
        }
    }
}
