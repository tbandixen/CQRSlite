using System;

namespace CQRSCode.ReadModel.Events
{
    public class ItemsRemovedFromInventory : BaseEvent
    {
        public readonly int Count;

        public ItemsRemovedFromInventory(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}