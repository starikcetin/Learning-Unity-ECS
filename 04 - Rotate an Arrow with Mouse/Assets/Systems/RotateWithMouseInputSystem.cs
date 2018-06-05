using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class RotateWithMouseInputSystem : ComponentSystem
{
    private struct RotateTargetGroup
    {
        public int Length;
        [ReadOnly] public ComponentDataArray<RotateWithMouseInputComponent> RotateWithMouseInputs;
        [ReadOnly] public ComponentDataArray<MouseInputComponent> MouseInputs;
        public ComponentDataArray<Rotation> Rotations;
    }

    private struct Mouse0DownGroup
    {
        public int Length;
        [ReadOnly] public ComponentDataArray<Mouse0DownComponent> Mouse0DownComponents;
    }

    [Inject] private RotateTargetGroup _rotateTargetGroup;
    [Inject] private Mouse0DownGroup _mouse0DownGroup;

    protected override void OnUpdate()
    {
        if (_mouse0DownGroup.Length > 0)
        {
            for (var i = 0; i < _rotateTargetGroup.Length; i++)
            {
                var mouseInput = _rotateTargetGroup.MouseInputs[i];

                var currentRotation = _rotateTargetGroup.Rotations[i].Value;

                var deltaRotX = math.axisAngle(new float3(1, 0, 0), mouseInput.Y / 5);
                var deltaRotY = math.axisAngle(new float3(0, 1, 0), -mouseInput.X / 5);
                var newRot = math.mul(math.mul(deltaRotY, deltaRotX), currentRotation);

                _rotateTargetGroup.Rotations[i] = new Rotation(newRot);
            }
        }
    }
}
