using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.Json;

namespace Festifact.Mobile.ViewModels
{
    [QueryProperty(nameof(Festival), "Festival")]
    public class FestivalViewModel : BaseViewModel
    {
        public ICommand FavouritesCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand MailCommand { get; set; }

        private readonly IFestivalService _festivalService;
        private readonly FestivalListViewModel _festivalListViewModel;
        private readonly UserViewModel _userViewModel;
        private readonly IMailService _mailService;

        public FestivalViewModel(IFestivalService festivalService, FestivalListViewModel festivalListViewModel, IMailService _mailService)
        {
            this._festivalService = festivalService;
            this._festivalListViewModel = festivalListViewModel;
            this._mailService = _mailService;
            

            FavouritesCommand = new Command(async () => await FavouriteFestival());
            OrderCommand = new Command(async () => await OrderTicket());
            MailCommand = new Command(() => MailFestival());
        }

        private Festival _festival;

        public Festival Festival
        {
            get => _festival;
            set
            {

                _festival = value;
                Title = _festival.Name;
                OnPropertyChanged();
            }
        }

        private async Task FavouriteFestival()
        {
           
            await Shell.Current.GoToAsync("..");
        }

        private async Task OrderTicket()
        {
            //add command to add a ticket to tickets.
            var ticket = await _festivalService.SaveTicketAsync(Festival.Id);
            string festival = Festival.ToString();
            string ticketString = string.Format("Ticketnr: ", ticket.Id);
            string body = string.Format(festival, ticketString);
            _mailService.Send("Ticket", body, "marcelle34@ethereal.email", null) ;
            await Shell.Current.GoToAsync("..");
        }

        private void MailFestival()
        {
            _mailService.Send(Festival.Name, Festival.ToString(), "marcelle34@ethereal.email", null);
        }

        /*public void MailMessage(Festival festival, Ticket ticket)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("marcelle34@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("marcelle34@ethereal.email")); //replace with actual email if u want
            email.Subject = "Your ticket";
            string jsonTicket = JsonSerializer.Serialize(ticket);
            string jsonFestival = JsonSerializer.Serialize(festival);
            string bodyString = string.Format(jsonTicket, jsonFestival);
            email.Body = new TextPart
            {
                Text = bodyString
            };

            var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate ("marcelle34@ethereal.email", "aCMvqUKCHRPgwbn4BN");
            smtp.Send(email);
            smtp.Disconnect(true);
        }*/
    }
}
