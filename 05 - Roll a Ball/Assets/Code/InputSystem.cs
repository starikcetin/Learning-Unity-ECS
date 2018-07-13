using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
    private struct Filter
    {
        public int Length;
        public ComponentArray<InputComponent> InputComponents;
    }

    [Inject] private Filter _matched;

    protected override void OnUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        for (var i = 0; i < _matched.Length; i++)
        {
            var input = _matched.InputComponents[i];
            input.Horizontal = horizontalInput;
            input.Vertical = verticalInput;
        }
    }
}
