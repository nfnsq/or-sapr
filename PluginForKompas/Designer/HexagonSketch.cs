using Kompas6API5;
using Kompas6Constants;

namespace PluginForKompas
{
    /// <summary>
    ///  Класс рисования эскиза правильного шестиугольника
    /// </summary>
    public static class HexagonSketch
    {
        /// <summary>
        /// Метод создает эскиз правильного шестиугольника
        /// </summary>
        /// <param name="rad">Радиус описанной окружности шестиугольника</param>
        public static bool DrawHexagon(double rad)
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
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
