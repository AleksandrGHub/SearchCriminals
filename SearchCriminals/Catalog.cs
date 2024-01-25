namespace SearchCriminals
{
    class Catalog
    {
        private Random _random = new Random();

        private List<Criminal> _criminals = new List<Criminal>();

        public Catalog()
        {
            AddCriminals();
        }

        public void ShowCriminals()
        {
            string nationality;

            int height;
            int weight;

            Console.WriteLine("Введите данные для поиска");

            Console.Write("Рост: ");
            height = GetNumber();

            Console.Write("Вес: ");
            weight = GetNumber();

            ShowNationalitys();

            Console.Write("Национальность: ");
            nationality = Console.ReadLine();

            var criminals = from criminal in _criminals where criminal.Height == height && criminal.Weight == weight && criminal.Nationality == nationality && criminal.IsArrested == false select criminal;

            if (criminals.Count() == 0)
            {
                Console.WriteLine("Совпадений не найдено!");
            }
            else
            {
                foreach (var criminal in criminals)
                {
                    Console.WriteLine($"{criminal.Surname} {criminal.Name} {criminal.Patronymic}    рост {criminal.Height} см       вес {criminal.Weight} кг        {criminal.Nationality}");
                }
            }

            Console.ReadKey();
        }

        private void AddCriminals()
        {
            int numberCriminals = 2000;
            int minWeight = 70;
            int maxWeight = 80;
            int minHeight = 170;
            int maxHeight = 180;
            int index = 1;

            List<string> surnames = new List<string>() { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров" };
            List<string> names = new List<string>() { "Сергей", "Дмитрий", "Андрей", "Алексей", "Максим", "Иван", "Роман", "Евгений", "Михаил", "Артем" };
            List<string> patronymics = new List<string>() { "Васильевич", "Викторович", "Витальевич", "Кириллович", "Константинович", "Леонидович", "Тимофеевич", "Федорович", "Николаевич", "Олегович" };
            List<string> nationalitys = new List<string>() { "Китаец", "Бразилец", "Мексиканец", "Испанец", "Итальянец" };
            List<bool> states = new List<bool>() { true, false };

            for (int i = 0; i < numberCriminals; i++)
            {
                _criminals.Add(new Criminal(surnames[_random.Next(surnames.Count)], names[_random.Next(names.Count)], patronymics[_random.Next(patronymics.Count)], nationalitys[_random.Next(nationalitys.Count)], _random.Next(minHeight, maxHeight), _random.Next(minWeight, maxWeight), _random.Next(states.Count) == index ? states[1] : states[0]));
            }
        }

        private void ShowNationalitys()
        {
            Console.WriteLine("\nВарианты национальностей");

            var nationalitys = (from criminal in _criminals select criminal.Nationality).Distinct();

            foreach (var nationality in nationalitys)
            {
                Console.Write($"{nationality} ");
            }

            Console.WriteLine("\n");
        }

        private int GetNumber()
        {
            int number;

            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Введите число!");
            }

            return number;
        }
    }
}