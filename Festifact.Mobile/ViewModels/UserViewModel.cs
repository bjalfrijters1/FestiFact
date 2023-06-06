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
        //public ICommand NewCommand();
        public ICommand SaveCommand { get; set; }

        private readonly IUserService _userService;

        public UserViewModel(IUserService _userService)
        {
            this._userService = _userService;
            _user = new Festifact.Mobile.Models.User();

            SaveCommand = new Command(async () => await SaveUser());
            OnPropertyChanged();

        }

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                Title = "Add new user";
                OnPropertyChanged();
            }
        }

        private async Task SaveUser()
        {
            
            await _userService.SaveUserAsync(User, true);
            //await _userService.GetUserAsync(User.Id);
            await Shell.Current.GoToAsync("..");

        }

    }
}
