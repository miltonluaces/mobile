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

#endregion

namespace GUI {

	[Activity (Label = "Control de Suministros", Icon = "@drawable/logoSm")]			
	public class SuppliesActivity : ListActivity {

		#region Events

		protected override void OnCreate(Bundle bundle)  {
			base.OnCreate(bundle);

			List<string> reportLines = new List<string>();
			reportLines.Add("CONTROL DE SUMINISTROS");
			reportLines.Add ("Proveedor\tCumplim\tAtrasos");
			Dataset.DataSubset dataSubset = Dataset.Instance.GetDataSubset("Supplies", "Total");
		
			StringBuilder sb;
			for (int i = 0; i < dataSubset.lines.Count; i++) {
				sb = new StringBuilder();
				sb.Append (dataSubset.lines [i] + "\t");
				for (int j = 0; j < dataSubset.data[i].Count; j++) {
					sb.Append (dataSubset.data [i] [j].ToString ("0.00") + "\t"); 
				}
				reportLines.Add(sb.ToString());
			}

			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reportLines);
		}

		#endregion

		#region Private Methods

	
		#endregion

	}
}

