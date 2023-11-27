using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct CubeSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        EntityManager entityManager = state.EntityManager;
        NativeArray<Entity> entities = entityManager.GetAllEntities(Allocator.Temp);

        foreach (Entity entity in entities)
        {
            if (entityManager.HasComponent<CubeComponent>(entity))
            {
                CubeComponent cube = entityManager.GetComponentData<CubeComponent>(entity);
                LocalTransform localTransform = entityManager.GetComponentData<LocalTransform>(entity);

                float3 moveDirection = cube.moveDirection * cube.moveSpeed * SystemAPI.Time.DeltaTime;

                localTransform.Position = localTransform.Position + moveDirection;
                entityManager.SetComponentData<LocalTransform>(entity, localTransform);

                if (cube.moveSpeed > 0)
                {
                    cube.moveSpeed -= SystemAPI.Time.DeltaTime;
                }
                else
                {
                    cube.moveSpeed = 0;
                }
                
                entityManager.SetComponentData<CubeComponent>(entity, cube);
            }
            
        }
    }
}