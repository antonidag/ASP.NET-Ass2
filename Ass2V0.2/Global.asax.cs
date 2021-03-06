﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Ass2V0._2
{
    public class Global : System.Web.HttpApplication
    {
        public static User CurrentUser { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            new UserContext().Users.ToList();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }
    }
}