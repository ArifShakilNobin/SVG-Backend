using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svg.DataAccess
{
    public class Rectangular : BaseEntity
    {
        public double? height { get; set; }
        public double width { get; set; }
        public string? color { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int rx { get; set; }
        public int ry { get; set; }
    }
}
