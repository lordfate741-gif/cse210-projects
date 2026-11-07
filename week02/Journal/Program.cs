// EXCEEDING REQUIREMENTS:
// I added a check when loading a journal file. If the filename the user
// types doesn't exist, the program shows a friendly message instead of
// crashing, and the entries already in the journal are kept.

Journal journal = new Journal();
PromptGenerator generator = new PromptGenerator();

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("Please select one of the following choices:");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Load");
    Console.WriteLine("4. Save");
    Console.WriteLine("5. Quit");
    Console.Write("What would you like to do? ");

    string choice = Console.ReadLine().Trim();

    if (choice == "1")
    {
        string prompt = generator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry entry = new Entry();
        entry._date = DateTime.Now.ToShortDateString();
        entry._promptText = prompt;
        entry._entryText = response;

        journal.AddEntry(entry);
    }
    else if (choice == "2")
    {
        journal.DisplayAll();
    }
    else if (choice == "3")
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
    else if (choice == "4")
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }
    else if (choice == "5")
    {
        running = false;
    }
}