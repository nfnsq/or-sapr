using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using System.Windows.Forms;
using Kompas6Constants3D;
using Kompas6Constants;

namespace PluginForKompas
{
    public static class HexagonSketch
    {
        public static void DrawHexagon(double rad)
        {
            try
            {
                ksSketchDefinition def = SketchCreator.MakeSketch();
                ksDocument2D doc = (ksDocument2D)def.BeginEdit();
                short polyParam = (short)StructType2DEnum.ko_RegularPolygonParam;
                ksRegularPolygonParam param = (ksRegularPolygonParam)KompasApp.kompas.GetParamStruct(polyParam);
                param.count = 6;
                param.xc = 0;
                param.yc = 0;
                param.ang = 0;
                param.radius = rad;
                param.describe = false;
                param.style = 1;
                doc.ksRegularPolygon(param, 0);
                def.EndEdit();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
