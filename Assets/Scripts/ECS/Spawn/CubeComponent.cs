using Unity.Entities;
using Unity.Mathematics;

public struct CubeComponent : IComponentData
{
    public float3 moveDirection;
    public float moveSpeed;
}