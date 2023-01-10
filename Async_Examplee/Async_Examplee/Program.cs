//async=> 

using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Program
{
    static readonly Stopwatch timer = new Stopwatch();
    public async static Task Main(string[] args)
    {
        timer.Start();

        Task1Async();
        Task2Async();

        timer.Stop();
        Console.ReadKey();

    }

    public static async Task Task1Async()
    {
        Console.WriteLine("Task1 Async Started" + timer.Elapsed.TotalSeconds.ToString());
      
        await Task.Delay(3000);
        Console.WriteLine("Task1 Async Completed" + timer.Elapsed.TotalSeconds.ToString());

    }

    public static async Task Task2Async()
    {
        Console.WriteLine("Task2 Async Started" + timer.Elapsed.TotalSeconds.ToString());
        await Task.Delay(2000);
        Console.WriteLine("Task2 Async Completed" + timer.Elapsed.TotalSeconds.ToString());

    }

    public static void Task1()
    {
        Console.WriteLine("Task1  Started" + timer.Elapsed.TotalSeconds.ToString());
        Thread.Sleep(2000);
        Console.WriteLine("Task1  Completed" + timer.Elapsed.TotalSeconds.ToString());
    } 
    
    public static void Task2()
    {
        Console.WriteLine("Task2  Started" + timer.Elapsed.TotalSeconds.ToString());
        Thread.Sleep(3000);
        Console.WriteLine("Task2  Completed" + timer.Elapsed.TotalSeconds.ToString());
    }
}