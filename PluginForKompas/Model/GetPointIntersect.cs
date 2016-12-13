using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using KAPITypes;

namespace PluginForKompas
{
    public static class GetPointIntersect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="rad"></param>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="par"></param>
        public static void LinArc(double x1, double y1, double x2, double y2,
                                                    double rad, double a1, double a2,
                                                    ksMathPointParam par)
        {
            ksDynamicArray arr = (ksDynamicArray)KompasApp.kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            if ((arr != null) && (par != null))
            {
                KompasApp.mat.ksIntersectLinSArc(
                    x1, y1, x2, y2,
                    0, 0, rad, a1, a2, 1, arr);

                arr.ksGetArrayItem(0, par);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="rad1"></param>
        /// <param name="a11"></param>
        /// <param name="a12"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="rad2"></param>
        /// <param name="a21"></param>
        /// <param name="a22"></param>
        /// <param name="par"></param>
        public static void ArcArc(double x1, double y1, double rad1, double a11, double a12,
                                                    double x2, double y2, double rad2, double a21, double a22,
                                                    ksMathPointParam par)
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
        }
    }
}
