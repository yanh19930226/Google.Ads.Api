using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SystemType = System.Type;

namespace Google.Ads.Api.Models
{
    public class OptionsBase
    {
        internal static string GetUsage(SystemType type)
        {
            PropertyInfo[] properties = type.GetProperties();

            List<string> commands = new List<string>();
            List<string> descriptions = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                OptionAttribute option = property.GetCustomAttribute<OptionAttribute>();
                commands.Add($"{option.LongName}=<{option.LongName}>");
                string requiredPrefix = option.Required ? "Required" : "Optional";
                descriptions.Add($"[{requiredPrefix}] {option.LongName}: {option.HelpText}");
            }

            return string.Join(" ", commands) + "\n" + string.Join("\n", descriptions);
        }
    }
}
