using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State e = new State()
        {
            Name = "e",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA1()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;
            b.Transitions['0'] = d;
            b.Transitions['1'] = b;
            c.Transitions['0'] = e;
            c.Transitions['1'] = d;
            d.Transitions['0'] = e;
            d.Transitions['1'] = d;
            e.Transitions['0'] = e;
            e.Transitions['1'] = e;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c];
                // меняем состояние на то, в которое у нас переход
                if (current == null)
                    // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;
            // результат true если в конце финальное состояние
        }
    }

    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State()
        {
            Name = "d",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State e = new State()
        {
            Name = "e",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['0'] = a;
            b.Transitions['1'] = e;
            c.Transitions['0'] = e;
            c.Transitions['1'] = d;
            d.Transitions['0'] = a;
            d.Transitions['1'] = c;
            e.Transitions['0'] = c;
            e.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c];
                // меняем состояние на то, в которое у нас переход
                if (current == null)
                    // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;
            // результат true если в конце финальное состояние
        }
    }

    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = a;
            b.Transitions['1'] = c;
            c.Transitions['0'] = c;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; 
                // меняем состояние на то, в которое у нас переход
                if (current == null)              
                    // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;
            // результат true если в конце финальное состояние
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "0111";
            string s2 = "01011";
            string s3 = "110101011";
            string s4 = "1110111";
            string s5 = "10";

            string s6 = "0101";
            string s7 = "00110011";
            string s8 = "0001";
            string s9 = "111000";

            string s10 = "00110011";
            string s11 = "0101";

            FA1 fa1 = new FA1();
            FA2 fa2 = new FA2();
            FA3 fa3 = new FA3();

            bool? result1 = fa1.Run(s1);
            bool? result2 = fa1.Run(s2);
            bool? result3 = fa1.Run(s3);
            bool? result4 = fa1.Run(s4);
            bool? result5 = fa1.Run(s5);

            bool? result6 = fa2.Run(s6);
            bool? result7 = fa2.Run(s7);
            bool? result8 = fa2.Run(s8);
            bool? result9 = fa2.Run(s9);

            bool? result10 = fa3.Run(s10);
            bool? result11 = fa3.Run(s11);

            Console.WriteLine($"FA1: {result1}");
            Console.WriteLine($"FA1: {result2}");
            Console.WriteLine($"FA1: {result3}");
            Console.WriteLine($"FA1: {result4}");
            Console.WriteLine($"FA1: {result5}");

            Console.WriteLine($"FA2: {result6}");
            Console.WriteLine($"FA2: {result7}");
            Console.WriteLine($"FA2: {result8}");
            Console.WriteLine($"FA2: {result9}");

            Console.WriteLine($"FA3: {result10}");
            Console.WriteLine($"FA3: {result11}");

        }
    }
}

