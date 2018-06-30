using SugoiSeries.Models;
using SugoiSeries.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SugoiSeries.ViewModel
{
    class DetailViewModel : ViewModelBase
    {
        //name
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        //overview
        string _overview;
        public string Overview
        {
            get { return _overview; }
            set { _overview = value; OnPropertyChanged(); }
        }
        //poster
        string _poster;
        public string Poster
        {
            get { return _poster; }
            set { _poster = value; OnPropertyChanged(); }
        }
        //backdrop
        string _backdrop;
        public string BackDrop
        {
            get { return _backdrop; }
            set { _backdrop = value; OnPropertyChanged(); }
        }
        //votes
        double _votes;
        public double Votes
        {
            get { return _votes; }
            set { _votes = value; OnPropertyChanged(); }
        }
        //release_date
        string _releaseDate;
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; OnPropertyChanged(); }
        }

        public DetailViewModel() : base("")
        {
       
        }
        public override async Task InitializeAsync(object parameter)
        {
            var serie = (parameter as Serie);

            Title = serie.Name;
            Name = serie.OriginalName;
            Overview = serie.Overview;

            Poster = serie.Poster;
            BackDrop = serie.Backdrop;
            ReleaseDate = serie.ReleaseDate;

            Votes = serie.VoteAverage;

            await base.InitializeAsync(parameter);

        }
    }
}
