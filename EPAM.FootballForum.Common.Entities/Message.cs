using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FootballForum.Common.Entities
{
    public class Message : Topic
    {
        private int _topicid;

        public Message(int topicid, int creatorid, string text, DateTime createdAt, DateTime updatedAt) : base(creatorid, text, createdAt, updatedAt)
        {
            TopicID = topicid;
        }

        public Message(int id, string text, DateTime createdAt, string author) : base(text, createdAt, author)
        {
            ID = id;
            Text = text;
            CreatedAt = createdAt;
            Author = author;
        }

        public int TopicID
        {
            get => _topicid;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("ID can't be less then 0.");
                else
                    _topicid = value;
            }
        }
    }
}
