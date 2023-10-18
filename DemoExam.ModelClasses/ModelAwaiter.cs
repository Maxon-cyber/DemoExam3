using System.Runtime.CompilerServices;

namespace DemoExam.ModelClasses;

internal static class ModelAwaiter
{
    public static TaskAwaiter GetAwaiter(this IModel type)
        => Task.Delay(1).GetAwaiter();
}