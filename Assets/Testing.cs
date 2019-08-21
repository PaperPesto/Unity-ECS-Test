using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Mesh Mesh;
    [SerializeField] private Material Material;
    private void Start()
    {
        EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent),
            typeof(Position),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(MoveSpeedComponent)
        );

        //Entity entity = manager.CreateEntity(typeof(LevelComponent));
        //Entity entity = manager.CreateEntity(entityArchetype);
        NativeArray<Entity> entityArray = new NativeArray<Entity>(10, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        //manager.SetComponentData(entity, new LevelComponent { Level = 10 });
        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new LevelComponent { Level = Random.Range(10, 20) });
            entityManager.SetComponentData(entity, new Position { Value = new Unity.Mathematics.float3(Random.Range(-8, 8f), Random.Range(-5, 5f), 0) });
            entityManager.SetComponentData(entity, new MoveSpeedComponent { Speed = Random.Range(1f, 10f) });

            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = Mesh,
                material = Material
            });
        }

        entityArray.Dispose();

        Debug.Log("Fine start");
    }
}
