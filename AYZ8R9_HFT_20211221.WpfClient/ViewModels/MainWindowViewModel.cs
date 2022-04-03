using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AYZ8R9_HFT_20211221.WpfClient.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand PlayersCommand { get; set; }
        public ICommand TeamsCommand { get; set; }
        public ICommand StatisticsCommand { get; set; }
        public ICommand MultipleTableCommand { get; set; }

        public MainWindowViewModel()
        {
            StatisticsCommand = new RelayCommand(() =>
            {
                new StatisticWindow().ShowDialog();
            });
            TeamsCommand = new RelayCommand(() =>
            {
                new TeamWindow().ShowDialog();
            });
            PlayersCommand = new RelayCommand(() =>
            {
                new PlayerWindow().ShowDialog();
            });

        }
    }
}
