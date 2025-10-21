using System;

using Prism.Commands;
using Prism.Dialogs;

namespace ProductMonitor.Login
{
    internal class LoginUserControlViewModel : IDialogAware
    {
        private DialogCloseListener _requestClose;
        DialogCloseListener IDialogAware.RequestClose => _requestClose;
        
        public string Title => "Login";

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

        public LoginUserControlViewModel()
        {
            LoginCommand = new DelegateCommand(DoLogin);
        }

        private void DoLogin()
        {
            _requestClose.Invoke(new DialogResult(ButtonResult.OK));
        }
    }
}