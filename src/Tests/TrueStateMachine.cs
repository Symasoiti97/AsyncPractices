using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class TrueStateMachine
{
    [CompilerGenerated]
    private sealed class TrueStateMachineTestd__1 : IAsyncStateMachine
    {
        public int _1__state;

        public AsyncTaskMethodBuilder _t__builder;

        public TrueStateMachine _4__this;

        private Task task5__1;

        private Exception exception5__2;

        private Exception exception5__3;

        private TaskAwaiter _u__1;

        private void MoveNext()
        {
            int num = _1__state;
            try
            {
                if (num != 0)
                {
                }

                try
                {
                    if (num != 0)
                    {
                        task5__1 = TrueGetTest(true);
                    }

                    try
                    {
                        TaskAwaiter awaiter;
                        if (num != 0)
                        {
                            awaiter = task5__1.GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                num = (_1__state = 0);
                                _u__1 = awaiter;
                                TrueStateMachineTestd__1 stateMachine = this;
                                _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                                return;
                            }
                        }
                        else
                        {
                            awaiter = _u__1;
                            _u__1 = default(TaskAwaiter);
                            num = (_1__state = -1);
                        }

                        awaiter.GetResult();
                    }
                    catch (Exception ex)
                    {
                        Exception ex2 = (exception5__2 = ex);
                        Console.WriteLine(string.Concat("await task Exception: ", exception5__2.Message));
                    }

                    task5__1 = null;
                }
                catch (Exception ex3)
                {
                    Exception ex2 = (exception5__3 = ex3);
                    Console.WriteLine(string.Concat("TrueGetTest Exception: ", exception5__3.Message));
                }
            }
            catch (Exception exception)
            {
                _1__state = -2;
                _t__builder.SetException(exception);
                return;
            }

            _1__state = -2;
            _t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [CompilerGenerated]
    private sealed class TrueGetTestd__2 : IAsyncStateMachine
    {
        public int _1__state;

        public AsyncTaskMethodBuilder _t__builder;

        public bool flag;

        private TaskAwaiter _u__1;

        private void MoveNext()
        {
            int num = _1__state;
            try
            {
                TaskAwaiter awaiter;
                if (num != 0)
                {
                    if (flag)
                    {
                        throw new Exception("Test Exception");
                    }

                    awaiter = Task.Delay(100).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (_1__state = 0);
                        _u__1 = awaiter;
                        TrueGetTestd__2 stateMachine = this;
                        _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = _u__1;
                    _u__1 = default(TaskAwaiter);
                    num = (_1__state = -1);
                }

                awaiter.GetResult();
            }
            catch (Exception exception)
            {
                _1__state = -2;
                _t__builder.SetException(exception);
                return;
            }

            _1__state = -2;
            _t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [AsyncStateMachine(typeof(TrueStateMachineTestd__1))]
    [DebuggerStepThrough]
    public Task TrueStateMachineTest()
    {
        TrueStateMachineTestd__1 stateMachine = new TrueStateMachineTestd__1();
        stateMachine._t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine._4__this = this;
        stateMachine._1__state = -1;
        stateMachine._t__builder.Start(ref stateMachine);
        return stateMachine._t__builder.Task;
    }

    [AsyncStateMachine(typeof(TrueGetTestd__2))]
    [DebuggerStepThrough]
    private static Task TrueGetTest(bool flag)
    {
        TrueGetTestd__2 stateMachine = new TrueGetTestd__2();
        stateMachine._t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.flag = flag;
        stateMachine._1__state = -1;
        stateMachine._t__builder.Start(ref stateMachine);
        return stateMachine._t__builder.Task;
    }
}