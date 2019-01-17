using System.Windows;

namespace HandyKeras.UserControl
{
    public partial class LayerItem
    {
        public LayerItem()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(LayerItem), new PropertyMetadata("?"));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty DetailProperty = DependencyProperty.Register(
            "Detail", typeof(string), typeof(LayerItem), new PropertyMetadata(default(string)));

        public string Detail
        {
            get => (string) GetValue(DetailProperty);
            set => SetValue(DetailProperty, value);
        }
    }
}
