using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    /// <summary>
    /// Класс выполняет операцию "фаска"
    /// </summary>
    public class ChamferMaker
    {
        private KompasApp _app;

        /// <summary>
        /// Коструктор с параметром
        /// </summary>
        /// <param name="app">Приложение компас</param>
        public ChamferMaker(KompasApp app)
        {
            this._app = app;
        }

        /// <summary>
        /// Метод создает фаску в 45'
        /// </summary>
        public bool Create(double dist, Point3d coor)
        {
            try
            {
                ksEntityCollection edge = (ksEntityCollection)_app.Part.EntityCollection((short)Obj3dType.o3d_edge);
                if ((edge != null) && (edge.SelectByPoint(coor.X, coor.Y, coor.Z)) && (edge.GetCount() != 0))
                {
                    ksEntity chamfer = (ksEntity)_app.Part.NewEntity((short)Obj3dType.o3d_chamfer);
                    ksChamferDefinition chDef = (ksChamferDefinition)chamfer.GetDefinition();

                    if (chDef != null)
                    {
                        chDef.tangent = true;
                        chDef.SetChamferParam(false, dist, dist);
                        ksEntityCollection chamferCollection = (ksEntityCollection)chDef.array();
                        chamferCollection.Clear();
                        chamferCollection.Add(edge.GetByIndex(0));
                        chamfer.Create();
                    }
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
