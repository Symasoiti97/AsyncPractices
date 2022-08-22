using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[Timeout(1000)]
public class TaskRunTests
{
    [Test]
    public void TaskRun_Test()
    {
        Task.Run(() => Console.WriteLine($"Вычисления - {Thread.CurrentThread.ManagedThreadId}"));

        Console.WriteLine($"Другие вычисления - {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep(1000);
    }

    [Test]
    public async Task TaskRun_Test2()
    {
        Console.WriteLine($"Другие вычисления ДО - {Thread.CurrentThread.ManagedThreadId}");

        await Run();

        Console.WriteLine($"Другие вычисления ПОСЛЕ - {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep(2000);
    }

    private static async Task Run()
    {
        Console.WriteLine($"Вычисления До - {Thread.CurrentThread.ManagedThreadId}");
        Task.Delay(0);
        Console.WriteLine($"Вычисления После - {Thread.CurrentThread.ManagedThreadId}");
    }
}