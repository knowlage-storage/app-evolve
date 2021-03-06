﻿using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinEvolve.UITests
{
    public class AppInitializer
    {
        const string apkfile = @"C:\dev\app-evolve\src\com.sample.evolve.apk";
        //        const string appfile = "../../../XamarinEvolve.iOS/bin/iPhoneSimulator/Debug/XamarinEvolveiOS.app";

        private static IApp app;

        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppInitializer.App' not set. Call 'AppInitializer.StartApp(platform)' before trying to access it.");
                return app;
            }
        }

        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                app = ConfigureApp.Android.ApkFile(apkfile)
                    .DeviceSerial("169.254.76.233:5555")
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
            }
            else
            {
                app = ConfigureApp
					.iOS
					.PreferIdeSettings()
					//.InstalledApp("com.arteksoftware.evolve")
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
            }

            return app;
        }
    }
}

