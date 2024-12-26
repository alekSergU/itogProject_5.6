//  main))
ShowAnket(SetAnket());



(string, string, int, bool, int, string[], int, string[]) SetAnket()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    (string name, string surName, int age, bool pet, int countPet, string[] namePet, int kolvoFavColors, string[] favColors) anketa;

    Console.Write("введи имя: ");
    anketa.name = Console.ReadLine();

    Console.Write("введи фамилию: ");
    anketa.surName = Console.ReadLine();

    do
    {
        Console.Write("сколько лет: ");
        anketa.age = int.Parse(Console.ReadLine());
    }
    while (Proverka(anketa.age));

    Console.Write("\nесть питомец? (варианты ответа: да/нет) ");

    anketa.countPet = 0;       //
    anketa.namePet = null;     //  заглушки
    anketa.pet = true;         //

    string otvetProPet = Console.ReadLine();
    switch (otvetProPet)
    {
        case "да":
            do
            {
                Console.Write("сколько штук: ");
                anketa.countPet = int.Parse(Console.ReadLine());
            }
            while (Proverka(anketa.countPet));
            anketa.namePet = NamePet(anketa.countPet);
            break;
        case "нет":
            anketa.namePet = new string[1];
            otvetProPet = "питомца нету";
            anketa.namePet[0] = otvetProPet;
            anketa.pet = false;
            break;
    }

    do
    {
        Console.Write("\nсколько любимых цветов: ");
        anketa.kolvoFavColors = int.Parse(Console.ReadLine());
    }
    while (Proverka(anketa.kolvoFavColors));

    Console.WriteLine("\nнапиши любимые цвета (после ввода каждого цвета необходимо нажать Enter):");
    anketa.favColors = FavColorss(anketa.kolvoFavColors);

    var returnAnket = (anketa.name, anketa.surName, anketa.age, anketa.pet, anketa.countPet, anketa.namePet, anketa.kolvoFavColors, anketa.favColors);

    return returnAnket;
}

string[] NamePet(int kolvoPett)
{
    string[] names = new string[kolvoPett + 1];
    for (int i = 1; i < names.Length; i++)
    {
        Console.WriteLine($"введи имя питомца № {i}");
        names[i] = Console.ReadLine();
    }
    return names;
}

string[] FavColorss(int countFavColors)
{
    string[] massFavColors = new string[countFavColors];
    for (int i = 1; i <= massFavColors.Length; i++)
    {
        Console.WriteLine($"введи любимый цвет № {i}");
        massFavColors[i - 1] = Console.ReadLine();
    }
    return massFavColors;
}

bool Proverka(int proverkaVvoda)
{
    bool povtor;
    if ((proverkaVvoda > 0) & (proverkaVvoda < 200)) povtor = false;
    else povtor = true;
    return povtor;
}

void ShowAnket((string name, string surName, int age, bool pet, int countPet, string[] namePet, int kolvoFavColors, string[] favColors) anketata)
{
    Console.WriteLine($"\n\nпривет {anketata.surName} {anketata.name}!");

    string let = "лет";
    string god = "год";
    string goda = "года";
    if ((anketata.age % 10 == 0) | (anketata.age % 10 == 5) | (anketata.age % 10 == 6) | (anketata.age % 10 == 7) | (anketata.age % 10 == 8) | (anketata.age % 10 == 9))
        Console.WriteLine($"\nтебе сейчас " + anketata.age + $" {let})");
    else if (anketata.age % 10 == 1)
        Console.WriteLine($"\nтебе сейчас " + anketata.age + $" {god})");
    else Console.WriteLine($"\nтебе сейчас " + anketata.age + $" {goda})");

    if (anketata.pet == true)
    {
        Console.WriteLine("\nколичество твоих питомцев: " + anketata.countPet);
        Console.WriteLine("их зовут:");
        for (int i = 1; i < anketata.namePet.Length; i++)
        {
            Console.WriteLine($"питомец № {i}: " + anketata.namePet[i]);
        }
    }
    else Console.WriteLine(anketata.namePet[0]);

    Console.WriteLine("\nколичество твоих любимых цветов: " + anketata.kolvoFavColors);
    for (int i = 1; i <= anketata.favColors.Length; i++)
    {
        Console.WriteLine("цвет № {0}: {1}", i, anketata.favColors[i - 1]);
    }
    Console.WriteLine("\nжми Enter");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadKey();
}
