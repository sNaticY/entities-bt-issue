using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct EntityTemplateData : IComponentData
{
    public Entity Value;
}
