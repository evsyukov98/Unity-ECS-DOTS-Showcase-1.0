using Unity.Entities;
using UnityEngine;

// Прокладка для создания "ECS - Component". Так пока в движке нет способа накидывать не МоноБехи в обьекты.
public class SpeedAuthoring : MonoBehaviour                     
{
    public float value;
}

// Наш "ECS - Component"
public struct SpeedComponent : IComponentData                          
{
    public float value;

    public SpeedComponent(float value)
    {
        this.value = value;
    }
}

// Класс для прикрепления "Component" в "Entity"
public class SpeedBaker : Baker<SpeedAuthoring>
{
    public override void Bake(SpeedAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);                 // Берем "Entity"
        SpeedComponent component = new SpeedComponent(authoring.value);         // Берем "Component"
        
        AddComponent(entity, component);                                        // Прикрепляем сущность к компоненту
    }
}