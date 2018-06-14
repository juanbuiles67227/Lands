namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string password;
        private bool isRunning;
        private bool isEnable;
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter and email.",
                    "Accept"); // 1. Title 2. Message 3. Button
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter and password.",
                    "Accept"); // 1. Title 2. Message 3. Button
                return;
            }

            this.IsRunning = true;
            this.IsEnable = false;

            if (this.Email != "j@b.com" || this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect.",
                    "Accept"); // 1. Title 2. Message 3. Button
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnable = true;
            await Application.Current.MainPage.DisplayAlert(
                "OK",
                "Login correct.",
                "Accept"); // 1. Title 2. Message 3. Button
        }
        #endregion
    }
}
