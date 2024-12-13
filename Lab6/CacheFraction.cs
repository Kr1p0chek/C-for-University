using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6C_
{
    class CacheFraction : IFraction
    {
        IFraction fraction;
        private double? cachedValue { get; set; }
        public CacheFraction(IFraction f)
        {
            this.fraction = f;
        }
        public double GetValue()
        {
            if (!cachedValue.HasValue)
            {
                cachedValue = fraction.GetValue();
            }
            return cachedValue.Value;
        }

        public double? GetCachedValue()
        {
            if (!cachedValue.HasValue)
                return null;
            return cachedValue.Value;
        }

        public void SetNumDen(int numerator, int denominator)
        {
            fraction.SetNumDen(numerator, denominator);
            this.cachedValue = null;
        }
    }
}
