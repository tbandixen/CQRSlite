using System;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemRenamed : BaseEvent
    {
        public readonly string NewName;

        public InventoryItemRenamed(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}