using Kompas6Constants3D;
using Kompas6API5;

namespace PluginForKompas
{
    public static class CircularCopyMaker
    {
        public static void CreateOperationCircPartArray(int count)
        {
            ksEntityCollection elemCol = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_cutExtrusion);
            if ((elemCol != null) && (elemCol.GetCount() != 0))
            {
                ksEntity axis = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_axisOY);
                ksEntity circCopy = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_circularCopy);
                ksCircularCopyDefinition CopyDef = (ksCircularCopyDefinition)circCopy.GetDefinition();

                if (CopyDef != null)
                {
                    CopyDef.count1 = 1;
                    CopyDef.count2 = count;
                    CopyDef.step2 = 360;
                    CopyDef.factor2 = true;
                    CopyDef.SetAxis(axis);
                    ksEntityCollection copiedElemCol = (ksEntityCollection)CopyDef.GetOperationArray();
                    copiedElemCol.Clear();
                    int i = elemCol.GetCount();
                    copiedElemCol.Add(elemCol.GetByIndex(i - 1));
                    circCopy.Create();
                }
            }
        }

        public static void CreateChamferCircPartArray(int count)
        {
            ksEntityCollection elemCol = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_cutExtrusion);
            ksEntityCollection chamCol = (ksEntityCollection)KompasApp.part.EntityCollection((short)Obj3dType.o3d_chamfer);

            if ((elemCol != null) && (elemCol.GetCount() != 0)
                && (chamCol != null) && (chamCol.GetCount() != 0))
            {
                ksEntity axis = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_axisOY);
                ksEntity circCopy = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_circularCopy);
                ksCircularCopyDefinition CopyDef = (ksCircularCopyDefinition)circCopy.GetDefinition();

                if (CopyDef != null)
                {
                    CopyDef.count2 = count;
                    CopyDef.step2 = 360;
                    CopyDef.factor2 = true;
                    CopyDef.SetAxis(axis);
                    ksEntityCollection copiedElemCol = (ksEntityCollection)CopyDef.GetOperationArray();
                    copiedElemCol.Clear();
                    int i = elemCol.GetCount();
                    copiedElemCol.Add(elemCol.GetByIndex(i - 1));
                    for (int j = chamCol.GetCount() - 4; j < chamCol.GetCount(); j++)
                    {
                        copiedElemCol.Add(chamCol.GetByIndex(j));
                    }
//                    copiedElemCol.Add(chamCol.GetByIndex(j - 2));
//                    copiedElemCol.Add(chamCol.GetByIndex(j - 3));
//                    copiedElemCol.Add(chamCol.GetByIndex(j - 4));


                    circCopy.Create();
                }
            }
        }
    }
}
