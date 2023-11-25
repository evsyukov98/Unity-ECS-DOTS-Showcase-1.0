using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


public class TargetPositionAuthoring : MonoBehaviour                     
{
    public float3 value;
}

public struct TargetPositionComponent : IComponentData
{
    public float3 value;
}

public class TargetPositionBaker : Baker<TargetPositionAuthoring>
{
    public override void Bake(TargetPositionAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);                     
        TargetPositionComponent component = new TargetPositionComponent {value = authoring.value}; 
        
        AddComponent(entity, component);                                           
    }
}

