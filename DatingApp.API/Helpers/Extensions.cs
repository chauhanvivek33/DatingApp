﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse httpResponse, string message)
        {
            httpResponse.Headers.Add("Application-Error", message);
            httpResponse.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int GetUsersAge(this DateTime DateOfBirth)
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(age) > DateTime.Today)
            {
                age--;
            }
            return age;
        }
    }
}
