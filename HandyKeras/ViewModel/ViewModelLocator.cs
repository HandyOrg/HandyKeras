using System;
using System.Windows;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace HandyKeras.ViewModel
{
    internal class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EnvInstallViewModel>();
            SimpleIoc.Default.Register<CreateProjectViewModel>();
            SimpleIoc.Default.Register<MapViewModel>();
            SimpleIoc.Default.Register<LayerSelectViewModel>();
        }

        public static ViewModelLocator Instance => new Lazy<ViewModelLocator>(() =>
            Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

        #region Vm

        #region window

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public EnvInstallViewModel EnvInstall => ServiceLocator.Current.GetInstance<EnvInstallViewModel>();

        #endregion

        #region control

        public CreateProjectViewModel CreateProject => ServiceLocator.Current.GetInstance<CreateProjectViewModel>();

        public MapViewModel Map => ServiceLocator.Current.GetInstance<MapViewModel>();

        public LayerSelectViewModel LayerSelect => ServiceLocator.Current.GetInstance<LayerSelectViewModel>();

        #endregion

        #endregion
    }
}