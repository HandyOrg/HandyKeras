using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HandyKeras.UserControl
{
    /// <summary>
    ///     贝塞尔曲线
    /// </summary>
    internal sealed class BezierCurve : Shape
    {
        private const double OneMinusGoldenRatio = 0.382;

        private const double GoldenRatioHalf = 0.309;

        private readonly PathGeometry _beziergGeometry;

        private readonly BezierSegment _bezierSegment;

        private readonly TranslateTransform _transform;

        public BezierCurve()
        {
            MinHeight = 2;
            MinWidth = 100;
            _transform = new TranslateTransform();
            RenderTransform = _transform;
            _bezierSegment = new BezierSegment();

            var segments = new PathSegmentCollection
            {
                _bezierSegment
            };

            var pathFigure = new PathFigure
            {
                Segments = segments
            };

            var figures = new PathFigureCollection
            {
                pathFigure
            };

            _beziergGeometry = new PathGeometry
            {
                Figures = figures
            };
        }

        protected override Geometry DefiningGeometry => _beziergGeometry;

        public static readonly DependencyProperty StartProperty = DependencyProperty.Register(
            "Start", typeof(Point), typeof(BezierCurve), new PropertyMetadata(default(Point), OnPointChanged));

        public Point Start
        {
            get => (Point) GetValue(StartProperty);
            set => SetValue(StartProperty, value);
        }

        public static readonly DependencyProperty EndProperty = DependencyProperty.Register(
            "End", typeof(Point), typeof(BezierCurve), new PropertyMetadata(default(Point), OnPointChanged));

        public Point End
        {
            get => (Point) GetValue(EndProperty);
            set => SetValue(EndProperty, value);
        }

        private static void OnPointChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var shape = (BezierCurve)d;

            shape._transform.X = shape.Start.X;
            shape._transform.Y = shape.Start.Y + 1;

            var width = shape.End.X - shape.Start.X;
            var height = shape.End.Y - shape.Start.Y;

            shape.Width = Math.Abs(width);
            shape.Height = Math.Abs(height);
            var ctrlPos = OneMinusGoldenRatio * shape.Width + GoldenRatioHalf * shape.Height;

            shape._bezierSegment.Point1 = new Point(ctrlPos - 1, 1);
            shape._bezierSegment.Point2 = new Point(shape.Width - ctrlPos + 1, height - 1);
            shape._bezierSegment.Point3 = new Point(width - 1, height - 1);
        }
    }
}