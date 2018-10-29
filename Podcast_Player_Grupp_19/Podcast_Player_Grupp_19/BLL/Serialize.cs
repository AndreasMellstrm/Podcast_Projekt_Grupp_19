using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Podcast_Player_Grupp_19.BLL {
    class Serialize {
        public void serializer() {
            var doc = XmlWriter.Create("test.xml");
            doc.WriteStartDocument();

            doc.WriteString("testtesttest");

            doc.Close();
        }
    }
}
