using Unity.Entities;
using UnityEngine;

public class LevelUpSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref LevelComponent levelComponent) =>
        {
            levelComponent.Level += Time.deltaTime;
            Debug.Log(levelComponent.Level);
        });
    }
}
