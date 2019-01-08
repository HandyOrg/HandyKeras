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

            if (!GlobalData.AppConfig.PipInstalled)
            {
                var window = new EnvInstallWindow()
                {
                    Owner = this
                };
                if (window.ShowDialog() == false)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
