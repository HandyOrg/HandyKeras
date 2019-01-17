using System.Windows.Input;

namespace HandyKeras.UserControl
{
    public partial class MapCtl
    {
        private static MapCtl _map;

        private static bool _isRecord;

        public MapCtl()
        {
            InitializeComponent();

            _map = this;
        }

        internal static void SwitchRecordMousePos(bool record)
        {
            if (_isRecord == record) return;

            _isRecord = record;

            if (record)
            {
                _map.MouseMove += Map_MouseMove;
                _map.MouseRightButtonDown += Map_MouseRightButtonDown;
            }
            else
            {
                _map.MouseMove -= Map_MouseMove;
                _map.MouseRightButtonDown -= Map_MouseRightButtonDown;
            }
        }

        private static void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapItem.BezierCurveCurrent = null;

        }

        private static void Map_MouseMove(object sender, MouseEventArgs e)
        {
            MapItem.BezierCurveCurrent.End = e.GetPosition(_map);
        }
    }
}
