using Quiz.Gui.ViewModels;

namespace Quiz.Gui;

public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    
}
