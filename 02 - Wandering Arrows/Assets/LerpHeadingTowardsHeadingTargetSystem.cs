using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class LerpHeadingTowardsHeadingTargetSystem : ComponentSystem
{
    private struct Group
    {
        [ReadOnly] public ComponentDataArray<HeadingTarget> HeadingTargets;
        public ComponentDataArray<Heading> Headings;
        public EntityArray Entities;
        public int Length;
    }

    [Inject] private Group _group;

    protected override void OnUpdate()
    {
        for (var i = 0; i < _group.Length; i++)
        {
            var entity = _group.Entities[i];
            var headingTarget = _group.HeadingTargets[i].Value;
            var heading = _group.Headings[i].Value;

            var newHeading = math.lerp(heading, headingTarget, 0.01f);

            PostUpdateCommands.SetComponent(entity, new Heading {Value = newHeading});
        }
    }
}
