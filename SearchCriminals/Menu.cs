namespace SearchCriminals
{
    class Menu
    {
        private string ExitCommand = "Выход";

        private Catalog _catalog = new Catalog();

        public void Work()
        {
            string userInput;

            do
            {
                Console.Clear();
                Console.WriteLine($"Для продолжения нажмите любую кнопку\nДля выхода введите: {ExitCommand}");

                userInput = Console.ReadLine();

                Console.Clear();

                if (userInput != ExitCommand)
                {
                    _catalog.ShowCriminals();
                }
            } while (userInput != ExitCommand);
        }
    }
}