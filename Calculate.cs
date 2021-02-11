using System;
using System.Collections.Generic;
using System.Text;

namespace IListTargemGames
{
    class Calculate
    {


        private static int GetPriority(char sign)
        {
            if (sign == '*' || sign == '/') return 3;
            else if (sign == '+' || sign == '-') return 2;
            else if (sign == '(') return 1;
            else if (sign == ')') return -1;
            else return 0;



        }

        public static string ExpressionToRpn(string expression)
        {
            string CurrentString = null;
            Stack<char> stack = new Stack<char>();

            int priority;
            for (int i = 0; i < expression.Length; i++)
            {
                priority = GetPriority(expression[i]);
                if (priority == 0) CurrentString += expression[i];

                if (priority == 1) stack.Push(expression[i]);

                if (priority > 1)
                {
                    //что бы не сливалось
                    CurrentString += " ";
                    while (stack.Count > 0)
                    {
                        if (GetPriority(stack.Peek()) >= priority) CurrentString += stack.Pop();
                        else break;
                    }
                    stack.Push(expression[i]);
                }

                if (priority == -1)
                {
                    CurrentString += " ";
                    while (GetPriority(stack.Peek()) != 1) CurrentString += stack.Pop();
                    stack.Pop();
                }
            }
            while (stack.Count > 0) CurrentString += stack.Pop();
            return CurrentString;
        }



        public static double RpnToAnswer(string RpnEexpression)
        {
            string CurrentString = null;
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < RpnEexpression.Length; i++) {
                if (RpnEexpression[i] == ' ') continue;

                if (GetPriority(RpnEexpression[i]) == 0) {
                    while (RpnEexpression[i] != ' ' && GetPriority(RpnEexpression[i]) == 0)
                    {
                        CurrentString += RpnEexpression[i++];
                        
                        if (i == RpnEexpression.Length) break;
                       
                    }
                    stack.Push(double.Parse(CurrentString));
                    CurrentString = null;
                }

                if (GetPriority(RpnEexpression[i]) > 1) {
                    double a = stack.Pop();
                    double b = stack.Pop();

                    if (RpnEexpression[i] == '+') stack.Push(b + a);
                    if (RpnEexpression[i] == '-') stack.Push(b - a);
                    if (RpnEexpression[i] == '*') stack.Push(b * a);
                    if (RpnEexpression[i] == '/') stack.Push(b / a);
                }
            }
            return stack.Pop();
        }
    }
}