using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Vector_Graphics_Editor
{
    /// <summary>
    /// Base class for all figures.
    /// </summary>
    internal abstract class Figure
    {
        public Color LineColor { get; set; }

        protected Figure()
        {
            LineColor = Color.Black;
        }

        public abstract void ShowInfo();
    }
}
