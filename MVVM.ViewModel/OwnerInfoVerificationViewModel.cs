using MVVM.Core;
using MVVM.Model;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class OwnerInfoVerificationViewModel : BaseViewModel
    {
        private readonly IOwnerInfoService ownerInfoService;
        public OwnerInfoVerificationViewModel(IOwnerInfoService ownerInfoService)
        {
            this.ownerInfoService = ownerInfoService;
            CheckOwnerInfoCommand = new AsyncCommand(execute: CheckOwnerInfoAction,
                canExecute: (object ob) => { return CanCheckOwnerInfo; });

            Title = "Owner Verification";
            Subtitle = "Verifies whether input credentials match configured owner";
        }

        public string UserName { get; set; }
        public string GreetingName { get; set; }

        public string OwnerInfoResult
        {
            get => ownerInfoResult;
            set => SetProperty(ref ownerInfoResult, value);
        }
        private string ownerInfoResult = string.Empty;

        public ICommand CheckOwnerInfoCommand { get; }

        public bool CanCheckOwnerInfo
        {
            get => canCheckOwnerInfo;
            set => SetProperty(ref canCheckOwnerInfo, value);
        }
        private bool canCheckOwnerInfo = true;

        private async Task CheckOwnerInfoAction()
        {
            CanCheckOwnerInfo = false;
            OwnerInfoResult = "Verifying...";

            var inputOwnerInfo = new OwnerInfo(UserName, GreetingName);
            var isOwner = await ownerInfoService.IsOwnerAsync(inputOwnerInfo);

            var isOwnerInsertedText = isOwner ? string.Empty : "don't ";
            OwnerInfoResult = $"Specified credentials '{inputOwnerInfo.UserName}' '{inputOwnerInfo.GreetingName}' {isOwnerInsertedText} match configured owner";
            CanCheckOwnerInfo = true;
        }
    }
}
