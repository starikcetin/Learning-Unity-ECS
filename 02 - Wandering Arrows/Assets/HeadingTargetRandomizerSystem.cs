using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class HeadingTargetRandomizerSystem : ComponentSystem
{
    private struct Group
    {
        [ReadOnly] public ComponentDataArray<RandomizeHeadingTarget> RandomizeHeadings;
        [WriteOnly] public ComponentDataArray<HeadingTarget> HeadingTargets;
        public EntityArray Entities;
        public int Length;
    }

    [Inject] private Group _group;

    protected override void OnUpdate()
    {
        for (var i = 0; i < _group.Length; i++)
        {
            var entity = _group.Entities[i];
            PostUpdateCommands.SetComponent(entity, new HeadingTarget {Value = Random.onUnitSphere});
        }
    }
}
