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
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

double[] GetStoresCoords(char[,] matrix, int counts)
{
    int x = 0;
    int y = 0;
    int start = 1;
    bool flag = false;
    double[] arrayWithCoords = new double[counts];
    for (int i = 0; i < counts; i++)
    {
        while (!flag)
        {
            Console.Write($"Введите координаты {start} магазина через запятую: ");
            string[] coords = Console.ReadLine().Split(',');
            flag = int.TryParse(coords[0], out x);
            flag = int.TryParse(coords[1], out y);
            if (x > 9 || y > 9)
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
        start++;
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
            arrayWithDifferense[indexForArray] = arrayWithCoords[i - 1] - arrayWithCoords[i];
            indexForArray++;
        }
        int indexMinPosition = 0;
        for (int i = 0; i < arrayWithDifferense.Length; i++)
        {
            for (int j = 0; j < arrayWithDifferense.Length; j++)
            {
                if (arrayWithDifferense[i] < arrayWithDifferense[indexMinPosition])
                {
                    indexMinPosition = i;
                }
            }
        }
        return indexMinPosition;
    }
}

char[,] city = new char[10, 10];
int numbersOfStores = GetDataFromUser("Введите ваше количество магазинов: ");

CreateCityMap(city);
double[] arrayWithCoords = GetStoresCoords(city, numbersOfStores);
int minimalIndexStore = GetMinimalRange(arrayWithCoords);

Console.WriteLine();
Console.WriteLine($"Ближайшие друг к другу магазины находятся на координатах: {arrayWithCoords[minimalIndexStore]} и {arrayWithCoords[minimalIndexStore + 1]}.");