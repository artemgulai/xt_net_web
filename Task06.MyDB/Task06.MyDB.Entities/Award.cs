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
        public Award()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                AwardImage = webClient.DownloadData("https://i.pinimg.com/236x/68/e0/07/68e0079b7540b1191555184de989b9c9.jpg");
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public byte[] AwardImage { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}. Title: {Title}.";
        }
    }
}
