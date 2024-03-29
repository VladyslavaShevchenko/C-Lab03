﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2
{
    public class Async : ICommand
    {
        readonly Predicate<object> _canExecute;
        readonly Func<object, Task> _executeAsync;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public Async(Func<object, Task> executeAsync)
            : this(executeAsync, _ => true)
        {
        }

        public Async(Func<object, Task> executeAsync, Predicate<object> canExecute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await _executeAsync(parameter);
            Console.WriteLine("execute end");
        }
    }
}