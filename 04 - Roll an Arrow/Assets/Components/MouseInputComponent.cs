using Unity.Entities;

public struct MouseInputComponent : IComponentData
{
    public readonly float X;
    public readonly float Y;

    public MouseInputComponent(float x, float y)
    {
        X = x;
        Y = y;
    }
}
