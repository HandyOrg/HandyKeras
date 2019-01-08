using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HandyControl.Controls;
using HandyKeras.Data;

namespace HandyKeras.ViewModel
{
    internal class EnvInstallViewModel : ViewModelBase
    {
        private Process _installProcess;

        private bool _isDownloading;

        /// <summary>
        ///     安装命令
        /// </summary>
        public RelayCommand InstallCmd => new Lazy<RelayCommand>(() => new RelayCommand(Install)).Value;

        /// <summary>
        ///     安装
        /// </summary>
        private void Install()
        {
            if (_isDownloading) return;

            _isDownloading = true;
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
                        _installProcess.Close();
                        GlobalData.AppConfig.PipInstalled = true;
                        _isDownloading = false;
                    }).ContinueWith(task =>
                    {
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
                        _isDownloading = false;
                    });
                }
                catch (Exception e)
                {
                    _isDownloading = false;
                    Growl.Error(e.Message);
                }
            }
        }
    }
}