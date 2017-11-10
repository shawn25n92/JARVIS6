using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JARVIS6
{
    public class JARVISWeb
    {
        public string TargetURL { get; set; }
        public JARVISWeb()
        {

        }
        public StatusObject GetURL()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject PostToURL()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
