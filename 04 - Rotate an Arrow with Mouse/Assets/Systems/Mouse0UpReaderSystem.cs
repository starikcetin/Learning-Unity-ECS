using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class Mouse0UpReaderSystem : ComponentSystem
    {
        private struct Group
        {
            public int Length;
            [ReadOnly] public ComponentDataArray<Mouse0DownComponent> Mouse0DownComponents;
            public EntityArray Entities;
        }

        [Inject] private Group _group;
        [Inject] private EntityManager _entityManager;

        protected override void OnUpdate()
        {
            if (Input.GetMouseButtonUp(0))
            {
                for (var i = 0; i < _group.Length; i++)
                {
                    _entityManager.DestroyEntity(_group.Entities[i]);
                }
            }
        }
    }
}
