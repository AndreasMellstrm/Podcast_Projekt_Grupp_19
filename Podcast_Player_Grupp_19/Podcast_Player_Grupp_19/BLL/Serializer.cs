using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Podcast_Player_Grupp_19.BLL {
   public class Serializer<T> {
        private string Path { get; set; }
        private JsonSerializer JsonSerializer{ get; set; }
        
        

        public Serializer(string pathToJson) {
            Path = pathToJson;
            JsonSerializer = new JsonSerializer {
                TypeNameHandling = TypeNameHandling.All
            };

            
        }


        public static string XmlSerializer(object o) {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }catch(Exception ex) {

            }
            finally {
                sw.Close();
                if(tw != null) {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        public void test(T obj) {
            using(var sw = new StreamWriter(Path)) {
                using (var xtw = new XmlTextWriter(sw)) {

                }
            }
        }

        public void Serialize(T obj) {
            using(var sw = new StreamWriter(Path)) {
                using(var jtw = new JsonTextWriter(sw)) {
                    JsonSerializer.Serialize(jtw, obj); 
                }
            }
        }

        public T DeSerialize() {
            using(var sr = new StreamReader(Path)) {
                using(var jtr = new JsonTextReader(sr)) {
                    return JsonSerializer.Deserialize<T>(jtr);
                } 
            }
        }

        


    }
}
