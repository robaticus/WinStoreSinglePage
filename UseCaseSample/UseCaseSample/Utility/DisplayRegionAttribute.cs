using System;

namespace UseCaseSample.Utility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DisplayRegionAttribute : Attribute
    {
        private readonly string _regionName;
        private bool _disableContent;

        public DisplayRegionAttribute(string regionName)
        {
            _regionName = regionName;
        }

        public bool DisableContent { get; set; }

        public string RegionName
        {
            get { return _regionName; }
        }
    }
}