using SugoiSeries.Infra;
using SugoiSeries.Infra.API;
using SugoiSeries.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SugoiSeries.Services
{
    public class SerieService : ISerieService
    {
        readonly ITmdbApi _api;

        public SerieService(ITmdbApi api)
        {
            _api = api;
        }

        public async Task<SerieResponse> GetSerieAsync()
        {
            return await _api.GetSerieResponseAsync(AppSettings.ApiKey);
        }
    }
}
