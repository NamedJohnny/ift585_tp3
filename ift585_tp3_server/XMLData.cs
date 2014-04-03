using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_server
{
    public class XMLData
    {
        public List<DiscussionRoom> rooms { get; set; }

        public List<User> users { get; set; }
        public XMLData()
        { }
        public XMLData(List<DiscussionRoom> r, List<User> u)
        { rooms = r; users = u; }
    }
}
