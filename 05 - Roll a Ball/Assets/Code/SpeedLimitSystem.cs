using Unity.Entities;
using UnityEngine;

public class SpeedLimitSystem : ComponentSystem
{
    private struct Filter
    {
        public int Length;
        public ComponentArray<SpeedLimitComponent> SpeedLimits;
        public ComponentArray<Rigidbody> Rigidbodies;
    }

    [Inject] private Filter _matched;

    protected override void OnUpdate()
    {
        for (var i = 0; i < _matched.Length; i++)
        {
            var speedLimit = _matched.SpeedLimits[i].Value;
            var rigidbody = _matched.Rigidbodies[i];

            if (rigidbody.velocity.magnitude > speedLimit)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * speedLimit;
            }
        }
    }
}
