using System;
using System.Windows;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;

namespace ProductMonitor.Login
{
    internal class LoginUserControlViewModel : BindableBase, IDialogAware
    {
        private DialogCloseListener _requestClose;
        DialogCloseListener IDialogAware.RequestClose => _requestClose;

        public string Title => "Login";

        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        private string  _password;

        public string  Password
        {
            get => _password;
            set => _password = value;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand NavigateRegisterCommand { get; set; }
        public DelegateCommand NavigateForgetPasswordCommand { get; set; }
        public DelegateCommand NavigateLoginCommand { get; set; }

        public LoginUserControlViewModel()
        {
            _selectedIndex = 0;
            LoginCommand = new DelegateCommand(DoLogin);
            RegisterCommand = new DelegateCommand(DoRegister);
            NavigateRegisterCommand = new DelegateCommand(NavigateRegister);
            NavigateForgetPasswordCommand = new DelegateCommand(NavigateForgetPassword);
            NavigateLoginCommand = new DelegateCommand(NavigateLogin);
        }

        private void NavigateLogin()
        {
            SelectedIndex = 0;
        }

        private void NavigateRegister()
        {
            SelectedIndex = 1;
        }

        private void NavigateForgetPassword()
        {
            MessageBox.Show("Sorry，该功能不支持！");
        }

        private void DoRegister()
        {
            MessageBox.Show("注册成功");
        }

        private void DoLogin()
        {
            var pwd = Password;
            _requestClose.Invoke(new DialogResult(ButtonResult.OK));
        }
    }
}