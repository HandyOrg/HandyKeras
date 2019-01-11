using System.Windows;
using System.Windows.Input;

namespace HandyKeras.UserControl.Basic
{
    public partial class MapItem
    {
        public MapItem()
        {
            InitializeComponent();

            Loaded += (s, e) => Update();
        }

        public static readonly DependencyProperty LeftPosProperty = DependencyProperty.Register(
            "LeftPos", typeof(Point), typeof(MapItem), new PropertyMetadata(default(Point)));

        public Point LeftPos
        {
            get => (Point) GetValue(LeftPosProperty);
            set => SetValue(LeftPosProperty, value);
        }

        public static readonly DependencyProperty RightPosProperty = DependencyProperty.Register(
            "RightPos", typeof(Point), typeof(MapItem), new PropertyMetadata(default(Point)));

        public Point RightPos
        {
            get => (Point) GetValue(RightPosProperty);
            set => SetValue(RightPosProperty, value);
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(MapItem), new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private void MouseDragElementBehavior_OnDragging(object sender, MouseEventArgs e) => Update();

        private void Update()
        {
            var matrix = RenderTransform.Value;
            var x = matrix.OffsetX;
            var y = matrix.OffsetY;
            var halfWidth = ActualWidth + x;
            var halfHeight = ActualHeight / 2 + y;

            LeftPos = new Point(x, halfHeight);
            RightPos = new Point(halfWidth, halfHeight);
        }
    }
}
