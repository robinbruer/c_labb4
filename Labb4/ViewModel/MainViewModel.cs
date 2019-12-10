using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Labb4.Repository;

namespace Labb4
{
    public class MainViewModel : SimpleViewModel
    {
        private Country currentCountry;
        private List<Country> countries;
        private CountryRepository countryRepository = new CountryRepository();
        private int index;

        public ICommand NextCommand { get; set; }
        public ICommand PrevCommand { get; set; }

        public MainViewModel()
        {
            countries = countryRepository.GetCountries();
            CurrentCountry = countries[index];
            NextButtonPressed();
            PrevButtonPressed();
        }

        public Country CurrentCountry
        {
            get => currentCountry;
            set => SetPropertyValue(ref currentCountry, value);
        }

        private void NextButtonPressed()
        {
            NextCommand = new Command(() =>
            {
                _ = index >= countries.Count - 1 ? index = 0 : index++;
                CurrentCountry = countries[index];
            });
        }

        private void PrevButtonPressed()
        {
            PrevCommand = new Command(() =>
            {
                _ = index <= 0 ? index = countries.Count - 1 : index--;
                CurrentCountry = countries[index];
            });
        }
    }
}
