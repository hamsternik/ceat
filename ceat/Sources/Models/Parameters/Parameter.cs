﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ceat.Sources.Models.Parameters
{
	public class Parameter
	{
		private readonly ExcelFile File;
		private readonly ParameterIndices Indices;

		public Parameter(ExcelFile file, ParameterIndices indices)
		{
			this.File = file;
			this.Indices = indices;
		}

		public MatchCollection ParameterTitles => new Regex(@"x\d+").Matches(File.Title());

		public double[] Values
		{
			get
			{
				var values = new List<double>();
				var rowIndex = Indices.Row;
				object current = null;
				do
				{
					current = File.ActiveSheet.Rows[rowIndex - 1][Indices.Column - 1];
					if (current != System.DBNull.Value)
						values.Add((double)current);
					rowIndex++;
				} while (current != null && current != System.DBNull.Value);

				return values.ToArray();
			}
		}
	}
}
