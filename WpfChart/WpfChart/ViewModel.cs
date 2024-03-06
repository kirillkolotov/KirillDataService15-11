using LiveCharts.Events;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WpfChart
{
    public class MyCommand<T> : ICommand where T : class
    {
        public Predicate<T> CanExecuteDelegate { get; set; }
        public Action<T> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate == null || CanExecuteDelegate((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null) ExecuteDelegate((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            DataClickCommand = new MyCommand<ChartPoint>
            {
                ExecuteDelegate = p => Console.WriteLine(
                    "[COMMAND] you clicked " + p.X + ", " + p.Y)
            };
            DataHoverCommand = new MyCommand<ChartPoint>
            {
                ExecuteDelegate = p => Console.WriteLine(
                    "[COMMAND] you hovered over " + p.X + ", " + p.Y)
            };
            UpdaterTickCommand = new MyCommand<LiveCharts.Wpf.CartesianChart>
            {
                ExecuteDelegate = c => Console.WriteLine("[COMMAND] Chart was updated!")
            };
            RangeChangedCommand = new MyCommand<RangeChangedEventArgs>
            {
                ExecuteDelegate = e => Console.WriteLine("[COMMAND] Axis range changed")
            };
        }

        public MyCommand<ChartPoint> DataHoverCommand { get; set; }
        public MyCommand<ChartPoint> DataClickCommand { get; set; }
        public MyCommand<LiveCharts.Wpf.CartesianChart> UpdaterTickCommand { get; set; }
        public MyCommand<RangeChangedEventArgs> RangeChangedCommand { get; set; }
    }
}