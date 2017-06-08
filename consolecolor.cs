using System.IO;
using System;

class Program
{
    static void Main()
    {
        Console.BackgroundColor=ConsoleColor.Red;
        Console.ForegroundColor=ConsoleColor.Black;
        Console.Clear();
        int x = 2;
        int y = 2;
        Console.SetCursorPosition(x,y);
        do{
            if(Console.ReadKey(true).Key == ConsoleKey.UpArrow){
                x = Console.CursorLeft;
                y = Console.CursorTop;
                y--;
                Console.SetCursorPosition(Console.CursorLeft,Console.CursorTop);
            }    
            if(Console.ReadKey(true).Key == ConsoleKey.DownArrow){
                x = Console.CursorLeft;
                y = Console.CursorTop;
                y++;
                Console.SetCursorPosition(x,y);
            }    
            if(Console.ReadKey(true).Key == ConsoleKey.LeftArrow){
                x = Console.CursorLeft;
                y = Console.CursorTop;
                x--;
                Console.SetCursorPosition(x,y);
            }    
            if(Console.ReadKey(true).Key == ConsoleKey.RightArrow){
                x = Console.CursorLeft;
                y = Console.CursorTop;
                x++;
                Console.SetCursorPosition(x,y);
            }    
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}
