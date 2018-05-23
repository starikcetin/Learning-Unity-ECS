using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public static class Bootstrap
{
	private static EntityManager _entityManager;
	private static MeshInstanceRenderer _sphereRenderer;

	private static EntityArchetype _sphereArchetype;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Initialize()
	{
		_entityManager = World.Active.GetOrCreateManager<EntityManager>();

		_sphereArchetype = _entityManager.CreateArchetype(
			typeof(Position),
			typeof(Heading),
			typeof(TransformMatrix),
			typeof(MoveSpeed),
			typeof(MoveForward)
		);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void InitializeWithScene()
	{
		_sphereRenderer = GameObject.FindObjectOfType<MeshInstanceRendererComponent>().Value;

		SpawnSpheresWithRandomHeadings(20000);
	}

	private static void SpawnSpheresWithRandomHeadings(int count)
	{
		for (var i = 0; i < count; i++)
		{
			SpawnSphere(GetRandomHeading());
		}
	}

	private static float3 GetRandomHeading()
	{
		return Random.onUnitSphere;
	}

	private static void SpawnSphere(float3 heading)
	{
		var sphereEntity = _entityManager.CreateEntity(_sphereArchetype);

		_entityManager.SetComponentData(sphereEntity, new Position {Value = new float3(0, 0, 0)});
		_entityManager.SetComponentData(sphereEntity, new Heading {Value = heading});
		_entityManager.SetComponentData(sphereEntity, new MoveSpeed {speed = 1});

		_entityManager.AddSharedComponentData(sphereEntity, _sphereRenderer);
	}
}
