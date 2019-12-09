namespace GUI {
    using System.Linq;
	using OxyPlot;
	using OxyPlot.Series;
    using Android.App;
    using Android.OS;
    using Android.Views;
    using OxyPlot.Xamarin.Android;


	[Activity(Label = "Plot")]
    public class PlotActivity : Activity  {

        protected override void OnCreate(Bundle bundle)   {
            base.OnCreate(bundle);

            //this.RequestWindowFeature(WindowFeatures.NoTitle);
			this.Title = "prueba";

     		var model = new OxyPlot.PlotModel();
			LineSeries ts = new LineSeries();
			ts.Points.Add(new DataPoint(0,0));
			ts.Points.Add(new DataPoint(1,1));
			ts.Points.Add(new DataPoint(1,2));
			ts.Points.Add(new DataPoint(2,2));
			ts.Points.Add(new DataPoint(2,3));
			ts.Points.Add(new DataPoint(3,4));
			model.Series.Add(ts);
        
			this.SetContentView(Resource.Layout.PlotActivity);
			var plotView = this.FindViewById<PlotView>(Resource.Id.plotview);
			plotView.Model = model;
        }
    }
}