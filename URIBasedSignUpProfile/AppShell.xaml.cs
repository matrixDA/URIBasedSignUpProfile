﻿namespace URIBasedSignUpProfile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }
    }
}
