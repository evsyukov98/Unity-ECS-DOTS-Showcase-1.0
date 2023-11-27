using Unity.Entities;

// Наш "ECS - Component"
public struct RotateSpeedComponent : IComponentData                          
{
    public float value;

    public RotateSpeedComponent(float value)
    {
        this.value = value;
    }
}