using System;
using System.Collections.Generic;
using System.Text;

namespace TVSSys
{
    public class ItemCombobox
    {
        public string Name;
        public string Value;
        public ItemCombobox(string name, string value)
        {
            Name = name; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }
}
