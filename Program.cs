int ReadPositiveInt(string message = "Enter a number: ") {
    Console.Write(message);
    do {
        string user_input = Console.ReadLine() ?? "";
        bool parse_successful = int.TryParse(user_input, out int user_integer);
        bool number_greater_than_zero = user_integer >= 0;

        if (parse_successful && number_greater_than_zero) {
            return user_integer;
        } else {
            Console.Write("Enter a number a positve number: ");
        }
    } while (true);
}

void DisplayOptions() {
    Console.Clear();
    Console.WriteLine("1. Create a Task");
    Console.WriteLine("2. View All Tasks");
    Console.WriteLine("3. Delete a Task");
    Console.WriteLine("4. Quit");
}

string CreateTask() {
    string task;
    do {
        Console.Write("Enter a task: ");
        task = Console.ReadLine() ?? "";
        if (task != "") return task;
    } while (true);
}

void DisplayTasks(List<string> list) {
    for (int i = 0; i < list.Count; ++i) {
        Console.WriteLine($"{i + 1}. {list[i]}");
    }
}

