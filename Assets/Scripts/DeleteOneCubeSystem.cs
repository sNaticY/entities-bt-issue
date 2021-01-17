using Unity.Core;
using Unity.Entities;
using UnityEngine;

public class DeleteOneCubeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var elapsedTime = Time.ElapsedTime;
        Entities.WithAll<DestroyTag>().ForEach((Entity entity) =>
        {
            if(elapsedTime > 3)
                EntityManager.DestroyEntity(entity);
            
        }).WithStructuralChanges().Run();
    }
}
