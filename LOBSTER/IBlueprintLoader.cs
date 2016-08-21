using System;

namespace LOBSTER
{
    public interface IBlueprintLoader<TItemGroup, TItemType, TGroup, TStat> where TItemGroup : struct, IComparable where TItemType : struct, IComparable where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        IBlueprint<TItemGroup, TItemType, TGroup, TStat> GetBlueprint(TItemGroup itemGroup, TItemType itemType);
    }
}