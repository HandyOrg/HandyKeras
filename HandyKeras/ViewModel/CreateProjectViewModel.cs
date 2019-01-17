using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HandyKeras.Data;

namespace HandyKeras.ViewModel
{
    internal class CreateProjectViewModel : ViewModelBase
    {
        public RelayCommand NewProjectCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(NewProject)).Value;

        private void NewProject()
        {

        }

        public RelayCommand OpenProjectCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(OpenProject)).Value;

        private void OpenProject()
        {

        }

        public RelayCommand OpenDemoCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(OpenDemo)).Value;

        private void OpenDemo()
        {

        }

        public ObservableCollection<ProjectInfoModel> ProjectInfoList { get; set; } =
            new ObservableCollection<ProjectInfoModel>();

        public CreateProjectViewModel()
        {
            for (int i = 1; i <= 10; i++)
            {
                ProjectInfoList.Add(new ProjectInfoModel
                {
                    Name = $"Project{i}",
                    Path = $"Path{i}",
                    CreateTime = DateTime.Now,
                    ModificationTime = DateTime.Now
                });
            }
        }
    }
}