using System;

namespace IListTargemGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Строковый калькулятор V1.0 \nвведи выражение и нажми Entr \nЧтобы выйти из программы введи exit");
            while (true) 
            {
                string input = Console.ReadLine();
                if (input == "exit") { break; }
                else 
                {
                    try
                    {
                        Console.WriteLine("Ответ:" + Calculate.RpnToAnswer(Calculate.ExpressionToRpn(input)));
                    }
                    catch (Exception e) 
                    {
                        Console.WriteLine("Ошибка вода попробуйте снова \n" + e.Message);                 
                    }
                }
            }
            Console.WriteLine("Вы вышли из программы");
        }
        
        
    }
}
