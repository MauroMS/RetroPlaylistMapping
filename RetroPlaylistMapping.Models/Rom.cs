using System.Xml.Serialization;

namespace RetroPlaylistMapping.Models;

[XmlRoot(ElementName = "rom")]
public class Rom
{

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "size")]
    public int Size { get; set; }

    [XmlAttribute(AttributeName = "crc")]
    public string Crc { get; set; }

    [XmlAttribute(AttributeName = "md5")]
    public string Md5 { get; set; }

    [XmlAttribute(AttributeName = "sha1")]
    public string Sha1 { get; set; }
}