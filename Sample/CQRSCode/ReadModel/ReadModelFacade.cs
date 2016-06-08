﻿using CQRSCode.ReadModel.Dtos;
using CQRSCode.ReadModel.Infrastructure;
using System;
using System.Collections.Generic;

namespace CQRSCode.ReadModel
{
    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return InMemoryDatabase.List;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return InMemoryDatabase.Details[id];
        }
    }
}