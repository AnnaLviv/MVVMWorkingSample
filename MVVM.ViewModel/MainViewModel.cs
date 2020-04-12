using MVVM.Core;
using MVVM.Service;
using MvvmHelpers.Commands;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class MainViewModel
    {
        public OwnerInfoVerificationViewModel OwnerInfoVerificationViewModel { get; }

        public MainViewModel()
        {
            var dependencyInjection = new DependencyInjection();
            OpenAcknowledgementsFileCommand = new Command(OpenAcknowledgementsFile);

            OwnerInfoVerificationViewModel = new OwnerInfoVerificationViewModel(dependencyInjection.GetService<IOwnerInfoService>());
        }

        public ICommand OpenAcknowledgementsFileCommand { get; }
        private void OpenAcknowledgementsFile()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return;

            var directory = Directory.GetCurrentDirectory();
            var acknowledgementsFile = Path.Combine(directory, "Open_Source_Acknowledgements.txt");

            var process = new Process();
            process.StartInfo = new ProcessStartInfo(acknowledgementsFile)
            {
                UseShellExecute = true
            };
            process.Start();
        }
    }
}
