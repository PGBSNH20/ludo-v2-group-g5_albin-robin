﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Ludo_Web.MVC.Models.Translations {
    //Data model for keeping translation strings
    public static class Dict
    {
        public static string Welcome { get; private set; }
        public static string FirstName { get; private set; }
        public static string LastName { get; private set; }
    }
}