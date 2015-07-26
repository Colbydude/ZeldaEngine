using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using ZeldaEngine.Maps;

namespace ZeldaEngine
{
    public static class XMLSerialization
    {
        public static bool LoadXML<T>(out T theObject, string path)
        {
            theObject = default(T);
            try
            {
                using (var stream = TitleContainer.OpenStream(path))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    theObject = (T)serializer.Deserialize(stream);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }
    }
}
