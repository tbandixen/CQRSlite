using System;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemCreated : BaseEvent 
	{
        public readonly string Name;
        public InventoryItemCreated(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }
	}
}