using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.MyDB.Entities
{
    public struct UserAwardLink
    {
        public UserAwardLink(int userId, int awardId)
        {
            UserId = userId;
            AwardId = awardId;
        }

        public int UserId { get; }
        public int AwardId { get; }
    }
}
