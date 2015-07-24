﻿namespace Microsoft.VisualStudio.Threading.Analyzers
{
    using Microsoft.CodeAnalysis;

    internal class Rules
    {
        internal static readonly DiagnosticDescriptor SynchronousWaitRule = new DiagnosticDescriptor(id: "VSSDK001",
            title: "Synchronous wait on tasks or awaiters is dangerous and may cause dead locks.",
            messageFormat: "Synchronous wait on tasks or awaiters is dangerous and may cause dead locks. " +
"Please consider the following options: " +
"1) Switch to asynchronous wait if the caller is already a \"async\" method. " +
"2) Change the chain of callers to be \"async\" methods, and then change this code to be asynchronous await. " +
"3) Use JoinableTaskFactory.Run() to wait on the tasks or awaiters. Refer to http://blogs.msdn.com/b/andrewarnottms/archive/2014/05/07/asynchronous-and-multithreaded-programming-within-vs-using-the-joinabletaskfactory.aspx for more info.",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor VsServiceBeingUsedOnUnknownThreadRule = new DiagnosticDescriptor(id: "VSSDK002",
            title: "Visual Studio service should be used on main thread explicitly.",
            messageFormat: "Visual Studio service \"{0}\" should be used on main thread explicitly. " +
"Please either verify the current thread is main thread, or switch to main thread asynchronously. " +
"1) APIs to verify the current thread is main thread: ThreadHelper.ThrowIfNotOnUIThread(), or IThreadHandling.VerifyOnUIThread(). " +
"2) APIs to switch to main thread asynchronously: JoinableTaskFactory.SwitchToMainThreadAsync(), or IThreadHandling.SwitchToUIThread(). " +
"Refer to http://blogs.msdn.com/b/andrewarnottms/archive/2014/05/07/asynchronous-and-multithreaded-programming-within-vs-using-the-joinabletaskfactory.aspx for more info.",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor AvoidAsyncVoidMethod = new DiagnosticDescriptor(id: "VSSDK003",
            title: "Avoid Async Void method.",
            messageFormat: "Avoid Async Void method, because any exceptions thrown out of an async void method will be raised directly on the SynchronizationContext and will crash the process. " +
"Refer to https://msdn.microsoft.com/en-us/magazine/jj991977.aspx for more info.",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor AvoidAsyncVoidLambda = new DiagnosticDescriptor(id: "VSSDK004",
            title: "Async Lambda is being used as Void Returning Delegate Type.",
            messageFormat: "Avoid using Async Lambda as Void Returning Delegate Type, because any exceptions thrown out of an async lambda returning void will be raised directly on the SynchronizationContext and will crash the process. " +
"Refer to https://msdn.microsoft.com/en-us/magazine/jj991977.aspx for more info.",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor AsyncEventHandlerShouldBeCalledByInvokeAsync = new DiagnosticDescriptor(id: "VSSDK005",
            title: "AsyncEventHandler delegates should be invoked via the extension method \"TplExtensions.InvokeAsync()\" defined in Microsoft.VisualStudio.Threading assembly.",
            messageFormat: "AsyncEventHandler delegates should be invoked via the extension method \"TplExtensions.InvokeAsync()\" defined in Microsoft.VisualStudio.Threading assembly.",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor AvoidAwaitTaskInsideJoinableTaskFactoryRun = new DiagnosticDescriptor(id: "VSSDK006",
            title: "Avoid calling await Task inside \"JoinableTaskFactory.Run\" delegate when Task is defined outside the delegate to avoid potential deadlocks.",
            messageFormat: "Calling await on a Task inside a JoinableTaskFactory.Run, when the task is initialized outside the delegate can cause potential deadlocks." +
            "You can avoid this problem by ensuring the task is initialized within the delegate or by using JoinableTask instead of Task.",
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

    }
}