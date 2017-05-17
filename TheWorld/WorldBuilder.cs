﻿using System;

namespace TheWorld
{
    /// <summary>
    /// World builder is responsible for all World creation.  
    /// It is a static class because it is only used once at the beginning of the program to construct the world.
    /// </summary>
    public static class WorldBuilder
    {
        /// <summary>
        /// Builds the world. This is the method where you design your world.  Create Areas, Populate those Areas, and then link those areas together.
        /// If an area is particularly complicated, you may consider writing a helper method to break that part out.
        /// 
        /// This method returns the starting Area which is linked to the rest of the World.
        /// </summary>
        /// <returns>The starting area linked to the rest of the world.</returns>
        public static Area BuildWorld()
        {
            // This is going to be the area where the player starts.
            Area start = new Area() { Name = "The Field", Description = "A wide grassy field with not much to see." };

            // I can create a new Item and add it directly into the Area without having a separate variable for it!  Convenient!
            start.AddItem(new Item()
            {
                Name = "Boulder",
                Description = "It's a big granite boulder.  It has a weird glyph carved into it, but you can't make any sense of it."
            }, "boulder");

            // Doing it again--no separate variable for the new item.  It goes directly into the created area.
            start.AddItem(new Item() { Name = "Grass", Description = "Grass... Lots of Grass... Like... Everywhere." },
                "grass");

            // I can do that with any kind of object that I can create entirely in one command.
            // Don't forget that last word is the Unique Identifier.  So I can't have more than one thing in my area named "bunny"
            start.AddCreature(new Creature()
            {
                Name = "Bunny Rabbit",
                Description = "A cute bunny.  Looks pretty tasty actually...",
                Stats = new StatChart() { Level = 1, MaxHPs = 10, HPs = 10, Atk = 2, Def = 0 }
            }, "bunny");

            start.AddCreature(new Creature()
            {
                Name = "brog",
                Description = "The deadly brog.  Its slippery slimeys scare the children. Beware the brog",
                Stats = new StatChart() { Level = 1, MaxHPs = 10, HPs = 10, Atk = 2, Def = 0 }
            }, "brog");

            // Here's a second area.
            Area stream = new Area()
            {
                Name = "Stream",
                Description = "A burbling stream.  There are some rocks that look like you could cross them to get to the other side."
            };

            // I will populate it with items and creatures in the same way...
            stream.AddItem(new Item()
            {
                Name = "Lizard",
                Description = "A funny lizard with a black stripe down its back.  It doesn't look intimidated by your presence," +
                " but it doesn't look very interested either. Upon closer inspection, it might not be alive..."
            }, "lizard");

            stream.AddCreature(new Creature()
            {
                Name = "Frog",
                Description = "A crazy big frog!  It looks like it could eat a bird if it caught one.  It also doesn't look happy.",
                Stats = new StatChart() { MaxHPs = 10, HPs = 10, Atk = 2, Def = 1, Level = 1 }
            }, "frog");


            // These two lines LINK the two areas together.  Don't forget to go both ways or you'll end up with a dead end
            // and no way out!!!
            start.AddNeighbor(stream, "north");
            stream.AddNeighbor(start, "south");

<<<<<<< HEAD
            Area brogland = new Area()
            {
                Name = "dark ominous land",
                Description = "A dark and desolate land over the horizon. The brogs rule this land. Beware The Land of the Brogs."
            };
            start.AddNeighbor(brogland, "south");
            brogland.AddNeighbor(start, "north");
            start.AddItem(new Item()
            {
                Name = "Brog Oil",
                Description = "A valuable bottle of brog oil, harvested from a brog with great dificulty," +
                " use it wisely"
            }, "brogoil");

            start.AddItem(new Item()
            {
                Name = "Brog Butter",
                Description = "A slop of brog butter. Slimp it down your throat to make for a sloppery evening"
            }, "brogbutter");

           
            Area acrossTheRiver = new Area()
            {
                Name = "Forest",
                Description = "This is the other side of the river! It is a forest clearing. It's muddy here..."
            };

            stream.AddNeighbor(acrossTheRiver, "rocks");
            acrossTheRiver.AddNeighbor(stream, "rocks");



            acrossTheRiver.AddItem(new Item()
            {
                Name = "Sparkling Rock",
                Description = "It's a really fancy rock. Look at it sparkle!",
                Value = new Money() { Gold = 3 }
            }, "sparkling-rock");

            acrossTheRiver.AddCreature(new Creature()
            {
                Name = "Trogdor the Burninator",
                Description = "Look at those beefy arms!",
                Stats = new StatChart() { HPs = 100, MaxHPs = 100, Level = 10, Atk = 100, Def = 100 }
            }, "dragon");

            acrossTheRiver.AddCreature(CreateWorm("Phil"), "phil");
            acrossTheRiver.AddCreature(CreateWorm("Janice"), "janice");

            Area beach = new TheWorld.Area()
            {
                Name = "Beach",
                Description = "A sandy beach. Small fry dart around in the water.",
            };

            start.AddNeighbor(beach, "east");
            beach.AddNeighbor(start, "west");

            beach.AddCreature(new Creature()
            {
                Name = "Giant Crab",
                Description = "It's a giant crab. Those claws look nasty!",
                Stats = new StatChart() { HPs = 25, MaxHPs = 25, Atk = 10, Def = 10, Level = 5 }
            }, "giant-crab");




            return start;
        }

        /// <summary>
        /// Create a generic Worm creature.

        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        private static Creature CreateCox(String name)
        {
            return new Creature()
            {
                Name = name,
                Description = "It's a wild Jason Cox!",
                Stats = new StatChart() { HPs = 90, Atk = 5, Def = -5, Level = 10, MaxHPs = 95 }
                
            };
        }

        private static Creature CreateWorm(String name)
        {
            return new Creature()
            {
                Name = name,
                Description = "It's a worm!",
                Stats = new StatChart() { HPs = 2, Atk = 0, Def = 0, Level = 0, MaxHPs = 2 }
            };
        }

        private static Item CreateItem(String name)
        {
            return new Item()
            {
                Name = "hammer",
                Description = "its a hammer",
                Value = new Money()
            };
         }

        private static Creature CreateGiantCrab(String name)
        {
            return new Creature()
            {
                Name = name,
                Description = "It's a giant crab. Those claws look nasty!",
                Stats = new StatChart() { HPs = 25, MaxHPs = 25, Atk = 10, Def = 10, Level = 5 }
            };
            
        }
    }
}

    

