using System;


namespace RPG_Characters
{
    class Program
    {
        static void Main(string[] args)
        {

            Warrior warrior = new Warrior("simon");
            warrior.DisplayCharacterInfo();

            Console.ReadLine();



        }
    }
}
