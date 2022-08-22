using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[Timeout(5000)]
public class StateMachineTests
{
    [Test(Description = "StateMachine")]
    public async Task StateMachineTest()
    {
        try
        {
            var task = GetTest(true);

            try
            {
                await task;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"await task Exception: {exception.Message}");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"GetTest Exception: {exception.Message}");
        }
    }

    [Test(Description = "TrueStateMachine")]
    public async Task TrueStateMachineTest()
    {
        try
        {
            var task = TrueGetTest(true);

            task.GetAwaiter().GetResult();

            try
            {
                await task;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"#1 await task Exception: {exception.Message}");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"#2 TrueGetTest Exception: {exception.Message}");
        }
    }

    [Test(Description = "StateMachine decompile")]
    public void StateMachineDecompileTest()
    {
        var stateMachine = new StateMachine();
        stateMachine.StateMachineTest();
    }

    [Test(Description = "TrueStateMachine decompile")]
    public void TrueStateDecompileMachineTest()
    {
        var trueStateMachine = new TrueStateMachine();
        trueStateMachine.TrueStateMachineTest();
    }

    private static Task GetTest(bool flag)
    {
        if (flag)
        {
            throw new Exception("Test Exception");
        }

        return Task.Delay(100);
    }

    private static async Task TrueGetTest(bool flag)
    {
        if (flag)
        {
            throw new Exception("Test Exception");
        }

        await Task.Delay(100);
    }
}