using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveCharts;

namespace CRM.WPF.ChartModels
{
    public class chartModels
    {
        /// <summary>
        /// Oszlopdiagram model osztálya
        /// </summary>
        public class ColumnDiagramm
        {
            public SeriesCollection? SeriesCollection { get; set; }
            public string[]? Labels { get; set; }
            public Func<double, string>? Formatter { get; set; }
        }

        /// <summary>
        /// Kör diagram model osztálya
        /// </summary>
        public class PieChartDiagramm
        {
            public SeriesCollection? SeriesCollection { get; set; }
        }
    }
}
