using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Polymorphism.Game
{
    class Field
    {
        public Field(Int32 width, Int32 heigth)
        {
            Width = width;
            Height = heigth;
        }

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
    }
}
