using ProjectForInterrupt;

// В приложении WPF у меня не получилось брость исключение при использовании метода Interrupt(), 
// поэтому я сделал отдельный проект консольного приложения.

public class Program
{
    public static void Main(string[] args)
    {
        //var myThread = new Thread(() =>
        //{
        //    try
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Console.WriteLine(i);
        //            Thread.Sleep(500);
        //        }
        //    }
        //    catch (ThreadInterruptedException ex)
        //    {
        //        Console.WriteLine("Брошено исключение: " + ex.Message);
        //        Console.WriteLine(typeof(ThreadInterruptedException));
        //    }
        //});

        //myThread.Start();
        //myThread.Interrupt();

        WrapList<string> wl = new WrapList<string>();

        for (int i = 0; i < 10; i++)
        {
            var myThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    wl.Add(Thread.CurrentThread.ManagedThreadId.ToString() + ": i = " + i);
                }
            });            
            myThread.Start();
        }
        Thread.Sleep(2000);

        foreach (var item in wl.Get())
        {
            Console.WriteLine(item);
        }
    }
}


