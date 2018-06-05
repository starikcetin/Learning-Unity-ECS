using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public static class Bootstrap
{
    private static EntityManager _entityManager;
    private static MeshInstanceRendererComponent _arrowRenderer;
    private static EntityArchetype _arrowArchetype;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void BeforeSceneLoad()
    {
        _entityManager = World.Active.GetOrCreateManager<EntityManager>();

        _arrowArchetype = _entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(Rotation),
            typeof(MeshInstanceRenderer),

            typeof(MouseInputComponent)
        );
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void AfterSceneLoad()
    {
        _arrowRenderer = Object.FindObjectOfType<MeshInstanceRendererComponent>();

        var arrow = _entityManager.CreateEntity(_arrowArchetype);

        _entityManager.SetComponentData(arrow, new Position(new float3(0,0,0)));
        _entityManager.SetComponentData(arrow, new Rotation(quaternion.identity));

        _entityManager.SetSharedComponentData(arrow, _arrowRenderer.Value);
    }

}
