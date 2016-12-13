using Kompas6API5;
using System.Windows.Forms;
using Kompas6Constants3D;

namespace PluginForKompas
{
    public static class CircleSketch
    {
        public static void DrawCircle(double centerCoordinateX,
                                          double centerCoordinateY, 
                                          double radius, int lineType)
        {
            try
            {
                ksSketchDefinition def = SketchCreator.MakeSketch();
                ksDocument2D doc = (ksDocument2D)def.BeginEdit();
                doc.ksCircle(centerCoordinateX, centerCoordinateY, radius, lineType);
                def.EndEdit();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
