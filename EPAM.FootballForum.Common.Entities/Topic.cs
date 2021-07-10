using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FootballForum.Common.Entities
{
    public class Topic
    {
        public Topic(int id, int creatorid, string text, DateTime updatedAt, string author)
        {
            ID = id;
            CreatorID = creatorid;
            Text = text;
            UpdatedAt = updatedAt;
            Author = author;
        }

        public Topic(int id, string text)
        {
            ID = id;
            Text = text;
        }

        public Topic(int creatorid, string text, DateTime createdAt, string author)
        {
            CreatorID = creatorid;
            Text = text;
            CreatedAt = createdAt;
            Author = author;
        }

        public Topic(string text, DateTime createdAt, string author)
        {
            Text = text;
            CreatedAt = createdAt;
            Author = author;
        }

        public Topic(int creatorid, string text, DateTime createdAt, DateTime updatedAt)
        {
            CreatorID = creatorid;
            Text = text;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        private int _id;
        public int ID
        {
            get => _id;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("ID can't be less then 0.");
                else
                    _id = value;
            }
        }

        private int _creatorid;
        public int CreatorID
        {
            get => _creatorid;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("ID can't be less then 0.");
                else
                    _creatorid = value;
            }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (value == null || value.Length >= 500)
                    throw new ArgumentException($"You can't put null or string with length more then 500 into text.");
                else
                    _text = value;
            }
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            protected set
            {
                _createdAt = value;
            }
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get => _updatedAt;
            private set
            {
                _updatedAt = value;
            }
        }

        private string _author;
        public string Author
        {
            get => _author;
            set
            {
                if (value == null)
                    throw new ArgumentException($"You can't put null or string with length less then 2 into login.");
                else
                    _author = value;
            }
        }
    }
}
