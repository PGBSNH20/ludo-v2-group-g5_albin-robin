﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LudoTranslation
{
    public class TranslationEngine
    {
        private readonly Dictionary<string, string> Dictionary;

         public TranslationEngine()
        {
            Dictionary = new Dictionary<string, string>();
        }

        public void InitializeLanguage(string lang)
        {
            var line = "";
            var reader = new StreamReader(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "/Translations/" + lang + ".lang");
            while ((line = reader.ReadLine()) != null && !string.IsNullOrWhiteSpace(line) && line.Contains("=="))
            {
                var lineSplit = line.Split("==");
                Dictionary.Add(lineSplit[0], lineSplit[1]);
                foreach (var prop in typeof(Dict).GetProperties())
                    prop.SetValue(null, Dictionary.SingleOrDefault(k => k.Key == prop.Name).Value);
            }
        }

        public static class Languages
        {
            public const string en_US = "en_US";
            public const string sv_SE = "sv_SE";
            public static bool Contains(string input)
            {
                return typeof(Languages).GetFields().Select(f => f.Name.ToLower()).ToList().Contains(input.ToLower());
            }
            public static List<string> GetLanguages()
            {
                return typeof(Languages).GetFields().Select(f => f.Name).ToList();
            }
        }
        /*
         * Archived code.
           Language used to be an enum
           
        public Language ParseEnum(string language)
        {
            var success = Enum.TryParse(language, true, out Language lang);
            return success ? lang : Language.en_US;
        }
        public bool EnumExists(string language)
        {
            var success = Enum.TryParse(language, true, out Language lang);
            return success;
        }
        */
    }
}