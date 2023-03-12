
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

double[] GetStoresCoords(char[,] matrix, int counts)
{
    int x = 0;
    int y = 0;
    int indexStart = 1;
    bool flag = false;
    double[] arrayWithCoords = new double[counts];
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
        arrayWithCoords[i] = (xForCooords * 10 + yForCooords) / 10;
        ShowMapCity(matrix);
        indexStart++;
        flag = false;
    }
    for (int i = 0; i < arrayWithCoords.Length; i++)
    {
        for (int j = 0; j < arrayWithCoords.Length; j++)
        {
            if (arrayWithCoords[i] > arrayWithCoords[j])
            {
                double temp = arrayWithCoords[i];
                arrayWithCoords[i] = arrayWithCoords[j];
                arrayWithCoords[j] = temp;
            }
        }
    }
    return arrayWithCoords;
}

int GetMinimalRange(double[] arrayWithCoords)
{
    double[] arrayWithDifferense = new double[arrayWithCoords.Length - 1];
    {
        int indexForArray = 0;
        for (int i = 1; i < arrayWithDifferense.Length + 1; i++)
        {
            arrayWithDifferense[indexForArray] = Math.Round(arrayWithCoords[i - 1] - arrayWithCoords[i], 2);
            indexForArray++;
        }
        int indexMinPosition = 0;
        return indexMinPosition;
    }
}


void ShowArrayWithCoords(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}


char[,] city = new char[10, 10];
int numbersOfStores = GetDataFromUser("Введите ваше количество магазинов: ");

CreateCityMap(city);
double[] arrayWithCoords = GetStoresCoords(city, numbersOfStores);
ShowArrayWithCoords(arrayWithCoords);