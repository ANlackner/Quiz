using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Core;
using System.Collections.Specialized;

namespace Quiz.Gui.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Player> _players = [];

    private int _playerId = 1;

    [ObservableProperty]
    bool _showUsersPopup = false;

    [RelayCommand]
    void ManageUsers()
    {
        this.ShowUsersPopup = true;
    }





    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddPlayerCommand))]
    private string _newPlayerName = string.Empty;

    private bool IsValidPlayerName => NewPlayerName != string.Empty;

    [RelayCommand(CanExecute = nameof(IsValidPlayerName))]
    void AddPlayer()
    {
        Player p = new Player(this._playerId, this.NewPlayerName);
        this.Players.Add(p);

        this._playerId++;
        this.NewPlayerName = string.Empty;
    }


    private string _name = string.Empty;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            SetProperty(ref _name, value);
        }
    }




    public MainViewModel()
    {
        this.Players.CollectionChanged += Players_CollectionChanged;
    }

    private void Players_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
        {
            // this.AddRoundCommand.NotifyCanExecuteChanged();
        }
    }
}
