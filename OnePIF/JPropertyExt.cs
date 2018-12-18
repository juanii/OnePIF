using Newtonsoft.Json.Linq;
using System;

static internal class JPropertyExt
{
    public static JProperty Rename(JProperty property, string newName)
    {
        if (property == null)
            throw new ArgumentNullException("property", "Cannot rename a null token");

        if (property.Parent == null)
            throw new InvalidOperationException("Cannot rename a property with no parent");

        JProperty newProperty = new JProperty(newName, property.Value);
        property.Replace(newProperty);

        return newProperty;
    }

    public static JProperty Move(JProperty property, JContainer newParent)
    {
        if (property == null)
            throw new ArgumentNullException("property", "Cannot move a null token");

        if (newParent == null)
            throw new ArgumentNullException("newParent", "Cannot move token to a null parent");

        if (property.Parent == null)
            throw new InvalidOperationException("Cannot move a property with no parent");

        property.Remove();
        newParent.Add(property);

        return property;
    }
}