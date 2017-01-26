using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PluginForKompas
{
    /// <summary>
    /// Сущность для получения указателей на интерфейсы приложения Kompas
    /// </summary>
    public class KompasApp
    {
        // Указатель на главный интерфейс API системы КОМПАС
        public KompasObject Kompas;

        // Указатель на интерфейс документа трехмерной модели
        public ksDocument3D Doc3d;

        // Указатель на интерфейс главного компонента
        public ksPart Part;

        // Указатель на интерфейс базовой плоскости XOZ
        public ksEntity BasePlane;

        // Указатель на интерфейс для работы с математическими функциями
        public ksMathematic2D Mat;

        /// <summary>
        /// Метод создает новый документ трехмерной 
        /// модели и получает указатель на интерфейс 
        /// главного компонента созданного документа
        /// </summary>
        public void CreateNewDoc()
        {
            try
            {
                Doc3d = (ksDocument3D)Kompas.Document3D();
                Doc3d.Create();
                Doc3d.fileName = "Gear";
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
        /// API КОМПАС
        /// </summary>
        public void GetActiveApp()
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

                }
            }
            if (Kompas != null)
            {
                Kompas.Visible = true;
                Kompas.ActivateControllerAPI();
            }
            
        }
        /// <summary>
        /// Метод создает новое прилжение Компас и 
        /// получает указатель на главный интерфейс API
        /// </summary>
        public void NewApp()
        {
            
            Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
            Kompas = (KompasObject)Activator.CreateInstance(t);
            if (Kompas != null)
            {
                Kompas.Visible = true;
                Kompas.ActivateControllerAPI();
            }
        }
    }
}
