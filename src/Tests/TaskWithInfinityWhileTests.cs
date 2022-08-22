using System;
using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable CS4014
#pragma warning disable CS0162

namespace Tests;

[Timeout(5000)]
public class TaskWithInfinityWhileTests
{
    [Test(Description = "Test #1")]
    public void WithAsyncTest()
    {
        InnerWithAsync();
    }

    [Test(Description = "Test #2")]
    public void ElidingAsyncTest()
    {
        Inner2ElidingAsync();
    }

    [Test(Description = "Test #3")]
    public async Task WithAsync2Test()
    {
        //thread 1
        await InnerWithAsync();
        //thread  не дойдем
    }

    [Test(Description = "Test #4")]
    public async Task ElidingAsync2Test()
    {
        await Inner2ElidingAsync();
    }

    [Test(Description = "Test #5")]
    public void ElidingAsync3Test()
    {
        InnerElidingAsyncTest();
    }

    [Test(Description = "Test #6")]
    public async Task WithAsync3Test()
    {
        await InnerWith2Async();
    }

    [Test(Description = "Test #7")]
    public void WithAsync4Test()
    {
        With2Async();
    }

    private static Task InnerElidingAsyncTest()
    {
        return Inner2ElidingAsync();
    }

    private static Task Inner2ElidingAsync()
    {
        var task = Task.Delay(1000).ContinueWith(task =>
        {
            Console.WriteLine("Task.Delay");
            return task;
        });

        while (true)
        {
        }

        return task;
    }

    private static async Task InnerWithAsync()
    {
        await Task.Delay(1000).ConfigureAwait(false);

        while (true)
        {
        }
    }

    private static async Task With2Async()
    {
        await InnerWithAsync();
    }

    private static async Task InnerWith2Async()
    {
        while (true)
        {
        }

        await Task.Delay(1000);
    }
}