using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        //1
        Console.WriteLine("***Створення об'єкта***");
        ResearchTeam team = new ResearchTeam("Платформи корпоративних інформаційних систем", "ЧНУ", 301, TimeFrame.TwoYears);
        
        Console.WriteLine(team.ToShortString());
        Console.WriteLine();


        //2
        Console.WriteLine("***Перевірка індексатора***");
        Console.WriteLine($"Чи триває дослідження 1 рік (Year)? : {team[TimeFrame.Year]}");
        Console.WriteLine($"Чи триває дослідження 2 роки (TwoYears)? : {team[TimeFrame.TwoYears]}");
        Console.WriteLine($"Чи триває дослідження довго (Long)? : {team[TimeFrame.Long]}");
        Console.WriteLine();


        //3
        Console.WriteLine("***Зміна властивостей***");
        team.ResearchTopic = "Легенди футболу";
        team.Organization = "FIFA";
        team.RegistrationNumber = 777;
        team.Duration = TimeFrame.Long;

        Console.WriteLine(team.ToString());
        Console.WriteLine();


        //4
        Console.WriteLine("***Додавання нових статей***");
        Person author1 = new Person("Кріштіану", "Роналду", new DateTime(1985, 2, 5));
        Person author2 = new Person("Кіліан", "Мбаппе", new DateTime(1998, 12, 20));

        Paper paper1 = new Paper("Бомбардирські рекорди", author1, new DateTime(2023, 5, 10));
        Paper paper2 = new Paper("Нове покоління футболістів", author2, new DateTime(2026, 1, 15));
        Paper paper3 = new Paper("Майбутнє футболу без легенд цього століття", author1, new DateTime(2025, 11, 20));

        team.AddPapers(paper1, paper2, paper3); 

        Console.WriteLine(team.ToString());
        Console.WriteLine();


        //5
        Console.WriteLine("***Пошук найновішої статті***");
        Paper? newestPaper = team.LatestPaper;
        
        if (newestPaper != null)
        {
            Console.WriteLine($"Найновіша стаття знайдена:\n{newestPaper.ToString()}");
        }
        else
        {
            Console.WriteLine("Статей немає.");
        }
        Console.WriteLine();

        //6
        Console.WriteLine("***Порівняння швидкості масивів***");
        Console.WriteLine("Введіть кількість рядків та стовпців (через кому, пробіл або тире)->");
        
        string input = Console.ReadLine()!;
        
        char[] separators = new char[] { ',', ' ', '-' };
        string[] parts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int nRows = int.Parse(parts[0]);
        int nColumns = int.Parse(parts[1]);
        int totalElements = nRows * nColumns;


        Paper[] array1D = new Paper[totalElements];
        for (int i = 0; i < totalElements; i++)
        {
            array1D[i] = new Paper(); 
        }

        Paper[,] array2D = new Paper[nRows, nColumns];
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                array2D[i, j] = new Paper();
            }
        }

        int jaggedRows = 0;
        int elementsLeft = totalElements;
        int currentStep = 1;
        int lastRowLength = 0;

        while (elementsLeft > 0)
        {
            jaggedRows++;
            if (elementsLeft >= currentStep)
            {
                lastRowLength = currentStep;
                elementsLeft -= currentStep;
                currentStep++;
            }
            else
            {
                lastRowLength = elementsLeft;
                elementsLeft = 0; 
            }
        }

        Paper[][] arrayJagged = new Paper[jaggedRows][];

        for (int i = 0; i < jaggedRows - 1; i++)
        {
            int len = i + 1;
            arrayJagged[i] = new Paper[len];
            
            for (int j = 0; j < len; j++)
            {
                arrayJagged[i][j] = new Paper();
            }
        }

        if (jaggedRows > 0)
        {
            arrayJagged[jaggedRows - 1] = new Paper[lastRowLength];
            
            for (int j = 0; j < lastRowLength; j++)
            {
                arrayJagged[jaggedRows - 1][j] = new Paper();
            }
        }


        int start1D = Environment.TickCount;
        for (int i = 0; i < totalElements; i++)
        {
            array1D[i].Title = "Test title";
        }
        int end1D = Environment.TickCount;
        int time1D = end1D - start1D;


        int start2D = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                array2D[i, j].Title = "Test title";
            }
        }
        int end2D = Environment.TickCount;
        int time2D = end2D - start2D;


        int startJagged = Environment.TickCount;
        for (int i = 0; i < arrayJagged.Length; i++)
        {
            for (int j = 0; j < arrayJagged[i].Length; j++) 
            {
                arrayJagged[i][j].Title = "Test title";
            }
        }
        int endJagged = Environment.TickCount;
        int timeJagged = endJagged - startJagged;

        Console.WriteLine("***Результати вимірювання часу***");
        Console.WriteLine($"Одновимірний масив:       {time1D} мс");
        Console.WriteLine($"Двовимірний прямокутний:  {time2D} мс");
        Console.WriteLine($"Зубчастий масив:          {timeJagged} мс");

    }
}