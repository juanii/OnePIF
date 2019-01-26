using System;

namespace OnePIF.Records
{
    public class ItemFieldAttribute : Attribute
    {
        public Types.SectionFieldType type { get; set; }

        public bool multiline { get; set; }

        public string sectionName { get; set; }

        public string fieldName { get; set; }

        public ItemFieldAttribute(Types.SectionFieldType type)
        {
            this.type = type;
        }
    }
}
