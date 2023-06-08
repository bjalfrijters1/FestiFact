using CommunityToolkit.Mvvm.ComponentModel;
using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festifact.Mobile.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private string _email;
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

        //public ICommand NewCommand();
        public ICommand SaveCommand { get; set; }
        public ICommand GetCommand { get; set; }
        public ICommand FavouriteShowsCommand { get; set; }
        public ICommand FavouritePerformersCommand { get; set; }

        private readonly IUserService _userService;

        public UserViewModel(IUserService _userService)
        {
            this._userService = _userService;
            _user = new User();

            SaveCommand = new Command(async () => await SaveUser());
            GetCommand = new Command(async () => await FetchUser());
            FavouriteShowsCommand = new Command(async () => await GoToFavourites());
            FavouritePerformersCommand = new Command(async () => await GoToFavouritePerformers());
            OnPropertyChanged();

        }

        private async Task GoToFavouritePerformers()
        {
            if (User == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(User), User }
            };
            try
            {
                await Shell.Current.GoToAsync(nameof(Views.FavouritePerformerListPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private bool _isNewUser;
        private bool IsNewUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
                return true;
            return false;
        }

        protected User _user;
        public User User
        {
            get => _user;
            set
            {
                _isNewUser = IsNewUser(value);
                _user = value;
                OnPropertyChanged();
            }
        }

        private async Task SaveUser()
        {
            
            await _userService.SaveUserAsync(User, _isNewUser);
            await Shell.Current.GoToAsync("..");
        }

        private async Task FetchUser()
        {
            User = await _userService.GetUserByEmailAsync(Email);

            if (User == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(User), User }
            };
            try
            {
                await Shell.Current.GoToAsync(nameof(Views.UserPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private async Task GoToFavourites()
        {
            if (User == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(User), User }
            };
            try
            {
                await Shell.Current.GoToAsync(nameof(Views.FavouriteShowListPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


    }
}
