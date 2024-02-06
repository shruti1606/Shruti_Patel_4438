using System;

class VirtualPet
{
    // Pet properties
    public string Type { get; set; }
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }

    // Constructor
    public VirtualPet(string type, string name)
    {
        Type = type;
        Name = name;
        Hunger = 5;
        Happiness = 5;
        Health = 5;
    }

    // Display pet info
    public void DisplayInfo()
    {
        Console.WriteLine($"Welcome to the virtual pet simulation!");
        Console.WriteLine($"Your pet is a {Type} named {Name}.");
        Console.WriteLine($"Pet Status: Hunger - {Hunger}/10, Happiness - {Happiness}/10, Health - {Health}/10");
    }

    // Pet care actions
    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} has been fed. Hunger decreased, and health slightly increased.");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Max(0, Hunger + 1);
        Console.WriteLine($"{Name} has played. Happiness increased, and hunger slightly increased.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"{Name} has rested. Health increased, and happiness slightly decreased.");
    }

    // Time-based changes
    public void TimePasses()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"Time passes. Hunger increases, and happiness decreases slightly.");
    }

    // Status check
    public void StatusCheck()
    {
        if (Hunger <= 2 || Happiness <= 2 || Health <= 2)
        {
            Console.WriteLine($"Warning! {Name}'s stats are critically low. Please take care of your pet.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Get pet type and name from the user
        Console.Write("Enter the type of pet (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();

        Console.Write("Enter the name of your pet: ");
        string petName = Console.ReadLine();

        // Create a virtual pet
        VirtualPet pet = new VirtualPet(petType, petName);

        // Display pet info
        pet.DisplayInfo();

        // Main loop
        while (true)
        {
            // Display menu
            Console.WriteLine("\nActions:");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Rest");
            Console.WriteLine("4. Status Check");
            Console.WriteLine("5. Quit");

            // Get user choice
            Console.Write("Choose an action (1-5): ");
            string choice = Console.ReadLine();

            // Perform chosen action
            switch (choice)
            {
                case "1":
                    pet.Feed();
                    break;
                case "2":
                    pet.Play();
                    break;
                case "3":
                    pet.Rest();
                    break;
                case "4":
                    pet.StatusCheck();
                    break;
                case "5":
                    Console.WriteLine("Thanks for playing! Goodbye.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid action.");
                    break;
            }

            // Simulate time passing
            pet.TimePasses();
        }
    }
}