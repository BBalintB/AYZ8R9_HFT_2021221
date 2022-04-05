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
    public class PlayerWindowViewModel:ObservableRecipient
    {
        public RestCollection<Player> Players{ get; set; }

        public ICommand AddToPlayersCommand { get; set; }
        public ICommand RemoveFromPlayersCommand { get; set; }
        public ICommand EditPlayerCommand { get; set; }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set {

                if (value != null)
                {
                    selectedPlayer = new Player()
                    {
                        PlayerId = value.PlayerId,
                        PlayerName = value.PlayerName,
                        PlayerJerseyNumber = value.PlayerJerseyNumber,
                        Age = value.Age,
                        Position = value.Position,
                        Stat = value.Stat,
                        StatID = value.StatID,
                        Teams = value.Teams,
                        TeamID = value.TeamID

                    };
                    OnPropertyChanged();
                    (RemoveFromPlayersCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

        }

        public PlayerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Players = new RestCollection<Player>("http://localhost:49978/", "player", "hub");
                AddToPlayersCommand = new RelayCommand(() =>
                {
                    Players.Add(new Player()
                    {
                        PlayerName = SelectedPlayer.PlayerName,
                        PlayerJerseyNumber = SelectedPlayer.PlayerJerseyNumber,
                        Age =  SelectedPlayer.Age,
                        Position = SelectedPlayer.Position,
                        Stat = SelectedPlayer.Stat,
                        StatID = SelectedPlayer.StatID,
                        Teams = SelectedPlayer.Teams,
                        TeamID = SelectedPlayer.TeamID
                    });
                });

                EditPlayerCommand = new RelayCommand(() =>
                {
                    Players.Update(SelectedPlayer);
                });

                RemoveFromPlayersCommand = new RelayCommand(() =>
                {

                    Players.Delete(SelectedPlayer.PlayerId);
                },
                () => {
                    return SelectedPlayer.PlayerName != null;
                });

                SelectedPlayer = new Player();
            }
        }
    }
}
