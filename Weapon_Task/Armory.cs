namespace Weapon_Task
{
    internal class Armory
    {
        public readonly string name = "My armory";

        Weapon[] weapons = new Weapon[0];

        public void AddWeapon(Weapon weapon)
        {
            Array.Resize(ref weapons, weapons.Length + 1);
            weapons[^1] = weapon;
        }

        public void ShowWeapons()
        {
            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine($"Silah adi: {weapon.Name}\nDaraq tutumu: {weapon.BulletCapacity}\nCari gulle sayi: {weapon.CurrentBullet}\nAtis modu: {weapon.FireMode}\nSilah ID: {weapon.ID}\n");
            }
        }

        public Weapon GetWeapon(int id)
        {
            Weapon weapon = null;
            do
            {
                foreach (Weapon w in weapons)
                {
                    if (id == w.ID)
                    {
                        weapon = w;
                        return weapon;
                    }
                }
                Console.WriteLine("Duzgun ID daxil edin");
                int.TryParse(Program.GetInput("Duzgun ID daxil edin"), out id);
            }
            while (weapon == null);
            return weapon;
        }

    }
}
