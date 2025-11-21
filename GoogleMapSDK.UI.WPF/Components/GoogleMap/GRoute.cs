using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace GoogleMapSDK.UI.WPF.Components.GoogleMap
{
    public class GRoute : GMapRoute
    {
        public Brush color { get; set; } = Brushes.Red;
        public GRoute(IEnumerable<PointLatLng> points) : base(points)
        {
            
        }
        public override Path CreatePath(List<Point> localPath, bool addBlurEffect)
        {
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext streamGeometryContext = streamGeometry.Open())
            {
                streamGeometryContext.BeginFigure(localPath[0], isFilled: false, isClosed: false);
                streamGeometryContext.PolyLineTo(localPath, isStroked: true, isSmoothJoin: true);
            }

            streamGeometry.Freeze();
            Path path = new Path();
            path.Data = streamGeometry;
            if (addBlurEffect)
            {
                BlurEffect blurEffect = new BlurEffect();
                blurEffect.KernelType = KernelType.Gaussian;
                blurEffect.Radius = 3.0;
                blurEffect.RenderingBias = RenderingBias.Performance;
                path.Effect = blurEffect;
            }

            path.Stroke = this.color;
            path.StrokeThickness = 5.0;
            path.StrokeLineJoin = PenLineJoin.Round;
            path.StrokeStartLineCap = PenLineCap.Triangle;
            path.StrokeEndLineCap = PenLineCap.Square;
            path.Opacity = 0.8;
            path.IsHitTestVisible = true;
            return path;
        }
    }
}