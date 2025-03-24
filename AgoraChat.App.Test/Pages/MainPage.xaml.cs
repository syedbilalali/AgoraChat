using AgoraChat.App.Test.Models;
using AgoraChat.App.Test.PageModels;

namespace AgoraChat.App.Test.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}