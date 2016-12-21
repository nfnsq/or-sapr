using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    /// <summary>
    /// Класс выполняет операцию "фаска"
    /// </summary>
    public static class ChamferMaker
    {
        /// <summary>
        /// Метод создает фаску в 45'
        /// </summary>
        /// <param name="dist">Длина катетов фаски</param>
        /// <param name="x">координата х ребра</param>
        /// <param name="y">координата у ребра</param>
        /// <param name="z">координата z ребра</param>
        public static bool Create(double dist, double x, double y, double z)
        {
            try
            {
                ksEntityCollection edge = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_edge);
                if ((edge != null) && (edge.SelectByPoint(x, y, z)) && (edge.GetCount() != 0))
                {
                    ksEntity chamfer = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_chamfer);
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
