#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarChart;
using Android.Graphics;

#endregion

namespace GUI {

	[Activity (Label = "Nivel de Serivicio al Cliente", Icon = "@drawable/logoSm")]			
	public class ServiceActivity : Activity {

		#region Events

		protected override void OnCreate(Bundle bundle)  {
			base.OnCreate(bundle);
			SetContentView (Resource.Layout.Service);
			List<float> serviceTS = Dataset.Instance.GetDataSubset("TimeSeries", "Total").data[2];
			SetChart(serviceTS.ToArray(), Color.PaleGoldenrod, Color.White, Color.Black);
		}

		#endregion

		#region Private Methods

		private void SetChart(float[] data, Color barColor, Color backColor, Color legColor) {
			float min = float.MaxValue;
			float max = float.MinValue;
			foreach (float f in data) {
				if(f < min) { min = f;	}
				if (f > max) { max = f;	}
			}
			float margin = 0.1f;
			min = min - (min * margin); if (min < 0) { min = 0; }
			max = max + (max * margin);
			var chart = new BarChartView (this) { ItemsSource = Array.ConvertAll (data, v => new BarModel { Value = v }) };
			chart.BarColor = barColor;
			chart.LegendColor = legColor;
			chart.SetBackgroundColor (backColor);
			chart.MinimumValue = min;
			chart.MaximumValue = max;
			AddContentView (chart, new ViewGroup.LayoutParams (	ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));	
		}

		#endregion


	}
}

