using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using HandyKeras.Data;

namespace HandyKeras.Window
{
    public partial class EnvInstallWindow
    {
        public EnvInstallWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<object>(this, MessageToken.CloseEnvInstallWindow, CloseWindow);
        }

        private void CloseWindow(object obj)
        {
            Messenger.Default.Unregister<object>(this, CloseWindow);
            Application.Current.Dispatcher.Invoke(() =>
            {
                DialogResult = true;
                Close();
            });
        }
    }
}
