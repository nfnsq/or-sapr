using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    public static class AxisChanger
    {
        /// <summary>
        /// Метод смещает базовую плоскость по оси OY на заданное расстояние
        /// </summary>
        public static void MovingBasePlaneByYAxis(double offset, bool direction)
        {
            ksEntity plane = (ksEntity)KompasApp.Part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDef = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (planeDef != null)
            {
                planeDef.SetPlane(KompasApp.BasePlane);
                planeDef.direction = direction;
                planeDef.offset = offset;
                plane.Create();
            }
            KompasApp.BasePlane = plane;
        }
    }
}
