using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class LerpHeadingTowardsHeadingTargetJobSystem : JobComponentSystem
{
    [ComputeJobOptimization]
    private struct HeadingTargetHeading : IJobProcessComponentData<HeadingTarget, Heading>
    {
        public void Execute([ReadOnly] ref HeadingTarget headingTarget, ref Heading heading)
        {
            heading.Value = math.lerp(heading.Value, headingTarget.Value, 0.01f);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new HeadingTargetHeading();
        return job.Schedule(this, 64, inputDeps);
    }
}
