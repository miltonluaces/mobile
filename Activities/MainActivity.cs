#region Imports

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.IO;


#endregion

namespace GUI  {

	[Activity (Label = "AI Logistics Monitor", MainLauncher = true, Icon = "@drawable/logoSm")]
	public class MainActivity : Activity  {

		#region Fields

		string fileName = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath + "/data.txt";

		#endregion
	
		#region Events

		protected override void OnCreate (Bundle bundle) {
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			Dataset.Instance.Read(fileName);
			//Dataset.Instance.Read(Assets.Open("data.txt"));

			ImageView imageView1 = FindViewById<ImageView> (Resource.Id.imageView1);
			Button button0 = FindViewById<Button> (Resource.Id.myButton);
			Button button1 = FindViewById<Button> (Resource.Id.button1);
			Button button2 = FindViewById<Button> (Resource.Id.button2);
			Button button3 = FindViewById<Button> (Resource.Id.button3);
			Button button4 = FindViewById<Button> (Resource.Id.button4);
			Button button5 = FindViewById<Button> (Resource.Id.button5);
			Button button6 = FindViewById<Button> (Resource.Id.button6);

			imageView1.Click += delegate {
				Intent intent = new Intent(this, typeof(GeneralActivity));
				StartActivity(intent);
			};

			button0.Click += delegate {
				Intent intent = new Intent(this, typeof(SalesActivity));
				StartActivity(intent);
			};

			button1.Click += delegate {	
				Intent intent = new Intent(this, typeof(InventActivity));
				StartActivity(intent);
			};

			button2.Click += delegate {	
				Intent intent = new Intent(this, typeof(ServiceActivity));
				StartActivity(intent);
			};

			button3.Click += delegate {	
				Intent intent = new Intent(this, typeof(RotationActivity));
				StartActivity(intent);
			};

			button4.Click += delegate {	
				Intent intent = new Intent(this, typeof(LostSalesActivity));
				StartActivity(intent);
			};

			button5.Click += delegate {	
				Intent intent = new Intent(this, typeof(SuppliesActivity));
				StartActivity(intent);
			};

			button6.Click += delegate {	
				Intent intent = new Intent(this, typeof(WarningsActivity));
				StartActivity(intent);
			};

			button6.Click += delegate {	
				Intent intent = new Intent(this, typeof(WarningsActivity));
				StartActivity(intent);
			};

			RadioButton rad1 = (RadioButton)FindViewById<Button> (Resource.Id.radioButton1);
			RadioButton rad2 = (RadioButton)FindViewById<Button> (Resource.Id.radioButton2);
			RadioButton rad3 = (RadioButton)FindViewById<Button> (Resource.Id.radioButton3);

			rad1.Click += delegate { Dataset.Instance.option = Dataset.OptionType.company; };
			rad2.Click += delegate { Dataset.Instance.option = Dataset.OptionType.distCent; };
			rad3.Click += delegate { Dataset.Instance.option = Dataset.OptionType.stores; };
		}

		protected override void OnResume () {
			base.OnResume ();
		}

		#endregion
	
	}
}




