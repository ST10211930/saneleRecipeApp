using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPart3v2
{
    public class RecipeName
    {
        //constructor
        public RecipeName(TextBox textboxRecipeName)
        {
            this.textboxRecipeName = textboxRecipeName;
        }

        public TextBox textboxRecipeName { get; set; }
    }
}
