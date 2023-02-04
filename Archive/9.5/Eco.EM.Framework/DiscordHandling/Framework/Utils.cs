﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Eco.EM.Framework.Discord
{
    public static class Utils
    {
        /// <summary>
        /// Convert Color object into hex integer
        /// </summary>
        /// <param name="color">Color to be converted</param>
        /// <returns>Converted hex integer</returns>
        public static int ColorToHex(Color color)
        {
            string HS =
                color.R.ToString("X2") +
                color.G.ToString("X2") +
                color.B.ToString("X2");

            return int.Parse(HS, System.Globalization.NumberStyles.HexNumber);
        }

        internal static JObject StructToJson(object @struct)
        {
            Type type = @struct.GetType();
            JObject json = new();

            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                string name = FieldNameToJsonName(field.Name);
                object value = field.GetValue(@struct);
                if (value == null)
                    continue;

                if (value is bool boolean)
                    json.Add(name, boolean);
                else if (value is int @int)
                    json.Add(name, @int);
                else if (value is Color color)
                    json.Add(name, ColorToHex(color));
                else if (value is string)
                    json.Add(name, value as string);
                else if (value is DateTime time)
                    json.Add(name, time.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"));
                else if (value is IList && value.GetType().IsGenericType)
                {
                    JArray array = new();
                    foreach (object obj in value as IList)
                        array.Add(StructToJson(obj));
                    json.Add(name, array);
                }
                else json.Add(name, StructToJson(value));
            }
            return json;
        }

        static readonly string[] ignore = { "InLine" };
        internal static string FieldNameToJsonName(string name)
        {
            if (ignore.ToList().Contains(name))
                return name.ToLower();

            List<char> result = new();

            if (IsFullUpper(name))
                result.AddRange(name.ToLower().ToCharArray());
            else
                for (int i = 0; i < name.Length; i++)
                {
                    if (i > 0 && char.IsUpper(name[i]))
                        result.AddRange(new[] { '_', char.ToLower(name[i]) });
                    else result.Add(char.ToLower(name[i]));
                }
            return string.Join("", result);
        }

        internal static bool IsFullUpper(string str)
        {
            bool upper = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsUpper(str[i]))
                {
                    upper = false;
                    break;
                }
            }
            return upper;
        }

        public static string Decode(Stream source)
        {
            using StreamReader reader = new(source);
            return reader.ReadToEnd();
        }

        public static byte[] Encode(string source, string encoding = "utf-8")
            => Encoding.GetEncoding(encoding).GetBytes(source);
    }
}
