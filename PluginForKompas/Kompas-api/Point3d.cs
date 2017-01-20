namespace PluginForKompas
{
    /// <summary>
    /// Сущность для описания трехмерной точки
    /// </summary>
    public struct Point3d
    {
        /// <summary>
        /// Конструктор для создания новой точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3d(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }
        private double _x;
        /// <summary>
        /// Координата Х точки в трехмерном пространстве
        /// </summary>
        public double X 
        { 
            get
            {
                return _x;
            }
            set
            {
                X = _x;
            }
        }

        private double _y;
        /// <summary>
        /// Координата Y точки в трехмерном пространстве
        /// </summary>
        public double Y 
        {
            get
            {
                return _y;
            }
            set
            {
                Y = _y;
            }
        }

        private double _z;
        /// <summary>
        /// Координата Z точки в трехмерном пространстве
        /// </summary>
        public double Z 
        {
            get 
            {
                return _z;
            }
            set
            {
                Z = _z;
            }
        } 
    }
}
