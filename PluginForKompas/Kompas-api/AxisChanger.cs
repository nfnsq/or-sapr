using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    /// <summary>
    /// Класс для изменения базовой плоскости
    /// </summary>
    public class AxisChanger
    {
        private KompasApp _app;

        /// <summary>
        /// Коструктор с параметром
        /// </summary>
        /// <param name="app">Приложение компас</param>
        public AxisChanger(KompasApp app)
        {
            this._app = app;
        }

        /// <summary>
        /// Метод смещает базовую плоскость по оси OY на заданное расстояние
        /// </summary>
        public void MovingBasePlaneByYAxis(double offset, bool direction)
        {
            ksEntity plane = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDef = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (planeDef != null)
            {
                planeDef.SetPlane(_app.BasePlane);
                planeDef.direction = direction;
                planeDef.offset = offset;
                plane.Create();
            }
            _app.BasePlane = plane;
        }
    }
}
