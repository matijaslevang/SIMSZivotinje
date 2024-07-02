using System;
using System.Windows;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object> execute;
    private readonly Predicate<object> canExecute;
    private Action cancelClick;
    private Action<object, RoutedEventArgs> confirmClick;

    public RelayCommand(Action<object> execute) : this(execute, null) { }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        this.canExecute = canExecute;
    }

    public RelayCommand(Action cancelClick)
    {
        this.cancelClick = cancelClick;
    }

    public RelayCommand(Action<object, RoutedEventArgs> confirmClick)
    {
        this.confirmClick = confirmClick;
    }

    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}

public class RelayCommand<T> : ICommand
{
    private readonly Action<T> execute;
    private readonly Predicate<T> canExecute;

    public RelayCommand(Action<T> execute) : this(execute, null) { }

    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
        if (execute == null)
            throw new ArgumentNullException(nameof(execute));

        this.execute = execute;
        this.canExecute = canExecute;
    }
    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        execute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}



