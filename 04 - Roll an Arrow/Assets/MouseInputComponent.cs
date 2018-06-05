using Unity.Entities;

public struct MouseInputComponent : IComponentData
{
    public readonly float X;
    public readonly float Y;
    public readonly BlittableBool Button0Down;

    public MouseInputComponent(float x, float y, BlittableBool button0Down)
    {
        X = x;
        Y = y;
        Button0Down = button0Down;
    }
}
