using System;
using System.Collections.Generic;
using System.Linq;



public class LL
{
    private Node head;

    public LL()
    {
        head = null;
    }

    public bool InsertWord(string word)
    {
        if (word.Length > 0 && word[word.Length - 1] == word[word.Length - 2] && word[word.Length - 2] == word[word.Length - 3])
        {
            Console.WriteLine($"Error: '{word}' is incorrect.");
            return false;
        }

        if (head == null)
        {
            head = new Node(word);
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(word);
        }

        return true;
    }

    public bool SearchWord(string word)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Word == word)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool DeleteWord(string word)
    {
        if (head == null)
        {
            return false;
        }

        if (head.Word == word)
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Word == word)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void DisplayWords()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Word);
            current = current.Next;
        }
    }

    public void showtheresult() {


        LL oTrie = new LL();

        List<string> words = new List<string> { "cat", "ball", "arham", "muddasir", "icecream", "dictionary" };
        foreach (string word in words)
        {
            oTrie.InsertWord(word);
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
                    else if (oTrie.SearchWord(addWord))
                    {
                        Console.WriteLine($"'{addWord}' already exists in the list.");
                    }
                    else if (oTrie.InsertWord(addWord))
                    {
                        Console.WriteLine($"'{addWord}' added.");
                    }
                    break;

                case 2:
                    Console.Write("Enter the word to search: ");
                    string searchWord = Console.ReadLine();
                    if (oTrie.SearchWord(searchWord))
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
                    if (oTrie.DeleteWord(deleteWord))
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
                    oTrie.DisplayWords();
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
