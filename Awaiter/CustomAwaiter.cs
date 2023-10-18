using DemoExam.ModelClasses;
using DemoExam.ModelClasses.User;
using System.Runtime.CompilerServices;

namespace Awaiter;

public static class CustomAwaiter
{
    public static TaskAwaiter GetAwaiter(this IModel type)
    {
        return Task.Delay(1).GetAwaiter();
    }
}