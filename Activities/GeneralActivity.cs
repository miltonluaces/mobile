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

namespace GUI  {

	[Activity (Label = "General", Icon = "@drawable/logoSm")]			
	public class GeneralActivity : ListActivity  {

		#region Fields


		#endregion

		#region Events

		protected override void OnCreate(Bundle bundle)  {
			base.OnCreate(bundle);

			List<string> reportLines = new List<string>();
			Dataset.DataSubset dataSubset = null;
			switch (Dataset.Instance.option) {
			case Dataset.OptionType.company:
				dataSubset = Dataset.Instance.GetDataSubset("General", "Total");
				reportLines.Add ("REPORTE GENERAL. TOTAL EMPRESA");
				reportLines.Add("Inventario en Costo\t" + dataSubset.data[0][0].ToString());
				reportLines.Add("Inventario en Volumen\t" + dataSubset.data[0][1].ToString());
				reportLines.Add("Nivel de Servicio al Cliente\t" + dataSubset.data[0][2].ToString());
				reportLines.Add("Rotación de la Mercancía\t" + dataSubset.data[0][3].ToString());
				reportLines.Add("Estimación de venta perdida\t" + dataSubset.data[0][4].ToString());
				reportLines.Add("Cumplimiento de proveedores\t" + dataSubset.data[0][5].ToString());
				//AddItemsTotal(reportLines, dataSubset);
				break;
			case Dataset.OptionType.distCent:
				//dataSubset = Dataset.Instance.GetDataSubset("General", "distCent");
				reportLines.Add ("REPORTE GENERAL. POR CEDIS");
				//AddItemsCedisStores(reportLines, dataSubset);
				break;
			case Dataset.OptionType.stores:
				//dataSubset = Dataset.Instance.GetDataSubset("General", "Stores");
				reportLines.Add("REPORTE GENERAL. POR TIENDAS");
				//AddItemsCedisStores(reportLines, dataSubset);
				break;
			}

			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reportLines);
		}

		#endregion

		#region Private Methods

		private void AddItemsTotal(List<string> reportLines, Dataset.DataSubset dataSubset) {
			reportLines.Add("Inventario en Costo\t" + dataSubset.data[0].ToString());
			reportLines.Add("Inventario en Volumen\t" + dataSubset.data[1].ToString());
			reportLines.Add("Nivel de Servicio al Cliente\t" + dataSubset.data[2].ToString());
			reportLines.Add("Rotación de la Mercancía\t" + dataSubset.data[3].ToString());
			reportLines.Add("Estimación de venta perdida\t" + dataSubset.data[4].ToString());
			reportLines.Add("Cumplimiento de proveedores\t" + dataSubset.data[5].ToString());
		}

		private void AddItemsCedisStores(List<string> reportLines, Dataset.DataSubset dataSubset) {
			reportLines.Add ("Inv\tServ\tRot\tVPerd");
			StringBuilder sb;
			for (int i = 0; i < dataSubset.lines.Count; i++) {
				sb = new StringBuilder();
				sb.Append (dataSubset.lines[i] + "\t");
				for (int j = 0; j < dataSubset.data[i].Count; j++) {
					sb.Append(dataSubset.data[i][j].ToString ("0.00") + "\t"); 
				}
				reportLines.Add(sb.ToString());
			}
		}

		#endregion
	}
}

