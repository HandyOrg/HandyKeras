using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HandyKeras.Data;
using HandyKeras.UserControl;

namespace HandyKeras.ViewModel
{
    internal class MapViewModel : ViewModelBase
    {
        private Panel _bezierCurveContainer;

        public Panel BezierCurveContainer
        {
            get => _bezierCurveContainer;
            set => Set(ref _bezierCurveContainer, value);
        }

        private Panel _mapItemContainer;

        public Panel MapItemContainer
        {
            get => _mapItemContainer;
            set => Set(ref _mapItemContainer, value);
        }

        public MapViewModel()
        {
            BezierCurveContainer = new Canvas();
            MapItemContainer = new Canvas();

            Messenger.Default.Register<LayerModel>(this, MessageToken.AddMapItem, AddMapItem);
        }

        private void AddMapItem(LayerModel layer)
        {
            MapItemContainer.Children.Add(new MapItem
            {
                Title = layer.Name
            });
        }
    }
}