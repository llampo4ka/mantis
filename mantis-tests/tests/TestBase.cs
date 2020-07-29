﻿using System;
using System.Text;
using NUnit.Framework;


namespace mantis_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        //public static bool PERFORM_LONG_UI_CHECKS = true;

        [SetUp]
        public void SetupApplicationManager()
        {

            app = ApplicationManager.GetInstance();

            app.Auth.Login(new AccountData("administrator", "root"));

        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 65 + 32)));
            }
            return builder.ToString();
        }

    }
}
