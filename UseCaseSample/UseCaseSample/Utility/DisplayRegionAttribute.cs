using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseSample.Utility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DisplayRegionAttribute : Attribute
    {

        private bool _disableContent;
        public bool DisableContent
        {
            get { return _disableContent1; }
            set { _disableContent1 = value; }
        }

        private string _regionName;
        private bool _disableContent1;

        public string RegionName
        {
            get { return _regionName; }
        }

        public DisplayRegionAttribute(string regionName)
        {
            _regionName = regionName;
        }
    }
}
