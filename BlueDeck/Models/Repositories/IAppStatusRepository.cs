﻿using BlueDeck.Models.Types;
using System.Collections.Generic;

namespace BlueDeck.Models.Repositories
{
    public interface IAppStatusRepository : IRepository<AppStatus>
    {
        List<ApplicationStatusSelectListItem> GetApplicationStatusSelectListItems();
        List<AppStatus> GetAppStatusesWithMemberCount();
        AppStatus GetAppStatusWithMemberCount(int id);
    }
}

