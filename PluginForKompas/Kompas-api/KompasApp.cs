using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PluginForKompas
{
    public class KompasApp
    {
        public static KompasObject Kompas;
        public static ksDocument3D Doc3d;
        public static ksPart Part;
        public static ksEntity BasePlane;
        public static ksMathematic2D Mat;

        /// <summary>
        /// Метод создает новый документ трехмерной 
        /// модели и получает указатель на интерфейс 
        /// главного компонента созданного документа
        /// </summary>
        public static void CreateNewDoc()
        {
            try
            {
                Doc3d = (ksDocument3D)Kompas.Document3D();
                Doc3d.fileName = "Gear";
                Doc3d.Create();
                Doc3d.UpdateDocumentParam();
                Part = (ksPart)Doc3d.GetPart((short)Part_Type.pTop_Part);
                BasePlane = (ksEntity)Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                Mat = (ksMathematic2D)Kompas.GetMathematic2D();
            }
            catch
            {
                MessageBox.Show("KompasApplication doesn't found!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод получает указатель активного интерфейса
        /// API КОМПАС или создает новое при его отсутствии
        /// </summary>
        public static void GetActiveApp()
        {
            if (Kompas == null)
            {
                string progID = "KOMPAS.Application.5";
                try
                {
                    Kompas = (KompasObject)Marshal.GetActiveObject(progID);
                }
                catch (COMException)
                {
                    Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    Kompas = (KompasObject)Activator.CreateInstance(t);
                }
                if (Kompas != null)
                {
                    Kompas.Visible = true;
                    Kompas.ActivateControllerAPI();
                }
            }
        }

        /// <summary>
        /// Метод закрывает приложение КОМПАС
        /// </summary>
        public static void Exit()
        {
            Kompas.Quit();
        }

        /// <summary>
        /// Метод смещает базовую плоскость по оси OY на заданное расстояние
        /// </summary>
        /// <param name="offset">Расстояние от базовой плоскости до смещеннной</param>
        public static void MovingBasePlaneByYAxis(double offset, bool direction)
        {
            ksEntity plane = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDef = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (planeDef != null)
            {
                planeDef.SetPlane(BasePlane);
                planeDef.direction = direction;
                planeDef.offset = offset;
                plane.Create();
            }
            BasePlane = plane;
        }
    }
}
