using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_05.FileChangeInfo
{
    internal class Change
    {
        public DateTime ChangeTime { set; get; }
        public ChangeType ChangeType { set; get; }
        public byte[] Content { set; get; }

        public Change() { }

        public Change(DateTime timeOfChange, ChangeType typeOfChange, byte[] content = null)
        {
            ChangeTime = timeOfChange;
            ChangeType = typeOfChange;
            Content = content;
        }
    }
}
