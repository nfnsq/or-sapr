﻿using Kompas6Constants3D;
using Kompas6API5;

namespace PluginForKompas
{
    /// <summary>
    /// Класс эскиза
    /// </summary>
    public static class SketchCreator
    {
        /// <summary>
        /// Метод создает новый эскиз
        /// </summary>
        /// <returns>Возвращает указатель на интерфейс эскиза</returns>
        public static ksSketchDefinition MakeSketch()
        {
            try
            {
                ksEntity entitySketch = (ksEntity)KompasApp.Part.NewEntity((short)Obj3dType.o3d_sketch);
                ksSketchDefinition sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                sketchDef.SetPlane(KompasApp.BasePlane);
                entitySketch.Create();
                return sketchDef;
            }
            catch
            {
                return null;
            }
        }
    }
}