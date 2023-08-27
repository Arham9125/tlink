public class Node
{
    public string Word { get; set; }
    public Node Next { get; set; }

    public Node(string word)
    {
        Word = word;
        Next = null;
    }
}

public class Data
{
    public void showtheresult()
    {


        LL slink = new LL();

        List<string> words = new List<string> { "cat", "ball", "arham", "muddasir", "icecream", "dictionary" };
        foreach (string word in words)
        {
            slink.InsertWord(word);
        }

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add word");
            Console.WriteLine("2. Search word");
            Console.WriteLine("3. Delete word");
            Console.WriteLine("4. Show word list");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the word to add: ");
                    string addWord = Console.ReadLine();

                    if (addWord.Any(c => !char.IsLetter(c)))
                    {
                        Console.WriteLine("Please use only letters (a-z) in the word.");
                    }
                    else if (addWord.Length < 2)
                    {
                        Console.WriteLine("Please enter a correct word.");
                    }
                    else if (slink.SearchWord(addWord))
                    {
                        Console.WriteLine($"'{addWord}' already exists in the list.");
                    }
                    else if (slink.InsertWord(addWord))
                    {
                        Console.WriteLine($"'{addWord}' added.");
                    }
                    break;

                case 2:
                    Console.Write("Enter the word to search: ");
                    string searchWord = Console.ReadLine();
                    if (slink.SearchWord(searchWord))
                    {
                        Console.WriteLine($"'{searchWord}' is found.");
                    }
                    else
                    {
                        Console.WriteLine($"'{searchWord}' is not found.");
                    }
                    break;

                case 3:
                    Console.Write("Enter the word to delete: ");
                    string deleteWord = Console.ReadLine();
                    if (slink.DeleteWord(deleteWord))
                    {
                        Console.WriteLine($"'{deleteWord}' deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"'{deleteWord}' not found.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Word List:");
                    slink.DisplayWords();
                    break;

                case 5:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }


    }


}