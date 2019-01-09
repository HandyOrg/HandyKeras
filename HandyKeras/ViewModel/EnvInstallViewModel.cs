using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using HandyKeras.Data;

namespace HandyKeras.ViewModel
{
    internal class EnvInstallViewModel : ViewModelBase
    {
        private Process _installProcess;

        private bool _isDownloading;

        public bool IsDownloading
        {
            get => _isDownloading;
            set => Set(ref _isDownloading, value);
        }

        private bool _isInstalled;

        public bool IsInstalled
        {
            get => _isInstalled;
            set => Set(ref _isInstalled, value);
        }

        public EnvInstallViewModel()
        {
            IsInstalled = GlobalData.AppConfig.KerasInstalled;
        }

        /// <summary>
        ///     安装命令
        /// </summary>
        public RelayCommand InstallCmd => new Lazy<RelayCommand>(() => new RelayCommand(Install, () => !IsInstalled)).Value;

        /// <summary>
        ///     安装
        /// </summary>
        private void Install()
        {
            if (IsDownloading) return;

            IsDownloading = true;
            var start = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };
            _installProcess = Process.Start(start);
            if (_installProcess != null)
            {
                _installProcess.StandardInput.AutoFlush = true;
                _installProcess.StandardInput.WriteLine($"cd {InternalStr.PythonPath}");
                _installProcess.StandardInput.WriteLine($"{InternalStr.PythonExePath} {InternalStr.InstallKerasCmd}&exit");

                try
                {
                    Task.Run(async () =>
                    {
                        await _installProcess.StandardOutput.ReadToEndAsync();
                        _installProcess.WaitForExit();
                    }).ContinueWith(task =>
                    {
                        _installProcess.Close();
                        IsDownloading = false;

                        if (task.IsFaulted)
                        {
                            if (task.Exception != null)
                            {
                                foreach (var innerException in task.Exception.InnerExceptions)
                                {
                                    Growl.Error(innerException.Message);
                                }
                            }
                        }
                        else
                        {
                            GlobalData.AppConfig.KerasInstalled = true;
                            IsInstalled = true;

                            Messenger.Default.Send<object>(null, MessageToken.CloseEnvInstallWindow);
                        }
                    });
                }
                catch (Exception e)
                {
                    IsDownloading = false;
                    Growl.Error(e.Message);
                }
            }
        }
    }
}