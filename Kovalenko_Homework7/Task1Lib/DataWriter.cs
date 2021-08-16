﻿using System;
using System.IO;
using System.Text.Json;


namespace Task1Lib
{
    public class DataWriter
    {
        private readonly string _fullPath;

        public DataWriter(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _fullPath = Path.GetFullPath(fileName);
        }

        public void Append(object data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(data, options);
            File.AppendAllText(_fullPath, json + "\n");
        }
    }
}
