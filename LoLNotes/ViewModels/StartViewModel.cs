using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    using Models;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class StartViewModel : BaseViewModel
    {
        private User user;

        AlanMocek.Communication.LoginSystem.LoginManager loginManager;

        public StartViewModel(User user)
        {
            this.user = user;
            loginManager = new AlanMocek.Communication.LoginSystem.LoginManager("software/lolnotes/UserCommunication.php","email","password",';');

            loginManager.ResultOptions.Add(new AlanMocek.Communication.ResultOption((x) => { MessageBox.Show(x[1].ToString()); EmailAddress = x[1]; return true; }, 2));
            loginManager.ResultOptions.Add(new AlanMocek.Communication.ResultOption((x) => { MessageBox.Show("cosss nie dziala"); return true; }, 0));

        }

        private string emailAddress;
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
                UpdateProperty(nameof(EmailAddress));
            }
        }

        private ICommand signInCommand;
        public ICommand SignIn
        {
            get
            {
                if (signInCommand == null)
                    signInCommand = new RelayCommand(
                        (arg) => 
                        {
                            if((arg is PasswordBox) == false)
                            {
                                throw new Exception("Password isnt passwordBox...");
                            }
                            loginManager.Login(EmailAddress, (arg as PasswordBox).Password);
                        }, 
                        (arg) => 
                        {
                            return true;
                        });

                return signInCommand;
            }
        }
    }
}
