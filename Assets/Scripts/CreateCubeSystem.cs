using Unity.Entities;

public class CreateCubeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, in EntityTemplateData data) =>
        {
            var cube1 = EntityManager.Instantiate(data.Value);
            EntityManager.AddComponent<DestroyTag>(cube1);

            EntityManager.Instantiate(data.Value);
            
            EntityManager.DestroyEntity(entity);

        }).WithStructuralChanges().Run();
    }
    
}
