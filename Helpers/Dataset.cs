#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text;

#endregion

namespace GUI {

	public class Dataset {

		#region Singleton

		private static Dataset instance;

		public static Dataset Instance {
			get { 
				if (instance == null) { instance = new Dataset (); }
				return instance;
			}
		}

		#endregion

		#region Fields

		char[] sepTab = { '\t'};
		char[] sepSpc = { ','};
		Dictionary<string, DataSubset> dataSubsets;
		public OptionType option;

		#endregion

		#region Constructor

		private Dataset() {
			dataSubsets = new Dictionary<string, DataSubset>();
		}

		#endregion

		#region Public Methods

		public void Read(string fileName) {
		StreamReader sr = new StreamReader(fileName);
		//public void Read(Stream stream) {
			//StreamReader sr = new StreamReader (stream);
			string set = "", subset = "", line = "";
			DataSubset dataSubset;
			string[] tokens, dataTokens;
			List<float> data;
			string fileLine;
			while ((fileLine = sr.ReadLine()) != null) {
				tokens = fileLine.Split(sepTab);
				if (tokens.Length <= 1) { continue; }
				if (tokens [0] == "Set") {
					set = tokens [1];
				} 
				else if (tokens [0] == "Subset") {
					subset = tokens [1];
				} 
				else if (tokens [0] == "Line") { 
					line = tokens[1];
					dataTokens = tokens[2].Split(sepSpc);
					data = new List<float>();
					for(int i=0;i<dataTokens.Length;i++) { 
						if (dataTokens[i].Trim() == "") { continue; }
						data.Add(Convert.ToSingle(dataTokens[i]));
					}
					string key = GetKey(set, subset);
					if (!dataSubsets.ContainsKey(key)) {
						dataSubset = new DataSubset(set, subset);
						dataSubsets.Add(key, dataSubset);					
					}
					dataSubsets[key].AddLine(line, data);
				} 
				else {
					//do  nothing
				}
			}
		}

		public DataSubset GetDataSubset(string set, string subset) {
			string key = GetKey(set, subset);
			if(!dataSubsets.ContainsKey(key)) { throw new Exception("Error, not found"); }
			return dataSubsets[key];
		}
		
		#endregion			

		#region Private Methods

		private string GetKey(string set, string subset) {
			return set.Trim() + "-" + subset.Trim();
		}

		#endregion

		#region Inner Classes & Enums

		public class DataSubset {
			
			public string set;
			public string subset;
			public List<string> lines;
			public List<List<float>> data;

			public DataSubset(string set, string subset) {
				this.set = set.Trim();
				this.subset = subset.Trim();
				this.lines = new List<string>();
				this.data = new List<List<float>>();
			}

			public void AddLine(string line, List<float> dat) {
				this.lines.Add(line);
				this.data.Add(dat);
			}
		}
		
		public enum OptionType { company, distCent, stores };

		#endregion

	}
}

