﻿using EjercicioCrudMvvm.Views;


namespace EjercicioCrudMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }
    }
}
