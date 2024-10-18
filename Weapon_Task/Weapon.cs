using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;

namespace Weapon_Task
{
    internal class Weapon
    {
        private string _name;
        private int _bulletCapacity;
        private int _currentBullet;
        private string _fireMode = "single";
        private static int _counter;
        public int ID { get; private set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else Console.WriteLine("Silah adi bos ola bilmez");
            }
        }
        public int BulletCapacity
        {
            get { return _bulletCapacity; }
            set
            {
                if (value > 0) _bulletCapacity = value;
                else Console.WriteLine("Gulle Tutumu 0dan boyuk olmalidir\n");
            }
        }

        public int CurrentBullet
        {
            get { return _currentBullet; }
            set
            {
                if (value >= 0 && value <= _bulletCapacity)
                {
                    _currentBullet = value;
                }
                else Console.WriteLine("Cari gulle sayi daraq tutumundan boyuk ve ya menfi ola bilmez\n");
            }
        }

        public string FireMode
        {
            get { return _fireMode; }
            set
            {
                if (value.ToLower() == "single" || value.ToLower() == "auto")
                {
                    _fireMode = value.ToLower();
                }
                else Console.WriteLine("Atis modu yalniz single ve ya auto olaraq qeyd edile biler\n");
            }
        }


        public Weapon(string name, int capasity, int currentBullet, string mode)
        {
            Name = name;
            BulletCapacity = capasity;
            CurrentBullet = currentBullet;
            FireMode = mode;
            _counter++;
            ID = _counter;
        }


        public Weapon CreateWeapon()
        {
            string name = Program.GetInput("Silah adi daxil et: ");
            int.TryParse(Program.GetInput("Daraq tutumu: "), out int cap);
            int.TryParse(Program.GetInput("Cari gulle sayi: "), out int cur);
            string mode = Program.GetInput("Atis modu: ");
            Console.WriteLine();

            return new Weapon(name, cap, cur, mode);
        }



        public void Shoot()
        {
            if (CurrentBullet == 0)
            {
                Console.WriteLine("Daraqda gulle yoxdur\n");
                return;
            }

            if (FireMode == "single")
            {
                CurrentBullet -= 1;
                Console.WriteLine("1 gulle ateslendi\n");
            }
            else
            {
                CurrentBullet = 0;
                Console.WriteLine("Daraqdaki butun gulleler bosaldildi\n");
            }

        }
        public int GetRemainBulletCount()
        {
            return CurrentBullet;
        }

        public void Reload()
        {
            CurrentBullet = BulletCapacity;
            Console.WriteLine($"Daraqdaki gulle sayi yenilendi. Indi daraqda {CurrentBullet} sayda gulle var\n");
        }

        public void ChangeFireMode()
        {
            string newMode = (FireMode == "single") ? "auto" : "single";

            FireMode = newMode;
            Console.WriteLine($"Atis modu {FireMode} olaraq deyisdirildi\n");
        }

    }
}
