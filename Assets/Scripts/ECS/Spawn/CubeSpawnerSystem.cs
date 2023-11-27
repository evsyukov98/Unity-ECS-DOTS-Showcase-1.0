using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

[BurstCompile]
public partial struct CubeSpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        // пытемся взять первый существующий entity с компонентом CubeSpawner 
        if (!SystemAPI.TryGetSingletonEntity<CubeSpawnerComponent>(out Entity spawnerEntity))
            return;

        // берем component
        RefRW<CubeSpawnerComponent> spawnerComponent = SystemAPI.GetComponentRW<CubeSpawnerComponent>(spawnerEntity);

        // (ECB) хранилище потокобезопасных команд :
        // Create, Destroy, SetComponent, AddComponent, RemoveComponent
        // Собирает все команды в очередь и запускает через команду PlayBack
        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

        if (spawnerComponent.ValueRO.nextSpawnTime < SystemAPI.Time.ElapsedTime)
        {
            // state.EntityManager.CreateEntity() не работает с BurstCompiler
            // поэтому используем ECB.Instatiate
            Entity newEntity = ecb.Instantiate(spawnerComponent.ValueRO.prefab);
            float3 newMoveDirection = Random.CreateFromIndex((uint)(SystemAPI.Time.ElapsedTime / SystemAPI.Time.DeltaTime)).NextFloat3(); 
            CubeComponent cubeComponent = new CubeComponent{moveDirection = newMoveDirection, moveSpeed = 5};
            RotateSpeedComponent rotateComponent = new RotateSpeedComponent{value = 2};
            
            ecb.AddComponent(newEntity, cubeComponent);
            ecb.AddComponent(newEntity, rotateComponent);

            spawnerComponent.ValueRW.nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawnerComponent.ValueRO.spawnRate;
            
            ecb.Playback(state.EntityManager);
        }
    }
}