using System;
using System.Collections.Generic;

namespace fans
{
    // Класс State представляет состояние в ДКА.
    public class State
    {
        public string Name; // Имя состояния
        public Dictionary<char, State> Transitions; // Словарь переходов по символам
        public bool IsAcceptState; // Флаг, указывающий, является ли состояние принимающим
    }

    // Класс FA1 представляет ДКА, который принимает бинарную строку, содержащую ровно один '0' и хотя бы одну '1'.
    public class FA1
    {
        public State InitialState = new State()
        {
            Name = "Initial",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State StateZero = new State()
        {
            Name = "StateZero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State StateOne = new State()
        {
            Name = "StateOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State AcceptState = new State()
        {
            Name = "Accept",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA1()
        {
            InitialState.Transitions['0'] = StateZero;
            InitialState.Transitions['1'] = StateOne;

            StateZero.Transitions['0'] = StateZero;
            StateZero.Transitions['1'] = AcceptState;

            StateOne.Transitions['0'] = AcceptState;
            StateOne.Transitions['1'] = StateOne;

            AcceptState.Transitions['0'] = AcceptState;
            AcceptState.Transitions['1'] = AcceptState;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (current.Transitions.TryGetValue(c, out State nextState))
                {
                    current = nextState;
                }
                else
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }


    // Класс FA2 представляет ДКА, который принимает бинарную строку, содержащую нечетное количество символов '0' и '1'.
    public class FA2
    {
        public State InitialState = new State()
        {
            Name = "Initial",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State StateZero = new State()
        {
            Name = "StateZero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State StateOne = new State()
        {
            Name = "StateOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State AcceptState = new State()
        {
            Name = "Accept",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA2()
        {
            InitialState.Transitions['0'] = StateZero;
            InitialState.Transitions['1'] = StateOne;

            StateZero.Transitions['0'] = StateOne;
            StateZero.Transitions['1'] = AcceptState;

            StateOne.Transitions['0'] = AcceptState;
            StateOne.Transitions['1'] = StateZero;

            AcceptState.Transitions['0'] = AcceptState;
            AcceptState.Transitions['1'] = AcceptState;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (current.Transitions.TryGetValue(c, out State nextState))
                {
                    current = nextState;
                }
                else
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }


    // Класс FA3 представляет ДКА, который принимает бинарную строку, содержащую '11'.
    public class FA3
    {
        public State InitialState = new State()
        {
            Name = "Initial",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State StateOne = new State()
        {
            Name = "StateOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State AcceptState = new State()
        {
            Name = "Accept",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA3()
        {
            InitialState.Transitions['0'] = InitialState;
            InitialState.Transitions['1'] = StateOne;

            StateOne.Transitions['0'] = InitialState;
            StateOne.Transitions['1'] = AcceptState;

            AcceptState.Transitions['0'] = AcceptState;
            AcceptState.Transitions['1'] = AcceptState;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (current.Transitions.TryGetValue(c, out State nextState))
                {
                    current = nextState;
                }
                else
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "0000010111"; // Пример строки для FA1
            string s2 = "010101"; // Пример строки для FA2
            string s3 = "11"; // Пример строки для FA3

            FA1 fa1 = new FA1();
            FA2 fa2 = new FA2();
            FA3 fa3 = new FA3();

            bool? result1 = fa1.Run(s1);
            bool? result2 = fa2.Run(s2);
            bool? result3 = fa3.Run(s3);

            Console.WriteLine($"FA1: {result1}");
            Console.WriteLine($"FA2: {result2}");
            Console.WriteLine($"FA3: {result3}");
        }
    }
}
