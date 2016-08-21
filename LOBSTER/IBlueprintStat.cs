using System;

namespace LOBSTER
{
    public interface IBlueprintStat<TGroup, TStat> where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        TGroup Group { get; set; }
        TStat Stat { get; set; }
        float MinValue { get; set; }
        float MaxValue { get; set; }
    }
}