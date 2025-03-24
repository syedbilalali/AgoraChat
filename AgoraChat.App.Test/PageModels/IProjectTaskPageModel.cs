using AgoraChat.App.Test.Models;
using CommunityToolkit.Mvvm.Input;

namespace AgoraChat.App.Test.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}