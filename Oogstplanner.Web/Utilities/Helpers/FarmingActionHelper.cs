﻿using System;

using Oogstplanner.Models;
using Oogstplanner.Utilities.ExtensionMethods;

namespace Oogstplanner.Utilities.Helpers
{
    public static class FarmingActionHelper
    {

        public static ActionType GetRelatedActionType(FarmingAction action)
        {
            return action.Action == ActionType.Harvesting ? ActionType.Sowing : ActionType.Harvesting;
        }
            
        public static Month GetRelatedMonth(FarmingAction action, int cropGrowingTime)
        {
            return action.Action == ActionType.Harvesting 
                ? action.Month.Subtract(cropGrowingTime)
                : action.Month.Add(cropGrowingTime);
        }
    }
}

