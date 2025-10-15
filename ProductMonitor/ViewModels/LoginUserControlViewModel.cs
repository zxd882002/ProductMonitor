using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace ProductMonitor.ViewModels
{
    internal class LoginUserControlViewModel : IDialogAware
    {
        public string Title => "Login";

        public event Action<IDialogResult> RequestClose;

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
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
    }
}