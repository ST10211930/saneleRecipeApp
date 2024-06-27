using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPart3v2
{
    public class StepDetails
    {
        //constructor
        public StepDetails(TextBox textboxSteps)
        {
            this.textboxSteps = textboxSteps;
        }

        public TextBox textboxSteps { get; set; }
    }
}
