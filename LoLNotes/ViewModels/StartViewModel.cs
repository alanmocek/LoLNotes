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
            loginManager = new AlanMocek.Communication.LoginSystem.LoginManager("software/lolnotes/login.php","email","password",';');

            loginManager.ResultOptions.Add(new AlanMocek.Communication.ResultOption((x) => 
            {
                if (x[0] == "declined")
                {
                    ErrorMessage = x[1];
                    return true;
                }
                else
                    return false;
            }, 2));
            loginManager.ResultOptions.Add(new AlanMocek.Communication.ResultOption((x) =>
            {
                if (x[0] == "accepted")
                {
                    user.Token = x[1];
                    return true;
                }
                else
                    return false;
            }, 2));

            loginManager.ResultOptions.Add(new AlanMocek.Communication.ResultOption((x) => { MessageBox.Show(x[0].ToString());  ErrorMessage="Błąd serwera"; return true; }, 0));

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
                UpdateProperty(nameof(ErrorMessage));
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                string temp = errorMessage;
                errorMessage = string.Empty;
                return temp;
            }
            set
            {
                errorMessage = value;
                UpdateProperty(nameof(ErrorMessage));
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
                            UpdateProperty(nameof(ErrorMessage));
                            if ((arg is PasswordBox) == false)
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

        private ICommand createAccountCommand;
        public ICommand CreateAccount
        {
            get
            {
                if (createAccountCommand == null)
                    createAccountCommand = new RelayCommand(
                        (arg) =>
                        {
                            System.Diagnostics.Process.Start("http://google.com");
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return createAccountCommand;
            }
        }
    }
}
