using System;

namespace ValidationObject
{
    internal class SchoolCapacityAttribute : Attribute
    {
        private int v;

        public SchoolCapacityAttribute(int v)
        {
            this.v = v;
        }
    }
}