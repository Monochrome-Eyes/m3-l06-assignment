List<string> taskList = new List<string>();

void displayOptions() {
    Console.WriteLine("************************");
    Console.WriteLine("|   1. Create a Task\t|");
    Console.WriteLine("|   2. View All Tasks\t|");
    Console.WriteLine("|   3. Delete a Task\t|");
    Console.WriteLine("|   4. Quit\t\t|");
    Console.WriteLine("************************");
}

int readNumber(int min, int max, string message = "Enter a number") {
    bool flag = true; 
    int number = 0;
    do {
        Console.Write($"{message} ({min} - {max}): ");
        string userInput = Console.ReadLine() ?? "";
        flag = int.TryParse(userInput, out number);
        if (number < min || number > max) {
            Console.WriteLine("Invalid input...");
            flag = false;
        }
    } while(!flag);
    return number;
}

void printOption(string title) {
    Console.WriteLine("---------------");
    Console.WriteLine(title);
    Console.WriteLine("---------------");
}

void createTask() {
    Console.Write("Enter a task: ");
    string task = Console.ReadLine() ?? "";
    taskList.Add(task);
    Console.WriteLine($"\"{task}\" was added");
}

void displayTasks() {
    for (int i = 0; i < taskList.Count; ++i) {
        Console.WriteLine($"{i + 1}. {taskList[i]}");
    }
    Console.WriteLine();
}

void deleteTask() {
}

bool flag = true;
do {
    displayOptions();
    Console.WriteLine();

    int choice = readNumber(1, 4, "Select option");

    switch (choice) {
        case 1:
            printOption("Create Task");
            createTask();
            break;
        case 2:
            displayTasks();
            break;
        case 3:
            deleteTask();
            break;
        case 4:
        default:
            flag = false;
            break;
    }
} while (flag);