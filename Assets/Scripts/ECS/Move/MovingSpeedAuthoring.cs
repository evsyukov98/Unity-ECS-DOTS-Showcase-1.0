using Unity.Entities;
using UnityEngine;

// Прокладка для создания "ECS - Component". Так пока в движке нет способа накидывать не МоноБехи в обьекты.
public class MovingSpeedAuthoring : MonoBehaviour                     
{
    public float value;
}

// Класс для прикрепления "Component" в "Entity". (Автоматически запускается при запуске игры)
public class MovingSpeedBaker : Baker<MovingSpeedAuthoring>
{
    public override void Bake(MovingSpeedAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);                     // Берем "Entity"
        MovingSpeedComponent component = new MovingSpeedComponent(authoring.value); // Берем "Component"
        
        AddComponent(entity, component);                                            // Прикрепляем сущность к компоненту
    }
}