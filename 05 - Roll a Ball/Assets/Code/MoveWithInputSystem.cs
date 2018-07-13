using Unity.Entities;
using UnityEngine;

public class MoveWithInputSystem : ComponentSystem
{
    private struct Movables
    {
        public int Length;
        public ComponentArray<MoveWithInputComponent> MoveWithInputComponents;
        public ComponentArray<InputComponent> InputComponents;
        public ComponentArray<Rigidbody> Rigidbodies;
    }

    [Inject] private Movables _matched;

    protected override void OnUpdate()
    {
        for (var i = 0; i < _matched.Length; i++)
        {
            var input = _matched.InputComponents[i];
            var rigidbody = _matched.Rigidbodies[i];

            rigidbody.AddForce(new Vector3(input.Horizontal * 5, 0, input.Vertical * 5));
        }
    }
}
