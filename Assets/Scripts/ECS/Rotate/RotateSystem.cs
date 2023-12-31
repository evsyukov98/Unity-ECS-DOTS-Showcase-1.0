using Unity.Entities;
using Unity.Transforms;

/// <summary>
/// "ECS - System".
/// Система которая проверяет у всех "Entity" наличие "Component"
/// И дает им определенное поведение.
/// </summary>
public partial class RotateSystem : SystemBase
{
    protected override void OnUpdate()
    {
        // SystemAPI.Query<T>();  // это запросить все компоненты по типу T. Также есть перегрузки в виде <T,T,T ...> 

        foreach ((RefRO<RotateSpeedComponent> component, RefRW<LocalTransform> transform)
            in SystemAPI.Query<RefRO<RotateSpeedComponent>, RefRW<LocalTransform>>())
        {
            // ValueRW - запись
            // ValueRO - чтение
            transform.ValueRW = transform.ValueRO.RotateX(component.ValueRO.value * SystemAPI.Time.DeltaTime);
        }
    }
}
