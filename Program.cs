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

void PressToContinue() {
    Console.WriteLine("\nPress Enter to continue");
    while (Console.ReadKey().Key != ConsoleKey.Enter) {}
}

void DisplayOptions() {
    Console.Clear();
    Console.WriteLine("==== Menu ====");
    Console.WriteLine("1. Create a Task");
    Console.WriteLine("2. View All Tasks");
    Console.WriteLine("3. Delete a Task");
    Console.WriteLine("4. Quit");
}

string CreateTask() {
    Console.Clear();
    Console.WriteLine("==== Create Task ====");
    string task;
    do {
        Console.Write("Enter a task: ");
        task = Console.ReadLine() ?? "";
        if (task != "") { 
            Console.WriteLine($"\n\"{task}\" added successfully!");
            PressToContinue();
            return task;
        }
    } while (true);
}

void DisplayTasks(List<string> list) {
    Console.Clear();
    Console.WriteLine("==== Tasks ====");
    if (list.Count == 0) {
        Console.WriteLine("No tasks to display");
        PressToContinue();
    } else {
        for (int i = 0; i < list.Count; ++i) {
            Console.WriteLine($"{i + 1}. {list[i]}");
        }
        PressToContinue();
    }
}

void DeleteTask(List<string> list) {
    Console.Clear();
    int number_of_tasks = list.Count;
    if (number_of_tasks == 0) {
        Console.WriteLine("No tasks to delete");
        PressToContinue();
        return;
    };

    Console.WriteLine("==== Delete Task ====");
    for (int i = 0; i < list.Count; ++i) {
        Console.WriteLine($"{i + 1}. {list[i]}");
    }

    int choice = ReadPositiveInt("\nEnter a task to delete: ");

    try {
        string deleted_task = list[choice - 1];
        list.RemoveAt(choice - 1);
        Console.WriteLine($"\n\"{deleted_task}\" removed successfully!");
        PressToContinue();
        return;
    } catch {
        Console.WriteLine("Cannot remove task. Please try again.");
        PressToContinue();
    }
}

List<string> taskList = new List<string>();
bool run_program = true;
while (run_program) {
    DisplayOptions();
    Console.WriteLine();
    int choice = ReadPositiveInt();

    switch(choice) {
        case 1:
            taskList.Add(CreateTask());
            break;
        case 2:
            DisplayTasks(taskList);
            break;
        case 3:
            DeleteTask(taskList);
            break;
        case 4:
        default:
            run_program = false;
            break;
    }
}

Console.Clear();