using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics.Views
{
    public static class GuildView
    {
        public static void DisplayGuild(Guild guild)
        {
            Console.WriteLine($"{guild.GuId} | {guild.Name} | {guild.Description}");
        }
    }
}
