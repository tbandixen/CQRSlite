using System;

namespace CQRSCode.ReadModel.Events
{
    public class ItemsCheckedInToInventory : BaseEvent
    {
        public readonly int Count;

        public ItemsCheckedInToInventory(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}