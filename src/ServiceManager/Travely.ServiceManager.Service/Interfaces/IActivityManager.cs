﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public interface IActivityManager
    {
        Task<Activity> CreateActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesAsync(int agencyId);
        Task<ActivityResponse> DeleteActivityAsync(long activityId);
        Task<Activity> EditActivityAsync(Activity activity);
    }
}
