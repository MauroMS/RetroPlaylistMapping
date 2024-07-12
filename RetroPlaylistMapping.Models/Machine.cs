using System.Xml.Serialization;

namespace RetroPlaylistMapping.Models;

[XmlRoot(ElementName = "machine")]
public class Machine
{
    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "rom")] public Rom Rom { get; set; }

    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }
}