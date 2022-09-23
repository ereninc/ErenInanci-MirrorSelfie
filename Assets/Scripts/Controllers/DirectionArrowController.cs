using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrowController : ControllerModel
{
    [SerializeField] PoolModel directionArrowPool;
    [SerializeField] float spawnInterval;
    [SerializeField] float maxSpawnTime;
    [SerializeField] Transform spawnPos;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            directionControllerUpdate();
        }
    }

    private void directionControllerUpdate() 
    {
        if (spawnInterval > 0)
        {
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0)
            {
                spawnDirectionArrow();
                spawnInterval = maxSpawnTime;
            }
        }
    }

    private void spawnDirectionArrow() 
    {
        DirectionModel dirModel = directionArrowPool.GetDeactiveItem<DirectionModel>();
        dirModel.OnSpawn(spawnPos);
        dirModel.SetDirection(getRandomDir());
    }

    private SwipeDirections getRandomDir() 
    {
        SwipeDirections dir = (SwipeDirections)Random.Range(0, 4);
        return dir;
    }
}