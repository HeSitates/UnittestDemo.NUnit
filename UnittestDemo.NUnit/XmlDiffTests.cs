using System.Xml;
using System.Xml.Linq;
using DemoClasses.Extensions;
using Microsoft.XmlDiffPatch;

namespace UnittestDemo.NUnit;

public class XmlDiffTests
{
  [Test]
  public void ExampleMicrosoft()
  {
    var doc = CreateXmlDocumentExample();

    var contactsAsXElement =
      new XElement(
        "Contacts",
        new XElement(
          "Contact",
          new XElement("Name", "Patrick Hines"),
          new XElement("Phone", "206-555-0144", new XAttribute("Type", "Home")),
          new XElement("Phone", "425-555-0145", new XAttribute("Type", "Work")),
          new XElement(
            "Address",
            new XElement("Street1", "123 Main St"),
            new XElement("City", "Mercer Island"),
            new XElement("State", "WA"),
            new XElement("Postal", "68042"))));

    TestContext.WriteLine(doc.SelectSingleNode("Contacts")?.InnerXml);
    TestContext.WriteLine(contactsAsXElement.ToXmlNode());

    var xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreWhitespace);
    var result = xmlDiff.Compare(doc.SelectSingleNode("Contacts"), contactsAsXElement.ToXmlNode());
    Assert.That(result, Is.True);
  }

  private static XmlDocument CreateXmlDocumentExample()
  {
    var doc = new XmlDocument();

    var name = doc.CreateElement("Name");
    name.InnerText = "Patrick Hines";

    var phone1 = doc.CreateElement("Phone");
    phone1.SetAttribute("Type", "Home");
    phone1.InnerText = "206-555-0144";

    var phone2 = doc.CreateElement("Phone");
    phone2.SetAttribute("Type", "Work");
    phone2.InnerText = "425-555-0145";

    var street1 = doc.CreateElement("Street1");
    street1.InnerText = "123 Main St";

    var city = doc.CreateElement("City");
    city.InnerText = "Mercer Island";

    var state = doc.CreateElement("State");
    state.InnerText = "WA";

    var postal = doc.CreateElement("Postal");
    postal.InnerText = "68042";

    var address = doc.CreateElement("Address");
    address.AppendChild(street1);
    address.AppendChild(city);
    address.AppendChild(state);
    address.AppendChild(postal);

    var contact = doc.CreateElement("Contact");
    contact.AppendChild(name);
    contact.AppendChild(phone1);
    contact.AppendChild(phone2);
    contact.AppendChild(address);

    var contactsAsXmlElement = doc.CreateElement("Contacts");
    contactsAsXmlElement.AppendChild(contact);
    doc.AppendChild(contactsAsXmlElement);
    return doc;
  }
}
