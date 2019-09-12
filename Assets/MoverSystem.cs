using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation position, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            position.Value.y += moveSpeedComponent.Speed * Time.deltaTime;

            if (position.Value.y > 5f)
            {
                moveSpeedComponent.Speed = -Mathf.Abs(moveSpeedComponent.Speed);
            }

            if (position.Value.y < -5f)
            {
                moveSpeedComponent.Speed = +Mathf.Abs(moveSpeedComponent.Speed);
            }
        }
    );
    }
}
