using System;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemDeactivated : BaseEvent
    {
        public InventoryItemDeactivated(Guid id)
        {
            Id = id;
        }
    }
}