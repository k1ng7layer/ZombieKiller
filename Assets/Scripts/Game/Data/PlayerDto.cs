using System;
using System.Collections.Generic;

namespace Game.Data
{
    [Serializable]
    public class PlayerDto
    {
        public float Experience;
        public List<string> Buffs;
        public List<AttributeDto> Attributes;
    }
}