using System;

class Program
{
    static void Main()
    {       
        int boardSize = 8;

        // Вывод заголовка шахматной доски
        DisplayBoardHeader();
        // Вывод шахматной доски
        DisplayBoard(boardSize);

        
        string firstCoordinate = null;
        string secondCoordinate = null;

        // Цикл для получения корректных координат от пользователя
        bool validInput = false;
        while (!validInput)
        {

            string[] coordinates = GetUserInputForCoordinates();

            firstCoordinate = coordinates[0];
            secondCoordinate = coordinates[1];

            // Проверка на одинаковость введенных координат
            if (firstCoordinate == secondCoordinate)
            {
                Console.WriteLine("Координаты не могут быть одинаковыми. Попробуйте снова.");
            }
            else
            {
                // Если координаты различны, выход из цикл
                validInput = true;
            }
        }

        // Вывод выбранных координат
        DisplaySelectedCoordinates(firstCoordinate, secondCoordinate);
        // Вывод цветов выбранных полей
        DisplayColorsOfSelectedFields(firstCoordinate, secondCoordinate);
        // Вывод шахматной доски с выбранными полями
        DrawBoardWithSelectedFields(firstCoordinate, secondCoordinate);
    }

    // Метод для вывода заголовка шахматной доски
    static void DisplayBoardHeader()
    {
        Console.WriteLine("   a  b  c  d  e  f  g  h"); // Нумерация столбцов
    }

    // Метод для вывода шахматной доски
    static void DisplayBoard(int size)
    {       

        for (int row = size - 1; row >= 0; row--)
        {
            Console.Write(row + 1 + " "); // Нумерация строк
            for (int col = 0; col < size; col++)
            {
                string field = (row + col) % 2 == 0 ? " * " : " + ";
                Console.Write(field);
            }
            Console.WriteLine();
        }
    }

    // Метод для получения координат от пользователя
    static string[] GetUserInputForCoordinates()
    {
        string[] coordinates = null;
        while (coordinates == null)
        {
            Console.WriteLine("Введите координаты двух полей (в формате столбец1+строка1 столбец2+строка2, например a1 h8):");
            string input = Console.ReadLine();

            coordinates = input.Split(' ');

            if (coordinates.Length != 2 || !ValidateCoordinate(coordinates[0]) || !ValidateCoordinate(coordinates[1]))
            {
                Console.WriteLine("Некорректный формат ввода или введены некорректные координаты. Попробуйте снова.");
                coordinates = null;
            }
        }
        return coordinates;
    }

    // Метод для проверки корректности введенных координат
    static bool ValidateCoordinate(string coordinate)
    {
        if (coordinate.Length != 2)
        {
            return false;
        }

        char file = coordinate[0];
        char rank = coordinate[1];

        return file >= 'a' && file <= 'h' && rank >= '1' && rank <= '8';
    }

    // Метод для вывода выбранных координат
    static void DisplaySelectedCoordinates(string firstCoordinate, string secondCoordinate)
    {
        Console.WriteLine();
        Console.WriteLine($"Выбранные координаты:");
        Console.WriteLine($"- Первое поле: {firstCoordinate}");
        Console.WriteLine($"- Второе поле: {secondCoordinate}");
        Console.WriteLine();
    }

    // Метод для вывода цветов выбранных полей
    static void DisplayColorsOfSelectedFields(string firstCoordinate, string secondCoordinate)
    {
        bool areLastCharactersEqual = GetColorSymbol(firstCoordinate).EndsWith(GetColorSymbol(secondCoordinate).Last().ToString());

        if (areLastCharactersEqual)
        {
            Console.WriteLine("Цвета полей одинаковы:");
        }
        else
        {
            Console.WriteLine("Цвета полей различны:");
        }

        Console.WriteLine($"Цвет первого поля ({firstCoordinate}): {GetColorSymbol(firstCoordinate)}");
        Console.WriteLine($"Цвет второго поля ({secondCoordinate}): {GetColorSymbol(secondCoordinate)}");
        Console.WriteLine();
    }

    // Метод для определения цвета поля
    static string GetColorSymbol(string coordinate)
    {
        return (coordinate[0] - 'a' + coordinate[1] - '1') % 2 == 0 ? "черное - *" : "белое - +";
    }

    // Метод для вывода шахматной доски с выбранными полями
    static void DrawBoardWithSelectedFields(string firstCoordinate, string secondCoordinate)
    {
        int boardSize = 8;

        // Вывод заголовка шахматной доски
        DisplayBoardHeader();

        for (int row = boardSize - 1; row >= 0; row--)
        {
            Console.Write(row + 1 + " "); // Нумерация строк
            for (int col = 0; col < boardSize; col++)
            {
                string field = (row + col) % 2 == 0 ? " * " : " + ";
                if (coordinateMatches(col, row, firstCoordinate))
                {
                    field = " 1 "; // Помечаем первое выбранное поле
                }
                else if (coordinateMatches(col, row, secondCoordinate))
                {
                    field = " 2 "; // Помечаем второе выбранное поле
                }
                Console.Write(field);
            }
            Console.WriteLine();
        }
    }

    // Метод для сравнения координат с полем
    static bool coordinateMatches(int col, int row, string coordinate)
    {
        return coordinate == GetCoordinate(col, row);
    }

    // Метод для получения координат поля
    static string GetCoordinate(int col, int row)
    {
        return ((char)('a' + col)).ToString() + (row + 1).ToString();
    }
}
