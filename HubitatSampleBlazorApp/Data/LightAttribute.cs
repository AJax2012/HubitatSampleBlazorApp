using System.Collections.Generic;

namespace HubitatSampleBlazorApp.Data
{
    public class LightAttribute
    {
        public string Name { get; set; }
        public string CurrentValue { get; set; }
        public string DataType { get; set; }
        public ICollection<string> Values { get; set; }
    }
}