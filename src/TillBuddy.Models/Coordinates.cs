using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TillBuddy.Models;

public class CoordinatesRequest
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CoordinatesResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
