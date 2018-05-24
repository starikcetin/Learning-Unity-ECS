using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public static class Bootstrap
{
    private static EntityManager _entityManager;
    private static MeshInstanceRenderer _arrowRenderer;
    private static EntityArchetype _arrowArchetype;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        _entityManager = World.Active.GetOrCreateManager<EntityManager>();

        _arrowArchetype = _entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(Heading),
            typeof(MoveSpeed),
            typeof(MoveForward)
        );
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeWithScene()
    {
        _arrowRenderer = GameObject.FindObjectOfType<MeshInstanceRendererComponent>().Value;

        CreateArrowsWithRandomHeadings(count: 10);
    }

    private static void CreateArrowsWithRandomHeadings(int count)
    {
        for (var i = 0; i < count; i++)
        {
            CreateArrow(heading: Random.onUnitSphere);
        }
    }

    private static void CreateArrow(float3 heading)
    {
        var arrow = _entityManager.CreateEntity(_arrowArchetype);

        _entityManager.SetComponentData(arrow, new Position {Value = new float3(0, 0, 0)});
        _entityManager.SetComponentData(arrow, new Heading {Value = heading});
        _entityManager.SetComponentData(arrow, new MoveSpeed {speed = 1});

        _entityManager.AddSharedComponentData(arrow, _arrowRenderer);
    }
}
