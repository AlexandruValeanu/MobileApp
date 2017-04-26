﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BTTP
{
    public partial class App : Application
    {
        public static RestService RestService { get; private set; }

        public App()
        {
            InitializeComponent();
            RestService = new RestService();
            GoToMainPage();
        }

        public static void GoToMainPage()
        {
            Task.Factory.StartNew(RestService.RefreshAndNotifyAsync);
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new ItemsPage(new CalorieStreamViewModel()))
                    {
                        Title = "Calories",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
					new NavigationPage(new ItemsPage(new LocationStreamViewModel()))
					{
						Title = "Locations",
						Icon = Device.OnPlatform("tab_feed.png", null, null)
					},
					new NavigationPage(new ItemsPage(new DistancesStreamViewModel()))
					{
						Title = "Distances",
						Icon = Device.OnPlatform("tab_feed.png", null, null)
					},
					new NavigationPage(new ItemsPage(new HeartRateStreamViewModel()))
					{
						Title = "Heart rate",
						Icon = Device.OnPlatform("tab_feed.png", null, null)
					},
                }
            };
        }
    }
}
