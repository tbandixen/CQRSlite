﻿using CQRSCode.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace CQRSCode.ReadModel.Infrastructure
{
    public static class InMemoryDatabase
    {
        public static readonly Dictionary<Guid, InventoryItemDetailsDto> Details = new Dictionary<Guid, InventoryItemDetailsDto>();
        public static readonly List<InventoryItemListDto> List = new List<InventoryItemListDto>();
    }
}