﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinEvolve.DataObjects;
using XamarinEvolve.Clients.Portable;
using XLabs.Platform.Device;

namespace XamarinEvolve.Clients.UI
{
    public class SpeakerCell: ViewCell
    {
        readonly INavigation navigation;
        string sessionId;
		IDevice device;
        public SpeakerCell (string sessionId, IDevice device, INavigation navigation = null)
        {
			this.device = device;
            this.sessionId = sessionId;
            Height = 60;
            View = new SpeakerCellView ();
            StyleId = "disclosure";
            this.navigation = navigation;
        }

        protected override async void OnTapped()
        {
            base.OnTapped();
            if (navigation == null)
                return;

            var speaker = BindingContext as Speaker;
            if (speaker == null)
                return;

            App.Logger.TrackPage(AppPage.Speaker.ToString(), speaker.FullName);

            await navigation.PushAsync(new SpeakerDetailsPage(sessionId, device)
                {
                    Speaker = speaker
                });
        }
    }
    public partial class SpeakerCellView : ContentView
    {
        public SpeakerCellView()
        {
            InitializeComponent();
        }
    }
}

