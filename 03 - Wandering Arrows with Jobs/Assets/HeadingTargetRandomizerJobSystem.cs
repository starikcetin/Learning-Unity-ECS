using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class HeadingTargetRandomizerJobSystem : JobComponentSystem
{
    private struct PFST : IJobParallelFor
    {
        public float t;
        [WriteOnly] public ComponentDataArray<HeadingTarget> HeadingTargets;

        public void Execute(int index)
        {
            var noise = Unity.Mathematics.noise.srdnoise(new float2(t, index));
            var noiseNormalized = math.normalize(noise);

            HeadingTargets[index] = new HeadingTarget {Value = noiseNormalized};
        }
    }

    private struct Group
    {
        public int Length;
        [ReadOnly] public ComponentDataArray<RandomizeHeadingTarget> RandomizeHeadingTargets;
        [WriteOnly] public ComponentDataArray<HeadingTarget> HeadingTargets;
    }

    [Inject] private Group _group;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PFST {t = Time.time, HeadingTargets = _group.HeadingTargets};
        return job.Schedule(_group.Length, 64, inputDeps);
    }
}
