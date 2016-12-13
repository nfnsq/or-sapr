using Kompas6Constants3D;
using Kompas6API5;

namespace PluginForKompas
{
    public static class SketchCreator
    {
        public static ksSketchDefinition MakeSketch()
        {
            ksEntity entitySketch = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
            sketchDef.SetPlane(KompasApp.basePlane);
            entitySketch.Create();
            return sketchDef;
        }
    }
}
