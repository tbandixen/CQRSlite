using CQRSCode.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace CQRSCode.ReadModel
{
    public interface IReadModelFacade
    {
        IEnumerable<InventoryItemListDto> GetInventoryItems();
        InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
    }
}