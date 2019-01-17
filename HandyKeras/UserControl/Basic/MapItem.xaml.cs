using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HandyKeras.UserControl
{
    public partial class MapItem
    {
        internal static MapItem MapItemStart;

        internal static BezierCurve BezierCurveCurrent;

        private BezierCurve _bezierCurve;

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

        public static readonly RoutedEvent ConnectionStartedEvent =
            EventManager.RegisterRoutedEvent("ConnectionStarted", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(MapItem));

        public event RoutedEventHandler ConnectionStarted
        {
            add => AddHandler(ConnectionStartedEvent, value);
            remove => RemoveHandler(ConnectionStartedEvent, value);
        }

        public static readonly RoutedEvent ConnectionStoppedEvent =
            EventManager.RegisterRoutedEvent("ConnectionStopped", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(MapItem));

        public event RoutedEventHandler ConnectionStopped
        {
            add => AddHandler(ConnectionStoppedEvent, value);
            remove => RemoveHandler(ConnectionStoppedEvent, value);
        }

        private void MouseDragElementBehavior_OnDragging(object sender, MouseEventArgs e) => Update();

        private void Update()
        {
            var matrix = RenderTransform.Value;
            var x = matrix.OffsetX;
            var y = ButtonNodeStop.TranslatePoint(new Point(), this).Y + matrix.OffsetY + 6;

            LeftPos = new Point(x + 6, y);
            RightPos = new Point(ActualWidth + x - 6, y);
        }

        private void ButtonNodeStart_OnClick(object sender, RoutedEventArgs e)
        {
            MapItemStart = this;
            _bezierCurve = new BezierCurve
            {
                End = RightPos
            };
            _bezierCurve.SetBinding(BezierCurve.StartProperty, new Binding(RightPosProperty.Name) {Source = this});
            BezierCurveCurrent = _bezierCurve;
            if (Parent is Panel panel)
            {
                panel.Children.Add(_bezierCurve);
                Panel.SetZIndex(_bezierCurve, panel.Children.Count);
            }
            MapCtl.SwitchRecordMousePos(true);
        }

        private void ButtonNodeStop_OnClick(object sender, RoutedEventArgs e)
        {
            if (MapItemStart != null && MapItemStart != this)
            {
                _bezierCurve = BezierCurveCurrent;
                MapCtl.SwitchRecordMousePos(false);
                _bezierCurve.SetBinding(BezierCurve.EndProperty, new Binding(LeftPosProperty.Name) { Source = this });
                BezierCurveCurrent = null;
                MapItemStart = null;
            }
        }
    }
}
