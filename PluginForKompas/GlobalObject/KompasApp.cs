﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PluginForKompas
{
    public static class KompasApp
    {
        public static KompasObject kompas;
        public static ksDocument3D doc3d;
        public static ksPart part;
        public static ksEntity basePlane;
        public static ksMathematic2D mat;

        /// <summary>
        /// Метод создает новый документ трехмерной 
        /// модели и получает указатель на интерфейс 
        /// главного компонента созданного документа
        /// </summary>
        public static void CreateNewDoc()
        {
            try
            {
                doc3d = (ksDocument3D)kompas.Document3D();
                doc3d.fileName = "Gear";
                doc3d.Create();
                doc3d.UpdateDocumentParam();
                part = (ksPart)doc3d.GetPart((short)Part_Type.pTop_Part);
                basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                mat = (ksMathematic2D)kompas.GetMathematic2D();
            }
            catch
            {
                MessageBox.Show("KompasApplication doesn't found!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод получает указатель на интерфейс
        /// текущего документа трехмерной модели
        /// и указатель на интерфейс главного компонента
        /// </summary>
        public static void GetActiveDoc()
        {
            try
            {
                doc3d = (ksDocument3D)kompas.ActiveDocument3D();
                part = (ksPart)doc3d.GetPart((short)Part_Type.pTop_Part);
                basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                mat = (ksMathematic2D)kompas.GetMathematic2D();

                EntityCollection entityCol = (EntityCollection)part.EntityCollection((short)Obj3dType.o3d_unknown);
                
                for (int i = 0; i < entityCol.GetCount(); i++)
                {
                    ksEntity entity = entityCol.GetByIndex(i);
                    doc3d.DeleteObject(entity);
                }
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
            if (kompas == null)
            {
                string progID = "KOMPAS.Application.5";
                try
                {
                    kompas = (KompasObject)Marshal.GetActiveObject(progID);
                }
                catch (COMException)
                {
                    Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    kompas = (KompasObject)Activator.CreateInstance(t);
                }
                if (kompas != null)
                {
                    kompas.Visible = true;
                    kompas.ActivateControllerAPI();
                }
            }
        }

        /// <summary>
        /// Метод закрывает приложение КОМПАС
        /// </summary>
        public static void Exit()
        {
            kompas.Quit();
        }
    
        /// <summary>
        /// Метод смещает базовую плоскость по оси OY на заданное расстояние
        /// </summary>
        /// <param name="offset">Расстояние от базовой плоскости до смещеннной</param>
        public static void MovingBasePlaneByYAxis(double offset)
        {
            ksEntity plane = (ksEntity)KompasApp.part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDef = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (planeDef != null)
            {
                planeDef.SetPlane(basePlane);
                planeDef.direction = true;
                planeDef.offset = offset;
                plane.Create();
            }
            basePlane = plane;
        }
    }
}
