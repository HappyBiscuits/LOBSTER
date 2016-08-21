using System;
using System.Collections.Generic;

namespace LOBSTER
{
    public interface IGeneratedItem<TItemGroup, TItemType, TGroup, TStat> where TItemGroup : struct, IComparable where TItemType : struct, IComparable where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        TItemGroup ItemGroup { get; set; }
        TItemType ItemType { get; set; }
        List<IGeneratedItemStat<TGroup, TStat>> GetStats();
        void AddStat(TGroup group, TStat stat, float value);
        float GetStat(TGroup group, TStat stat);
    }
}