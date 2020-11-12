using RestSharp;
using RestSharp.Serialization;
using Services.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Services.Infrastructure.Restsharp.Serializers
{
    //https://github.com/ErcinDedeoglu/TCMB-Exchange-Rates/blob/master/TCMB.Helper/XmlHelper.cs
    public class CustomXmlSerializer : IRestSerializer
    {
        public CustomXmlSerializer()
        {

        }
        public string[] SupportedContentTypes => new [] { "application/xml" };

        public DataFormat DataFormat => DataFormat.Xml;

        public string ContentType { get; set; } = "application/json";

        public T Deserialize<T>(IRestResponse response)
        {
            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(response.Content);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader stringReader = new StringReader(xmlString))
                {
                    Type outType = typeof(T);
                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader xmlReader = new XmlTextReader(stringReader))
                    {
                        objectOut = (T)serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objectOut;
        }

        public string Serialize(Parameter parameter)
        {
            return Serialize(parameter.Value);
        }

        public string Serialize(object obj) => JsonSerializer.Serialize(obj);
    }
}
