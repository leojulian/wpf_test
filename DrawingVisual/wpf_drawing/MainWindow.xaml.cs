using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(10, 10), new Size(300, 80));

                context.DrawRectangle(Brushes.LightBlue, new Pen(Brushes.Black, 2), rect);
                context.DrawEllipse(Brushes.Red, new Pen(Brushes.Black, 2), new Point(50, 150), 10, 10);

                return drawingVisual;
            }
        }

        private void PushEffectExample()
        {
            Pen shapeOutlinePen = new Pen(Brushes.Black, 2);
            shapeOutlinePen.Freeze();

            // Create a DrawingGroup
            DrawingGroup dGroup = new DrawingGroup();

            // Obtain a DrawingContext from 
            // the DrawingGroup.
            using (DrawingContext dc = dGroup.Open())
            {
                // Draw a rectangle at full opacity.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(0, 0, 25, 25));

                // Push an opacity change of 0.5. 
                // The opacity of each subsequent drawing will
                // will be multiplied by 0.5.
                dc.PushOpacity(0.5);

                // This rectangle is drawn at 50% opacity.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(25, 25, 25, 25));

                // Blurs subsquent drawings. 
                dc.PushEffect(new BlurBitmapEffect(), null);

                // This rectangle is blurred and drawn at 50% opacity (0.5 x 0.5). 
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(50, 50, 25, 25));

                // This rectangle is also blurred and drawn at 50% opacity.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(75, 75, 25, 25));

                // Stop applying the blur to subsquent drawings.
                dc.Pop();

                // This rectangle is drawn at 50% opacity with no blur effect.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(100, 100, 25, 25));
            }

            Image theImage = new Image();
            DrawingImage dImageSource = new DrawingImage(dGroup);
            theImage.Source = dImageSource;

            renderGrid.Children.Add(theImage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            visualHost.Add(CreateDrawingVisualRectangle());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            PushEffectExample();
        }
    }
}
