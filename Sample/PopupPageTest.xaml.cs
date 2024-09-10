using System.Diagnostics;

using MPowerKit.MediaPlugin;
using MPowerKit.Navigation.Awares;
using MPowerKit.Navigation.Popups;

namespace Sample;

public partial class PopupPageTest : IPopupDialogAware
{
    public PopupPageTest()
    {
        InitializeComponent();

        Task.Run(OpenFilePickerAsync);


    }

    private async Task OpenFilePickerAsync()
    {
        await Task.Delay(2000);
        var filePath = MainThread.InvokeOnMainThreadAsync(() => Media.Current.PickPhotoAsync());

        Debug.WriteLine(filePath);
    }

    public Action<(Confirmation Confirmation, bool Animated)> RequestClose { get; set; }
}