using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_system
{
    public static class appManager
    {
        //test
        public static login loginForm;
        public static instructorF instructorForm;
        public static studentF studentForm;
        public static sqlProjectEntities entities;
        public static string currentUserName;

        static appManager()
        {
            //initialize the three main forms to use them during the app
            //to show and close them anywhere in the app and easily access them
            loginForm = new login();
            instructorForm = new instructorF();
            studentForm = new studentF();
            entities = new sqlProjectEntities();
        }
    }
}
