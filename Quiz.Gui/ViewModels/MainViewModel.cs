using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Core;
using Quiz.Gui.Models;
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
    ObservableCollection<QuestionProviderItem> _rounds = [];

    Random gen = new Random();
    private bool UsersAvailable => this.Players.Count > 0;
    public bool IsRoundInit => this._game.Count > 0 && this._game.GetLatestRound().Status == GameRoundStatus.Init;

    public bool IsRoundActive => this._game.Count > 0 && this._game.GetLatestRound().Status == GameRoundStatus.Active;

    public bool IsRoundDone => this._game.Count > 0 && this._game.GetLatestRound().Status == GameRoundStatus.Done;

    public string? RoundTopic
    {
        get
        {
            if (this._game.Count > 0)
            {
                return this._game.GetLatestRound().Topic;
            }

            return null;
        }
    }


    [RelayCommand(CanExecute = nameof(UsersAvailable))]
    void AddRound()
    {
        IQuestionProvider staticProvider;

        // get random providers
        // gen.Next returns 0 or 1
        if (gen.Next(0, 2) == 0)
        {
            staticProvider = new StaticQuestions();
        }
        else
        {
            staticProvider = new NatureQuestionProvider();
        }

        // create an item and generate image
        QuestionProviderItem item = new QuestionProviderItem(staticProvider);

        // add item to game rounds (for the display)
        this.Rounds.Add(item);

        // add round to game object
        _game.AddRound(staticProvider, true, 5);

        // add each player to the game object
        foreach (Player p in Players)
        {
            _game.AddPlayerToLatestRound(p);
        }

        OnPropertyChanged(nameof(RoundTopic));

        OnPropertyChanged(nameof(IsRoundInit));
        OnPropertyChanged(nameof(IsRoundActive));
        OnPropertyChanged(nameof(IsRoundDone));
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

    private Game _game = new Game();

    private GameRound? _activeRound = null;

    private Play? _activePlay = null;
}
