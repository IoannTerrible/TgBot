using System;
using System.Collections.Generic;
using System.IO;

namespace Deliverance
{
    public static class ConfigLoader
    {
        public static Dictionary<string, string> LoadConfig(string filePath)
        {
            var config = new Dictionary<string, string>();

            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading config file: {ex.Message}");
            }

            return config;
        }
    }
}
