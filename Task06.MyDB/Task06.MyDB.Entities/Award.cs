using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task06.MyDB.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public byte[] AwardImage { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}. Title: {Title}.";
        }
    }
}
