using Unity.Entities;

// Наш "ECS - Component"
public struct MovingSpeedComponent : IComponentData
{
    public float value;
    
    public MovingSpeedComponent(float value)
    {
        this.value = value;
    }
}