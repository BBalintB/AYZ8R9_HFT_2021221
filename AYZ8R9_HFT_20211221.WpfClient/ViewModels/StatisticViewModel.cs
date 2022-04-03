using AYZ8R9_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AYZ8R9_HFT_20211221.WpfClient.ViewModels
{
    public class StatisticViewModel:ObservableRecipient
    {
        public RestCollection<Statistic> Statistics { get; set; }

        public ICommand AddToStatCommand{ get; set; }
        public ICommand RemoveFromStatCommand{ get; set; }
        public ICommand EditStatCommand { get; set; }

        public static bool IsInDesignModoe{
            get {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
                
        }

        private Statistic selectedStat;

        public Statistic SelectedStat
        {
            get { return selectedStat; }
            set {
                if (value!=null)
                {
                    selectedStat = new Statistic()
                    {
                        StatId = value.StatId,
                        PassingYards = value.PassingYards,
                        RushingYards = value.RushingYards,
                        ReceivingYards = value.ReceivingYards,
                        Touchdowns = value.Touchdowns,
                        Player = value.Player

                    };
                    OnPropertyChanged();
                    (RemoveFromStatCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public StatisticViewModel()
        {
            if (!IsInDesignModoe)
            {
                Statistics = new RestCollection<Statistic>("http://localhost:49978/", "statistic","hub");
                AddToStatCommand = new RelayCommand(() =>
                {
                    Statistics.Add(new Statistic()
                    {
                        ReceivingYards = SelectedStat.ReceivingYards,
                        PassingYards = SelectedStat.PassingYards,
                        RushingYards = SelectedStat.RushingYards,
                        Touchdowns = SelectedStat.Touchdowns
                    });
                });

                EditStatCommand = new RelayCommand(() =>
                {
                    try
                    {
                        ;
                        Statistics.Update(SelectedStat);
                    }
                    catch (ArgumentException ex)
                    {
                       ////////
                    }
                    
                });

                RemoveFromStatCommand = new RelayCommand(() =>
                {

                    Statistics.Delete(SelectedStat.StatId);
                },
                ()=>{
                    return SelectedStat != null;                    
                });

                SelectedStat = new Statistic();
            }
            
        }
    }
}
