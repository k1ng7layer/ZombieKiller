﻿using System;
using BehaviorDesigner.Runtime;
using Ecs.Extensions.UidGenerator;

namespace Ai.SharedVariables
{
    [Serializable]
    public class SharedUid : SharedVariable<Uid>
    {
        public static implicit operator SharedUid(Uid value)
        {
            return new SharedUid { Value = value };
        }
    }
}