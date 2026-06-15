using System;

namespace SingletonPattern
{
    public sealed class Logger
    {
        private static Logger _instance = null;
        private static readonly object _lock = new object();

        private Logger()
        {
            Console.WriteLine("Logger Instance Created");
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("First message");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("Second message");

            if (logger1 == logger2)
            {
                Console.WriteLine("Same instance proved");
            }

            Console.ReadKey();
        }
    }
}