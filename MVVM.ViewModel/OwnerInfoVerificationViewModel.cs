using MVVM.Core;
using MVVM.Model;
using MvvmHelpers.Commands;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class OwnerInfoVerificationViewModel:INotifyPropertyChanged
    {
        private readonly IOwnerInfoService ownerInfoService;
        public OwnerInfoVerificationViewModel(IOwnerInfoService ownerInfoService)
        {
            this.ownerInfoService = ownerInfoService;
            CheckOwnerInfoCommand = new AsyncCommand(CheckOwnerInfoAction);
        }

        public string UserName { get; set; }
        public string GreetingName { get; set; }
        public string OwnerInfoResult { get; private set; }
        public ICommand CheckOwnerInfoCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private async Task CheckOwnerInfoAction()
        {
            OwnerInfoResult = "Verifying...";
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(OwnerInfoResult)));

            var inputOwnerInfo = new OwnerInfo(UserName, GreetingName);
            var isOwner = await ownerInfoService.IsOwnerAsync(inputOwnerInfo);

            OwnerInfoResult = string.Format("Specified credentials {0}match configured owner", isOwner ? string.Empty : "don't ");
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(OwnerInfoResult)));
        }
    }
}
