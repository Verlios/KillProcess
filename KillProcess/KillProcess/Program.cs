using System;
using System.Timers;

namespace KillProcess
{
    class Program
    {
        public static int timeLive;
        public static string nameProcess = "";
        public static int timeCheck;
        static void Main(string[] args)
        {


            if (args.Length == 3)
            {

                try
                {
                    if (string.IsNullOrEmpty(args[0]))
                    {
                        throw new Exception("First argument can't be empty");
                    }
                    nameProcess = args[0];
                    try
                    {

                        if (string.IsNullOrEmpty(args[1]) && string.IsNullOrEmpty(args[2]))
                        {
                            throw new Exception("Second and third arguments must be more 0");
                        }
                        timeLive = int.Parse(args[1]) * 60000;
                        timeCheck = int.Parse(args[2]) * 60000;
                        try
                        {
                            ProcessHadler.FindProcess(nameProcess, timeLive);
                            Console.WriteLine("For ending program press any key");
                            Timer t = new Timer();
                            t.Elapsed += OnTimeEvent;
                            t.Enabled = true;
                            t.Interval = timeCheck;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            else
            {
                Console.WriteLine("For start program need write 3 parametrs: name process, time live process and time check. Please restart program. For ending program press any key.");
            }




            Console.ReadKey();


        }
        private static void OnTimeEvent(Object source, ElapsedEventArgs e)
        {
            ProcessHadler.FindProcess(nameProcess, timeLive);
        }
    }
}
