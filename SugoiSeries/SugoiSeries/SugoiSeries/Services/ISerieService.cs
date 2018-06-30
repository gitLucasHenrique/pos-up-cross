using SugoiSeries.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SugoiSeries.Services
{
    public interface ISerieService
    {
        Task<SerieResponse> GetSerieAsync();
    }
}
