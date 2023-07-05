using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BanKuy.Droid;
using EstudiantesITQ.Droid;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesITQ.Droid
{
    [Activity(Label = "SplashActivity", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
