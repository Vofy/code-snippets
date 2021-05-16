using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace MemoryKeeper
{
    class Note
    {
        private int id;
        private string title;
        private string content;
        private string timeUpdated;
        private string deadline;

        public Note() { }

        public Note(int id, string title, string content, string timeUpdated, string alertTime)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.timeUpdated = timeUpdated;
            this.deadline = alertTime;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string TimeUpdated { get => timeUpdated; set => timeUpdated = value; }
        public string Deadline { get => deadline; set => deadline = value; }
    }
}
