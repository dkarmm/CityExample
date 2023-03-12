// 1. Создать карту города.
//     1. Создать матрицу из 0, где 1 будут означать магазины.
//     2. Создать матрицу из чаров, где x будет означать магазин.

// 2. Выяснить кол-во магазинов от пользователя путём ввода в терминал.

// 3. Указать рандомно местонахождение магазинов на карте.

int GetDataFromUser(string text)
{
    bool flag = false;
    int value = 0;
    while (!flag)
    {
        Console.Write(text);
        flag = int.TryParse(Console.ReadLine(), out value);
        if (value <= 1)
        {
            Console.WriteLine("Необходимое значение магазинов должно быть больше 1.");
            flag = false;
        }
    }
    return value;
}

void CreateCityMap(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = ' ';
        }
    }
}

void ShowMapCity(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}");
        }
        Console.WriteLine();
    }
}

double [] GetStoresCoords(char[,] matrix, int counts)
{
    int x = 0;
    int y = 0;
    int indexStart = 1;
    bool flag = false;
    double [] arrayWithCoords = new double [counts];
    for (int i = 0; i < counts; i++)
    {
        while (!flag)
        {
            Console.Write($"Введите координаты {indexStart} магазина через запятую: ");
            string[] tokens = Console.ReadLine().Split(',');
            flag = int.TryParse(tokens[0], out x);
            flag = int.TryParse(tokens[1], out y);
            if (x > 10 || y > 10)
            {
                Console.WriteLine("Координаты вышли за пределелы города.");
                flag = false;
            }
        }
        matrix[x, y] = 'x';
        double xForCooords = Convert.ToDouble(x);
        double yForCooords = Convert.ToDouble(y);
        arrayWithCoords[i] = (xForCooords * 10 + yForCooords)/10; 
        ShowMapCity(matrix);
        indexStart++;
        flag = false;
    }
    return arrayWithCoords;
}

void ShowArray(double [] array)
{
    for(int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}

char[,] city = new char[10, 10];
int numbersOfStores = GetDataFromUser("Введите ваше количество магазинов: ");

CreateCityMap(city);
double [] arrayWithCoords = GetStoresCoords(city, numbersOfStores);
ShowArray(arrayWithCoords);