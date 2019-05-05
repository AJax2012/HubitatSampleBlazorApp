using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubitatSampleBlazorApp.Data
{
    public class Light
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public ICollection<LightAttribute> Attributes { get; set; }
        public ICollection<object> Capabilities { get; set; }
        public ICollection<string> Commands { get; set; }
    }
}
