using Unity.Entities;
using UnityEngine;

public class Mouse0DownReaderSystem : ComponentSystem
{
    [Inject] private EntityManager _entityManager;

    protected override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var entity = _entityManager.CreateEntity(typeof(Mouse0DownComponent));
        }
    }
}
