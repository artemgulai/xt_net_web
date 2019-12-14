using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_05.FileChangeInfo
{
    class Change
    {
        protected DateTime _timeOfChange;
        protected ChangeType _typeOfChange;
        protected byte[] _content;

        public DateTime ChangeTime 
        {
            set { _timeOfChange = value; } 
            get => _timeOfChange; 
        }
        public ChangeType ChangeType 
        {
            set { _typeOfChange = value; }  
            get => _typeOfChange; 
        }
        public byte[] Content 
        {
            set { _content = value; }
            get => _content; 
        }

        public Change() { }

        public Change(DateTime timeOfChange, ChangeType typeOfChange, byte[] content = null)
        {
            _timeOfChange = timeOfChange;
            _typeOfChange = typeOfChange;
            _content = content;
        }
    }
}
