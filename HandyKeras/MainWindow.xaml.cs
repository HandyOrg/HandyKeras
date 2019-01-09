using System;
using HandyKeras.Data;
using HandyKeras.Window;

namespace HandyKeras
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            if (!GlobalData.AppConfig.KerasInstalled)
            {
                var window = new EnvInstallWindow()
                {
                    Owner = this
                };
                if (window.ShowDialog() == false)
                {
                    Close();
                }
            }
        }
    }
}
