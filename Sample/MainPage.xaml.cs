using System.Diagnostics;

using Mopups.PreBaked.PopupPages.SingleResponse;

using MPowerKit.MediaPlugin;
using MPowerKit.Navigation.Awares;
using MPowerKit.Navigation.Interfaces;

namespace Sample;

public partial class MainPage : IInitializeAware
{
    private readonly INavigationService _navigationService;
    private readonly IRegionManager _regionManager;
    private readonly IPopupNavigationService _popupNavigationService;
    int count = 0;

    public MainPage(INavigationService navigationService,
        IRegionManager regionManager, IPopupNavigationService popupNavigationService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _regionManager = regionManager;
        _popupNavigationService = popupNavigationService;
    }

    public void Initialize(INavigationParameters parameters)
    {
        _regionManager.NavigateTo("MainRegion", "NewContent1", null);
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        await _popupNavigationService.ShowPopupAsync("PopupPageTest", null, true);


        //await _navigationService.NavigateAsync("NewPage1", null, true);
    }

    private async void MopupsButton_OnClicked(object? sender, EventArgs e)
    {
        SingleResponseViewModel.AutoGenerateBasicPopup(Colors.HotPink, Colors.Black, "I Accept", Colors.Gray, "Good Job, enjoy this single response example", string.Empty);

        await Task.Delay(2000);
        var filePath = MainThread.InvokeOnMainThreadAsync(() => Media.Current.PickPhotoAsync());

        Debug.WriteLine(filePath);

    }
}