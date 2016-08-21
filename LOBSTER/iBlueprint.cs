using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOBSTER
{
    public interface IBlueprint<out TItemGroup, out TItemType, in TGroup, in TStat> where TItemGroup : struct, IComparable where TItemType : struct, IComparable where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        TItemGroup GetGroup();
        TItemType GetItemType();
        float GetMin(TGroup group, TStat stat);
        float GetMax(TGroup group, TStat stat);


    }
}
