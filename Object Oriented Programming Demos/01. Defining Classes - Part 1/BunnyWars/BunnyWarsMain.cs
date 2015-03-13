﻿namespace BunnyWars
{
    using Animals;
    using Bunnies;
    using System;
    using System.Collections.Generic;

    class BunnyWarsMain
    {
        static void ChangeBunny(Bunny bunny)            // static method
        {
            bunny.Health = 0;
        }

        static void Main()
        { 
            //Bunnies.Bunny ivanBunny = new Bunnies.Bunny();  // constructor, if there is not namespace using Bunnies;

            //Bunny peshoBunny = new Bunny();         // constructor => create new object bunny
            //Console.WriteLine(peshoBunny);   // Bunnies.Bunny

            Bunny blueBunny = new Bunny("Ivan", "Blue");

            Bunny zayoBunny = new Bunny("Zayo");
            //Console.WriteLine(zayoBunny);      // Bunnies.Bunny
            //zayoBunny.ChangeColor("Red");   // this could be made by properties also
            ulong currentZayoCarrots = zayoBunny.AddCarrots(100);
            Console.WriteLine("Zayo carrots = " + currentZayoCarrots);

            Bunny bugsBunny = new Bunny("Bugs", "White");
            ulong currentBugsCarrots = bugsBunny.AddCarrots(2000);
            Console.WriteLine("Bugs carrots = " + currentBugsCarrots);

            string zayoName = zayoBunny.Name;   // we need property for that
            Console.WriteLine(zayoName);
            //zayoBunny.Name = "Koko";            // won't work because the property is read only (only get)

            string color = zayoBunny.Color; // get
            zayoBunny.Color = "Blue";       // set

            zayoBunny.Health = 150;
            Console.WriteLine(zayoBunny.Health);

            Console.WriteLine(zayoBunny.isRetired);
             
            //zayoBunny.Retire();
            zayoBunny.Health -= 250;
            zayoBunny.Retire();
            Console.WriteLine(zayoBunny.isRetired);

            //Animal animal = new Animal(); // won't work because the class Animal is abstract

            //Console.WriteLine(Bunny.NumberOfLegs); 
            //doesn't work because it's private 
            //works, if it's:   public static int NumberOfLegs = 4;   but it's not ok to be public

            var chipiBunny = new Bunny("Chipi");
            //Bunny chipiBunny = new Bunny("Chipi");

            Console.WriteLine(chipiBunny.Health);    // 100

            ChangeBunny(chipiBunny);

            Console.WriteLine(chipiBunny.Health);    // 0

            // create a Bunny collection
            List<Bunny> bunnies = new List<Bunny>();

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Bunny currentBunny = new Bunny(new string((char)i, 10));
                currentBunny.Health = random.Next(0, 100);
                bunnies.Add(currentBunny);
            } 

            //foreach (var bunny in bunnies)
            //{
            //    Console.WriteLine(bunny.Name + " " + bunny.Health);
            //}


            // initialize a list zayoAndChipi
            var zayoAndChipi = new List<Bunny>
            {
                zayoBunny,
                chipiBunny
            };

            foreach (var bunny in zayoAndChipi)
            {
                Console.WriteLine(bunny.Name);
            }

            
            AirCraft firstAirCraft = new AirCraft(chipiBunny, 60);
            AirCraft secondAirCraft = new AirCraft(bugsBunny, 80);

            Console.WriteLine(secondAirCraft.Pilot.Health); // 100

            firstAirCraft.Attack(secondAirCraft);   // 40

            Console.WriteLine(secondAirCraft.Pilot.Health);

            //AirCraft.Speed();   // this method exist, but firstAirCraft.Speed() don't, because the method Speed() is static
        } 
    }
}
