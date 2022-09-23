using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrowController : ControllerModel
{
    [SerializeField] PoolModel directionArrowPool;
    [SerializeField] float spawnInterval;
    [SerializeField] float maxSpawnTime;
    [SerializeField] Transform spawnPos;
    [SerializeField] int directionArrowCount;
    [SerializeField] PhotoController photoController;
    [SerializeField] LevelModel activeLevel;
    int levelDataIndex = 0;

    public override void Initialize()
    {
        base.Initialize();
        activeLevel = LevelController.Controller.LoadedLevel;
    }

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            directionControllerUpdate();
        }
    }

    public void DecreaseArrowCount()
    {
        if (directionArrowCount > 0)
        {
            directionArrowCount--;
            if (directionArrowCount == 0)
            {
                ScreenController.Instance.ShowScreen(2);
                GameStateController.Instance.ChangeState(GameStates.End);
                photoController.OnEnd();
            }
        }
    }

    private void directionControllerUpdate()
    {
        if (directionArrowCount > 0)
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
    }

    private void spawnDirectionArrow()
    {
        DirectionModel dirModel = directionArrowPool.GetDeactiveItem<DirectionModel>();
        dirModel.OnSpawn(spawnPos);
        dirModel.SetDirection(activeLevel.LevelDatas[levelDataIndex]);
        levelDataIndex++;
    }

    //Change this to level data.
    private SwipeDirections getRandomDir()
    {
        SwipeDirections dir = (SwipeDirections)Random.Range(0, 4);
        return dir;
    }
}