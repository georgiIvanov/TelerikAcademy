using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace _01.SearchControls
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Initializer.Producers = new List<Producer>();

            string[] models = {"S2", "S4", "A5", "S7", "S8", "A6", "A7", "A8"};

            Initializer.Producers.Add(new Producer("Audi", models));

            models = new string[] { "545", "525", "528", "745", "750", "760", "840"};

            Initializer.Producers.Add(new Producer("BMW", models));

            models = new string[] { "S550", "S600", "S63", "S65", "SLS", "SL 65" };

            Initializer.Producers.Add(new Producer("Mercedes", models));

            Extra[] extras = {new Extra("Air conditioner"), new Extra("Electric windows"), new Extra("Parktronik"),
                                 new Extra("Cruise Control"), new Extra("Automatic brake system")};

            Initializer.Extras = new List<Extra>(extras);

            string[] engineTypes = { "Diesel", "Petrol", "Electric", "Hybrid" };

            Initializer.EngineTypes = engineTypes.ToList();
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
    }
}