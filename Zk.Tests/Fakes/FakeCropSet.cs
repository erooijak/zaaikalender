﻿using System.Linq;
using Zk.Models;

namespace Zk
{
    public class FakeFarmingActionSet : FakeDbSet<FarmingAction>
	{
        public override FarmingAction Find(params object[] keyValues)
		{
			return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
		}
	}
}