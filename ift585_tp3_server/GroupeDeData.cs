using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_server
{
    public class GroupeDeData
    {
        public DiscussionRoom room { get; set; }

        public List<User> users { get; set; }
        public GroupeDeData()
        { }
        public GroupeDeData(DiscussionRoom r, List<User> u)
        { room = r; users = u; }
    }
}
