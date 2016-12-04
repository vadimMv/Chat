using System;
using System.Collections.Generic;
namespace MessageType
{
    /// <summary>
    /// Message class library used for network serialization
    /// </summary>
    [Serializable]

    public class Message
    {

        public string Name { get; private set; }

        public string Text { get; private set; }

        public string Color { get; private set; }
        public byte[] ImageArray { get; set; }       // bytes array for image sending
        /// <summary>
        /// private list getter/setter
        /// </summary>
        public List<string> PrivateList
        {
            get
            {
                return _private;
            }
            set
            {
                _private.AddRange(value);
            }
        }

        private List<string> _private;  // private list 


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="name">name client</param>
        /// <param name="text">message body</param>
        /// <param name="color">font color</param>

        public Message(string name, string text, string color)
        {
            Name = name;
            Text = text;
            Color = color;
            _private = new List<string> { name };
        }


        /// <summary>
        /// message obj overrided
        /// </summary>
        /// <returns>object to string</returns>
        public override string ToString()  
        {
            return $" {Name} said : \n  {Text} \n ";
        }
    }
}
