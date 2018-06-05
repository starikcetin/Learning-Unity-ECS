using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class RotateWithMouseInputSystem : ComponentSystem
{
    private struct Group
    {
        public int Length;
        [ReadOnly] public ComponentDataArray<RotateWithMouseInputComponent> RotateWithMouseInputs;
        [ReadOnly] public ComponentDataArray<MouseInputComponent> MouseInputs;
        public ComponentDataArray<Rotation> Rotations;
    }

    [Inject] private Group _group;

    protected override void OnUpdate()
    {
        for (var i = 0; i < _group.Length; i++)
        {
            var mouseInput = _group.MouseInputs[i];

            if (mouseInput.Button0Down)
            {
                var currentRotation = _group.Rotations[i].Value;

                var deltaRotX = math.axisAngle(new float3(1, 0, 0), mouseInput.Y / 10);
                var deltaRotY = math.axisAngle(new float3(0, 1, 0), -mouseInput.X / 10);
                var newRot = math.mul(math.mul(deltaRotY, deltaRotX), currentRotation);

                _group.Rotations[i] = new Rotation(newRot);
            }
        }
    }
}
