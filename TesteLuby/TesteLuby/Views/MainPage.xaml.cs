﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TesteLuby.Models;
using TesteLuby.ViewModels;

namespace TesteLuby.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = new MainViewModel();
            BindingContext = vm;

            vm.ExibirLogin += () => Chama_Login();

            //InitializeComponent();
            //MasterBehavior = MasterBehavior.Popover;
            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        private async void Chama_Login()
        {
            await Navigation.PushAsync(new Login());
        }
    }
}