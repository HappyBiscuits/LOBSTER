using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOBSTER
{
    public interface IGeneratedItemStat<TGroup, TStat> where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        
    }

    public interface IGeneratedItem<TItemGroup, TItemType, TGroup, TStat> where TItemGroup : struct, IComparable where TItemType : struct, IComparable where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        TItemGroup ItemGroup { get; set; }
        TItemType ItemType { get; set; }
        List<IGeneratedItemStat<TGroup, TStat>> GetStats();
        void AddStat(TGroup group, TStat stat, float value);
        float GetStat(TGroup group, TStat stat);
    }
    public class ItemGenerator<TItemGroup, TItemType, TGroup, TStat> where TItemGroup : struct, IComparable where TItemType : struct, IComparable where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        private IBlueprintLoader<TItemGroup, TItemType, TGroup, TStat> _blueprintLoader;
        private Func<IGeneratedItem<TItemGroup, TItemType, TGroup, TStat>> _generateNewItem;
        private Func<IGeneratedItemStat<TGroup, TStat>> _generateNewItemStat;
        private Func<float, float, float> _randomRange; 

        public ItemGenerator(Func<IGeneratedItem<TItemGroup, TItemType, TGroup, TStat>> generateNewItem, Func<IGeneratedItemStat<TGroup, TStat>> generateNewItemStat, Func<float, float, float> randomRange)
        {
            _generateNewItem = generateNewItem;
            _generateNewItemStat = generateNewItemStat;
            _randomRange = randomRange;
        }

        public IGeneratedItem<TItemGroup, TItemType, TGroup, TStat> GenerateItem(TItemGroup itemGroup, TItemType itemType)
        {
            var blueprint = _blueprintLoader.GetBlueprint(itemGroup, itemType);

            var item = _generateNewItem();
            item.ItemGroup = itemGroup;
            item.ItemType = itemType;

            foreach (var val in blueprint.GetStats())
            {
                item.AddStat(val.Group, val.Stat, _randomRange(val.MinValue, val.MaxValue));
            }
            return item;

        }


    }

    public interface IBlueprintLoader<TItemGroup, TItemType, TGroup, TStat> where TItemGroup : struct, IComparable where TItemType : struct, IComparable where TGroup : struct, IComparable where TStat : struct, IComparable
    {
        IBlueprint<TItemGroup, TItemType, TGroup, TStat> GetBlueprint(TItemGroup itemGroup, TItemType itemType);
    }
}
