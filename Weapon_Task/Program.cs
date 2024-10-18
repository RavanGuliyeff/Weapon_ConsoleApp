using System.Runtime.InteropServices.JavaScript;

namespace Weapon_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Armory armory = new Armory();
            Weapon weapon1 = new Weapon("AK47", 40, 20, "single");
            armory.AddWeapon(weapon1);
            Weapon curWeapon = weapon1;
            bool c = false;

            do
            {
                string choice = GetInput("1 - Movcud silahlari gostermek ucun\n2 - Ates acmaq ucun\n3 - Daraqda qalan gulle sayini gormek üçün\n4 - Daragi yenilemek üçün\n5 - Atis modunu deyismek üçün\n0 - Proqrami dayandırmaq üçün\n");

                switch (choice)
                {
                    case "0":
                        c = true;
                        break;

                    case "1":
                        armory.ShowWeapons();
                        bool d = false;
                        do
                        {
                            Console.WriteLine($"Hazirda secili olan silah: {curWeapon.Name}\n");
                            string choice2 = GetInput("1 - Silah secimi Menyusu\n2 - Silah elave etmek\n3 - Secili silahda deyisiklik etmek\n0 - Menyudan cixmaq\n");
                            switch (choice2)
                            {
                                case "0":
                                    d = true;
                                    break;

                                case "1":
                                    int.TryParse(GetInput("Silah ID nomresi daxil et:"), out int id);
                                    curWeapon = armory.GetWeapon(id);
                                    break;

                                case "2":
                                    armory.AddWeapon(weapon1.CreateWeapon());
                                    armory.ShowWeapons();
                                    break;

                                case "3":
                                    bool y = false;
                                    do
                                    {
                                        Console.WriteLine($"Hazirda secili olan silah: {curWeapon.Name}");
                                        string choice3 = GetInput("1 - Silah adi\n2 - Daraq tutumu\n3 - Cari gulle sayi\n0 - Menyudan cixis\n");
                                        switch (choice3)
                                        {
                                            case "1":
                                                curWeapon.Name = GetInput("Yeni ad daxil edin: ");
                                                armory.ShowWeapons();
                                                break;
                                            case "2":
                                                int.TryParse(GetInput("Yeni silah tutumu daxil edin: "), out int newCap);
                                                curWeapon.BulletCapacity = newCap;
                                                if (curWeapon.CurrentBullet > curWeapon.BulletCapacity) curWeapon.CurrentBullet = curWeapon.BulletCapacity;
                                                armory.ShowWeapons();
                                                break;
                                            case "3":
                                                int.TryParse(GetInput("Yeni cari gulle sayi daxil edin: "), out int newCur);
                                                curWeapon.CurrentBullet = newCur;
                                                armory.ShowWeapons();
                                                break;
                                            case "0":
                                                y = true;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    while (!y);
                                    break;
                            }

                        }
                        while (!d);
                        break;

                    case "2":
                        curWeapon.Shoot();
                        break;

                    case "3":
                        Console.WriteLine(curWeapon.GetRemainBulletCount());
                        break;

                    case "4":
                        curWeapon.Reload();
                        break;

                    case "5":
                        curWeapon.ChangeFireMode();
                        break;
                    default:
                        break;
                }
            }
            while (!c);
        }


        public static string GetInput(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

    }
}
