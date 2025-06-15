using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace wpf_drawing
{
    public class VisualHost : FrameworkElement
    {
        private VisualCollection _visualCollection;
        public VisualHost()
        {
            _visualCollection = new VisualCollection(this);
        }

        protected override int VisualChildrenCount => _visualCollection.Count;
        protected override Visual GetVisualChild(int index)
        {
            return _visualCollection[index];
        }

        public void Add(DrawingVisual visual)
        {
            _visualCollection.Add(visual);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(this);
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(HitCallback), new PointHitTestParameters(pt));
        }

        private HitTestResultBehavior HitCallback(HitTestResult result)
        {
            if (result.VisualHit is DrawingVisual visual)
            {
                visual.Opacity = 0.5; // 点击后变半透明
                return HitTestResultBehavior.Stop;
            }
            return HitTestResultBehavior.Continue;
        }
    }
}
