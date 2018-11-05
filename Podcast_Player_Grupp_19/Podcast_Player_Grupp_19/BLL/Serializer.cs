using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Podcast_Player_Grupp_19.BLL {
    public class Serializer<T> {
        private string Path { get; set; }
        private JsonSerializer JsonSerializer { get; set; }
        private XmlSerializer XmlSerializer { get; set; }



        public Serializer(string pathToJson) {
            Path = pathToJson;
            JsonSerializer = new JsonSerializer {
                TypeNameHandling = TypeNameHandling.All
            };



        }
        public void XmlSerialize(ItemList<Podcast> list) {
            if (list.List.Count != 0) {
                XmlSerializer Xmlserializer = new XmlSerializer(typeof(ItemList<Podcast>));
                using (TextWriter writer = new StreamWriter("Podcasts.xml")) {
                    Xmlserializer.Serialize(writer, list);
                }


            } else {

            }


        }

        public void Serialize(T obj) {
            using (var sw = new StreamWriter(Path)) {
                using (var jtw = new JsonTextWriter(sw)) {
                    JsonSerializer.Serialize(jtw, obj);
                }
            }
        }

        public void test() {
            XmlSerializer xml = new XmlSerializer(typeof(XDocument)) {
                toXml().CreateReader(); 
        }

        public XDocument toXml() {
            using (var sr = new StreamReader(Path)) {
                using (var jtr = new JsonTextReader(sr)) {
                    var x = JsonConvert.DeserializeXNode(Path, "root");


                    return x;
                }
            }
        } } }