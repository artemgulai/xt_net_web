using System.Collections.Generic;

namespace Task06.Entities
{
    public class Award
    {
        public Award()
        {
            Users = new SortedSet<int>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public ISet<int> Users { get; }

        public bool AddUser(int userId)
        {
            return Users.Add(userId);
        }

        public bool RemoveUser(int userId)
        {
            return Users.Remove(userId);
        }

        public override string ToString()
        {
            return $"ID: {Id}. Title: {Title}.";
        }
    }
}
