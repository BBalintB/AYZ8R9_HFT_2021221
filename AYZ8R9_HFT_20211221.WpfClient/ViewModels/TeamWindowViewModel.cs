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
    public class TeamWindowViewModel:ObservableRecipient
    {
        public RestCollection<Team> Teams{ get; set; }

        public ICommand AddToTeamCommand { get; set; }
        public ICommand RemoveFromTeamCommand { get; set; }
        public ICommand EditTeamCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

        }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Team()
                    {
                        TeamId = value.TeamId,
                        TeamName = value.TeamName,
                        HeadCoach = value.HeadCoach,
                        City = value.City,
                        Stadium = value.Stadium,
                        Division = value.Division,
                        Players = value.Players

                    };
                    OnPropertyChanged();
                    (RemoveFromTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public TeamWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Teams = new RestCollection<Team>("http://localhost:49978/", "team","hub");

                AddToTeamCommand = new RelayCommand(() =>
                {
                    Teams.Add(new Team()
                    {
                        TeamName = SelectedTeam.TeamName,
                        HeadCoach = SelectedTeam.HeadCoach,
                        City = SelectedTeam.City,
                        Stadium = SelectedTeam.Stadium,
                        Division = SelectedTeam.Division
                    });
                });

                EditTeamCommand = new RelayCommand(() =>
                {
                    Teams.Update(SelectedTeam);
                });

                RemoveFromTeamCommand = new RelayCommand(() =>
                {

                    Teams.Delete(SelectedTeam.TeamId);
                },
                () => {
                    return SelectedTeam != null;
                });

                SelectedTeam = new Team();
            }
        }
    }
}
