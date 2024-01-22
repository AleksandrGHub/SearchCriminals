namespace SearchCriminals
{
    class Criminal
    {
        public Criminal(string surname, string name, string patronymic, string nationality, int height, int weight, bool isArrested)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsArrested = isArrested;
        }

        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public string Nationality { get; private set; }

        public int Height { get; private set; }
        public int Weight { get; private set; }

        public bool IsArrested { get; private set; }
    }
}