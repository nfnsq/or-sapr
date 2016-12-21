using Kompas6API5;
using KAPITypes;
using System.Windows.Forms;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для нахождения точки пересечения
    /// </summary>
    public static class PointIntersect
    {
        /// <summary>
        /// Метод находит точку пересечения отрезка с дугой, 
        /// центр дуги - начало координат плоскости
        /// </summary>
        /// <param name="x1">Координата х первой точки отрезка</param>
        /// <param name="y1">Координата у первой точки отрезка</param>
        /// <param name="x2">Координата х второй точки отрезка</param>
        /// <param name="y2">Координата у второй точки отрезка</param>
        /// <param name="rad">Радиус дуги</param>
        /// <param name="a1">Начальный угол дуги</param>
        /// <param name="a2">Конечный угол дуги</param>
        /// <param name="par">Выходные данные</param>
        public static bool LinArc(double x1, double y1, double x2, double y2,
                                                    double rad, double a1, double a2,
                                                    ksMathPointParam par)
        {
            try
            {
                ksDynamicArray arr = (ksDynamicArray)KompasApp.kompas.GetDynamicArray(ldefin2d.POINT_ARR);
                if ((arr != null) && (par != null))
                {
                    KompasApp.mat.ksIntersectLinSArc(
                        x1, y1, x2, y2,
                        0, 0, rad, a1, a2, 1, arr);

                    arr.ksGetArrayItem(0, par);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод находит точку пересечения двух дуг
        /// </summary>
        /// <param name="x1">Координата х центра дуги1</param>
        /// <param name="y1">Координата у центра дуги1</param>
        /// <param name="rad1">Ралиус дуги1</param>
        /// <param name="a11">Начальный угол дуги1</param>
        /// <param name="a12">Конечный угол дуги1</param>
        /// <param name="x2">Координата х центра дуги2</param>
        /// <param name="y2">Координата y центра дуги2</param>
        /// <param name="rad2">Радиус дуги2</param>
        /// <param name="a21">Начальый угол дуги2</param>
        /// <param name="a22">Конечный угол дуги2</param>
        /// <param name="par">Выходные параметры</param>
        public static bool ArcArc(double x1, double y1, double rad1, double a11, double a12,
                                                    double x2, double y2, double rad2, double a21, double a22,
                                                    ksMathPointParam par)
        {
            try
            {
                ksDynamicArray arr = (ksDynamicArray)KompasApp.kompas.GetDynamicArray(ldefin2d.POINT_ARR);

                if ((arr != null) && (par != null))
                {
                    KompasApp.mat.ksIntersectArcArc(
                        x1, y1, rad1, a11, a12, 1,
                        x2, y2, rad2, a21, a22, 1,
                        arr
                        );
                    arr.ksGetArrayItem(0, par);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
