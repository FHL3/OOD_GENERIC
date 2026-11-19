using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Generics.Models;

namespace OOD_Generics.Views
{
    public static class WeaponView
    {
        public static void DisplayWeapon(Weapon weapon)
        {
            Console.WriteLine($"{weapon.WeapId} | {weapon.Name} | {weapon.Description} | {weapon.WeaponType}");
        }
    }
}
