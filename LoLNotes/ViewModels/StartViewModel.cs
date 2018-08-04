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

            InitResultOptions();
            

        }

        private void InitResultOptions()
        {
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
                    ChangeViewModelToNotes?.Invoke();
                    return true;
                }
                else
                    return false;
            }, 2));
            loginManager.ResultOptions.Add(new AlanMocek.Communication.ResultOption((x) => { MessageBox.Show(x[0].ToString());  ErrorMessage="Błąd serwera"; return true; }, 0));
        }

        public event ViewModelEventHandler ChangeViewModelToNotes;
        

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

        #region LoginOptions
        private ICommand signInCommand;
        private ICommand createAccountCommand;

        public ICommand SignInCommand
        {
            get
            {
                if (signInCommand == null)
                    signInCommand = new RelayCommand(
                        (arg) => 
                        {
                            user.EmailAddress = emailAddress;
                            SignIn((arg as PasswordBox));
                        }, 
                        (arg) => 
                        {
                            return true;
                        });

                return signInCommand;
            }
        }
        public ICommand CreateAccountCommand
        {
            get
            {
                if (createAccountCommand == null)
                    createAccountCommand = new RelayCommand(
                        (arg) =>
                        {
                            CreateAccount();
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return createAccountCommand;
            }
        }

        private void SignIn( PasswordBox passwordBox)
        {
            UpdateProperty(nameof(ErrorMessage));
            if ((passwordBox is PasswordBox) == false)
            {
                throw new Exception("Password isnt passwordBox...");
            }
            loginManager.Login(EmailAddress, (passwordBox as PasswordBox).Password);
        }
        private void CreateAccount()
        {
            System.Diagnostics.Process.Start("http://google.com");
        }
        #endregion
    }
}
