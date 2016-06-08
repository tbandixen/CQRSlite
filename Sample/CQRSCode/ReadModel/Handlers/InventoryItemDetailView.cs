﻿using CQRSCode.ReadModel.Dtos;
using CQRSCode.ReadModel.Events;
using CQRSCode.ReadModel.Infrastructure;
using CQRSlite.Events;
using System;

namespace CQRSCode.ReadModel.Handlers
{
    public class InventoryItemDetailView : IEventHandler<InventoryItemCreated>,
                                            IEventHandler<InventoryItemDeactivated>,
                                            IEventHandler<InventoryItemRenamed>,
                                            IEventHandler<ItemsRemovedFromInventory>,
                                            IEventHandler<ItemsCheckedInToInventory>
    {
        public void Handle(InventoryItemCreated message)
        {
            InMemoryDatabase.Details.Add(message.Id, new InventoryItemDetailsDto(message.Id, message.Name, 0, message.Version));
        }

        public void Handle(InventoryItemRenamed message)
        {
            InventoryItemDetailsDto d = GetDetailsItem(message.Id);
            d.Name = message.NewName;
            d.Version = message.Version;
        }

        private InventoryItemDetailsDto GetDetailsItem(Guid id)
        {
            InventoryItemDetailsDto dto;
            if (!InMemoryDatabase.Details.TryGetValue(id, out dto))
            {
                throw new InvalidOperationException("did not find the original inventory this shouldnt happen");
            }
            return dto;
        }

        public void Handle(ItemsRemovedFromInventory message)
        {
            var dto = GetDetailsItem(message.Id);
            dto.CurrentCount -= message.Count;
            dto.Version = message.Version;
        }

        public void Handle(ItemsCheckedInToInventory message)
        {
            var dto = GetDetailsItem(message.Id);
            dto.CurrentCount += message.Count;
            dto.Version = message.Version;
        }

        public void Handle(InventoryItemDeactivated message)
        {
            InMemoryDatabase.Details.Remove(message.Id);
        }
    }
}
