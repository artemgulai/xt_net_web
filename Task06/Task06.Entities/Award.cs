using System.Collections.Generic;

namespace Task06.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<int> Users { get; } = new List<int>();

        public override string ToString()
        {
            return $"ID: {Id}. Title: {Title}.";
        }
    }
}
