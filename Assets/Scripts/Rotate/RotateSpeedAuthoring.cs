using Unity.Entities;
using UnityEngine;

// Прокладка для создания "ECS - Component". Так пока в движке нет способа накидывать не МоноБехи в обьекты.
public class RotateSpeedAuthoring : MonoBehaviour                     
{
    public float value;
}

// Наш "ECS - Component"
public struct RotateSpeedComponent : IComponentData                          
{
    public float value;

    public RotateSpeedComponent(float value)
    {
        this.value = value;
    }
}

// Класс для прикрепления "Component" в "Entity". (Автоматически запускается при запуске игры)
public class RotateSpeedBaker : Baker<RotateSpeedAuthoring>
{
    public override void Bake(RotateSpeedAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);                     // Берем "Entity"
        RotateSpeedComponent component = new RotateSpeedComponent(authoring.value); // Берем "Component"
        
        AddComponent(entity, component);                                            // Прикрепляем сущность к компоненту
    }
}