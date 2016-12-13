using Kompas6API5;
using Kompas6Constants3D;

namespace PluginForKompas
{
    public static class ChamferMaker
    {
        public static void Create(double dist, double x, double y, double z)
        {
            ksEntityCollection edge = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_edge);
            if ((edge != null) && (edge.SelectByPoint(x, y, z)) && (edge.GetCount() != 0))
            {
                ksEntity chamfer = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_chamfer);
                ksChamferDefinition chDef = (ksChamferDefinition)chamfer.GetDefinition();

                if (chDef != null)
                {
                    chDef.tangent = true;
                    bool q = chDef.SetChamferParam(false, dist, dist);
                    ksEntityCollection chamferCollection = (ksEntityCollection)chDef.array();
                    chamferCollection.Clear();
                    bool p =chamferCollection.Add(edge.GetByIndex(0));
                    bool k = chamfer.Create();
                }
            }
        }
    }
}
