using System;
using System.Xml.Linq;

namespace Tommy;

enum Gender
{
	Male,
	Female
}

class Animal
{
	public string name;
	public int age;
	private Gender gender;
	public int energy;
	public int sale;

	public Gender Gender
	{
		get { return gender; }
		set
		{
			if (value == Gender.Female || value == Gender.Male)
			{
				gender = value;
			}
			else
			{
				throw new Exception("Invalid Gender :D");
			}
		}
	}
	public string Name
	{
		get { return name; }
		set
		{
			if (value.Length <= 14)
			{
				name = value;
			}
			else
			{
				throw ArgumentException("name cannot be less than 14 :(");
			}
		}
	}


	private Exception ArgumentException(string v)
	{
		throw new NotImplementedException();
	}

	public int Energy
	{
		get { return energy; }
		set
		{
			if (value >= 0 && value <= 100)
			{
				energy = value;
			}
			else
			{
				throw ArgumentException("energy nerve cannot be suspended.");
			}
		}
	}

	public int Age {
		get { return age; }
		set {

			if (value >= -19 && value <= 3)
			{
				age = value;

			 }
			else
			{
				throw ArgumentException("age limit should not be exceeded.");
			}
			
		}
	}
	public int Sale {
		get { return sale; }


		set { if (value >= 0)
			{
				value = sale;
			}
			else {
				throw ArgumentException("diamond required ;(");
			}
		}
	}


	public int FoodQuantity { get; set; }

	public Animal()
	{
		Sale = 0;
	}

	public Animal(string name, int age, Gender gender)
	{
		Name = name;
		Age = age;
		Gender = gender;
		Sale = 0;
	}

	public virtual void Eat()
	{
		Energy += 10;
		FoodQuantity++;
	}

	public virtual void Sleep()
	{
		Energy += 15;
		if (Energy > 100)
		{
			Energy = 100;
		}
	}

	public virtual void EnergyGame()
	{
		if (Energy >= 5)
		{
			Energy -= 5;
		}
		else
		{
			Console.WriteLine("Low energy, rest needed.");
		}
	}
}

class Cat : Animal
{
	public bool ToiletTrained { get; set; }

	public Cat()
	{
		Sale = 30;
	}

	public Cat(string name, int age, Gender gender) : base(name, age, gender)
	{
		Sale = 30;
		ToiletTrained = false;
	}

	public override void Eat()
	{
		base.Eat();
		Age++;
		ToiletTrained = true;
	}
	public override void Sleep (){
		base.Sleep();
		Energy++;
		Age++;
		}

	public override void EnergyGame()
	{
		base.EnergyGame();
		ToiletTrained = false;
	}
	public void UseToilet()
	{
		if (ToiletTrained)
		{
			ToiletTrained = false;
			Console.WriteLine("Please use the litter box.");
		}
		else
		{
			Console.WriteLine("Cat is not toilet trained.");
		}
	}
	public override string ToString()
	{
		return $"Cat: Name: {Name}, Age: {Age}, Gender: {Gender}";
	}
}

class Dog : Animal
{
	public bool HouseTrained { get; set; }

	public Dog()
	{
		Sale = 40;
	}

	public Dog(string name, int age, Gender gender) : base(name, age, gender)
	{
		Sale = 40;
		HouseTrained = false;
	}
	public bool Hoisetrained {
		get { return HouseTrained; }
		set { HouseTrained = value;
			Console.WriteLine($"{Name} Homeschooled: {(HouseTrained ? "True" : "False")}");

		}

	}
	public void Train()
	{
		HouseTrained = true;
	   
	}
	public override void EnergyGame()
	{
		base.EnergyGame();
		age++;
	}
	public override string ToString()
	{
		return $"Dog: Name: {Name}, Age: {Age}, Gender: {Gender}, HouseTrained: {(HouseTrained ? "Educated" : "No Educated")}";
	}


	
}
class Fish : Animal {
	private int swimAbility;

	public int SwimAbilitY
	{
		get { return swimAbility; }
		private set
		{
			if (value >= 0 && value <= 100)
			{
				swimAbility = value;
			}
			else
			{
				throw new Exception("Don't have swimming skills.");
			}
		}
	}

	public Fish()
	{
		Sale = 50;
		SwimAbilitY = 50;
	}
	public Fish(string name, int age, Gender gender) : base(name, age, gender)
	{
		SwimAbilitY = 50;
	}

	public void ImproveSwimAbility()
	{
		if (Energy >= 20)
		{
			SwimAbilitY += 10;
			Energy -= 20;
			Console.WriteLine($"{Name} He developed swimming ability. New swimming ability: {SwimAbilitY}");
		}
		else
		{
			Console.WriteLine($"{Name} does not have enough energy to develop swimming ability.");
		}
	}
	public override void EnergyGame()
	{
		base.EnergyGame();
		SwimAbilitY++;

	}

	public override void Eat()
	{
		base.Eat();
		FoodQuantity++;

	}
	public override void Sleep() {
		base.Sleep();
		age++;
	}
	public override string ToString()
	{
		return $"Dog: Name: {Name}, Age: {Age}, Gender: {Gender}";
	}

}
class Bird : Animal
{
    public bool CanFly { get; set; }
    public Dictionary<string, string> SpecialActivities { get;  set; }
    public int fly{ get; private set; }

    public Bird(string name, int age, Gender gender) : base(name, age, gender)
    {
        CanFly = true;
        SpecialActivities = new Dictionary<string, string>();
        fly = 0;
    }

    public void Fly()
    {
        if (CanFly)
        {
            Console.WriteLine($"{Name} flying.");
            Energy -= 8; 
            if (fly > 0)
            {
                fly++; 
                Console.WriteLine($"flying level up {fly}");
            }
        }
        else
        {
            Console.WriteLine($"{Name} incapable of flying.");
        }
    }

    public void AddSpecialActivity(string day, string activity)
    {
        SpecialActivities[day] = activity;
    }

    public void PerformSpecialDayActivity(string day)
    {
        if (SpecialActivities.ContainsKey(day))
        {
            Console.WriteLine($"{Name}, {day}'doing a special activity: {SpecialActivities[day]}");
        }
        else
        {
            Console.WriteLine($"{Name}, {day}'Doesn't do any special activities\n.");
        }
    }

    public void IncreaseflySkill()
    {
        if (Energy >= 15)
        {
            Energy -= 15; 
           fly++; 
            Console.WriteLine($"{Name}, Fly increased his skill. new level: {fly}");
        }
        else
        {
            Console.WriteLine($"{Name},You must gather energy to increase your flying ability..");
        }
    }
    public override void Sleep()
    {
        base.Sleep();
        Energy++;
    }
    public override void Eat()
    {
        base.Eat();
		energy++;

    }
    public override void EnergyGame()
    {
        base.EnergyGame();
		Energy--;
		fly++;
    }

    public override string ToString()
    {
        return $"Bird: Name: {Name}, Age: {Age}, Gender: {Gender}, Flyying: {(CanFly ? "Yes" : "NO")}, Flyygin: {Fly}";
    }
   
}

class PetShopItem
{
    public string Name { get; }
    public int Price { get; }

    public PetShopItem(string name, double price)
    {
        Name = name;
        Price = (int)price;
    }
}

class PetShop
{
    private List<Animal> animals;
    private List<PetShopItem> items;
    private double trainingCost;
    private double consultationCost;

    public List<Animal> Animals
    {
        get { return animals; }
    }

    public List<PetShopItem> Items
    {
        get { return items; }
    }

    public PetShop()
    {
        animals = new List<Animal>();
        items = new List<PetShopItem>();
        trainingCost = 50;
        consultationCost = 30;
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public void AddItem(string itemName, double price)
    {
        items.Add(new PetShopItem(itemName, price));
    }

    public void TrainAnimal(Dog dog)
    { 
        PetShopItem trainingItem = items.Find(item => item.Name == "Training"); // BURDAN BURDAN BURDAN -- 3 DEFE YAZDM BIRDEN GORMESSIZ BUTUN KODU KOMEK ALMIWAM DEYE OXUYARSIZ ALTDA
        if (trainingItem != null)
        {
            if (dog.HouseTrained)
            {
                Console.WriteLine($"{dog.Name} is already house trained.");
            }
            else
            {
                if (trainingItem.Price <= dog.Energy)
                {
                    dog.HouseTrained = true;
                    dog.Energy -= trainingItem.Price;
                    Console.WriteLine($"{dog.Name} has received house training.");
                } //bu hiiseye can komek aldim qonuwmuzdan for eachle etmek istedim hec cure alinmadi saatlarla otorub eyniside alt funksiyada bu funskisalari kommek almiwam
                else
                {
                    Console.WriteLine($"Insufficient energy. {dog.Name} cannot receive house training.");
                }
            }
        }
        else
        {
            Console.WriteLine("House training service is not available.");
        }
    }

    public void Consultation()
    {
        PetShopItem consultationItem = items.Find(item => item.Name == "Consultation");
        if (consultationItem != null)
        {
            Console.WriteLine("Consultation service provided.");
        }
        else
        {
            Console.WriteLine("Consultation service is not available.");
        }
    }

    
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Pet Shop!");

        PetShop petShop = new PetShop();

        while (true)
        {
            Console.WriteLine("Press 1 to add a new animal, 2 for the farm, Q to Quit:");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    Console.WriteLine("Select an animal: 1 for Dog, 2 for Cat, 3 for Fish, 4 for Bird");
                    char animalChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Select gender: M for Male, F for Female");
                    Gender gender = Console.ReadKey().KeyChar == 'M' ? Gender.Male : Gender.Female;
                    Console.WriteLine();

                    Animal newAnimal;
                    switch (animalChoice)
                    {
                        case '1':
                            newAnimal = new Dog(name, age, gender);
                            break;
                        case '2':
                            newAnimal = new Cat(name, age, gender);
                            break;
                        case '3':
                            newAnimal = new Fish(name, age, gender);
                            break;
                        case '4':
                            newAnimal = new Bird(name, age, gender);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            continue;
                    }

                    petShop.AddAnimal(newAnimal);
                    Console.WriteLine($"Added a new {newAnimal.GetType().Name}: {newAnimal.Name}");
                    break;

                case '2':
                    Console.WriteLine("Welcome to the Farm!");
                    Console.WriteLine("Press W to work, S to rest, B to buy, R to return to the main menu:");

                    char farmChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (farmChoice)
                    {
                        case 'w':
                        case 'W':
                            Console.WriteLine("Working on the farm:");
                           
                            break;
                        case 's':
                        case 'S':
                            Console.WriteLine("Resting on the farm:");
                           
                            break;
                        case 'b':
                        case 'B':
                            Console.WriteLine("Buying on the farm:");
                           
                            break;
                        case 'r':
                        case 'R':
                            Console.WriteLine("Returning to the main menu.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;

                case 'q':
                case 'Q':
                    Console.WriteLine("Quitting the pet shop.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
