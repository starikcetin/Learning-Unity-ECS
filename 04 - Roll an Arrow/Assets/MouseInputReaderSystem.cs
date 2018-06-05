using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class MouseInputReaderSystem : ComponentSystem
{
    private struct Group
    {
        public int Length;
        [WriteOnly] public ComponentDataArray<MouseInputComponent> MouseInputComponents;
    }

    [Inject] private Group _group;


    protected override void OnUpdate()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        var button0Down = Input.GetMouseButton(0);

        for (var i = 0; i < _group.Length; i++)
        {
            _group.MouseInputComponents[i] = new MouseInputComponent(x, y, button0Down);
        }
    }
}
