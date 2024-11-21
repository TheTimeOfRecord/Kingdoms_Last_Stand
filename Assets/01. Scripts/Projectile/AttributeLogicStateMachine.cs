using System.Collections.Generic;
using UnityEngine;

public class AttributeLogicStateMachine 
{
    private Dictionary<AttributeType, AttributeLogics> attributeLogicMap;

    public void Initialize()
    {
        attributeLogicMap = new Dictionary<AttributeType, AttributeLogics>
        {
            { AttributeType.Explosion, new ExplosionAttribute() },
            { AttributeType.Poison, new PoisonAttribute() },
            { AttributeType.Ice, new IceAttribute() },
            { AttributeType.Lighting, new LightingAttribute() },
            { AttributeType.Pierce, new PierceAttribute() },
            { AttributeType.Normal, new NormalAttribute() }
        };
    }

    public AttributeLogics GetAttributeLogic(AttributeType type)
    {
        if (attributeLogicMap.TryGetValue(type, out AttributeLogics logic))
        {
            return logic;
        }

        return null;
    }
}
