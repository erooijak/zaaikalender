﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

using Zk.Models;

namespace Zk.ViewModels
{
    /// <summary>
    ///     View model used for the seasons and months displayed on view, 
    ///     the CSS classes and the JavaScript binding.
    /// </summary>
    public class MainViewModel
    {
        public IEnumerable<string> SeasonsCssClasses { get; set; }
        public IEnumerable<string> SeizoenenForDisplay { get; set; }
        public Queue<string> MonthsOrderedForDisplay { get; set; }
    }

}