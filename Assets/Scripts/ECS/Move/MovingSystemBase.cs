using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

/// <summary>
/// "ECS - System".
/// Система которая проверяет у всех "Entity" наличие "Component"
/// И дает им определенное поведение.
/// </summary>
public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        // Запрашиваем "entity" с "components" - LocalTransform, MovingSpeed, TargetPosition 
        foreach (var (localTransform, speed, targetPosition) in 
            SystemAPI.Query<RefRW<LocalTransform>, RefRO<MovingSpeedComponent>, RefRW<TargetPositionComponent>>()) 
        {
            float3 direction = math.normalize(targetPosition.ValueRO.Position - localTransform.ValueRO.Position);
            
            localTransform.ValueRW.Position += direction * SystemAPI.Time.DeltaTime * speed.ValueRO.value;
        }
    }
}