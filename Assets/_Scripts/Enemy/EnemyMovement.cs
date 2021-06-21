using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMovement
{
    GameObject thisGameObject;
    float EnemyPlayerXDifference, EnemyPlayerYDifference;
    float DualMovementDivider = 1.5f;

    float MoveSpeed;

    float timer = 0;
    List<Vector3> PlayerLastMoved = new List<Vector3>();

    public float DirectionModifierUPDown = 1;
    public float DirectionModifierLeftRight = 1;

    EnemyBrain EnemyBrain;

    public void ChasePlayer()
    {
        MoveToLocation();
        if (DistanceBetweenThisandEnemy() > 5)
        {
            CreatePath();
            FollowPlayerPath();
        }
        else
        {
            GoDirectlyAtPlayer();
            PlayerLastMoved.Clear();
        }
    }
    float DistanceBetweenThisandEnemy()
    {
        return Vector3.Distance(thisGameObject.transform.position, EnemyBrain.Target.transform.position);
    }
    void GoDirectlyAtPlayer()
    {
        GetEnemyPlayerDifference(EnemyBrain.Target.transform.position);
    }
    void CreatePath()
    {
        timer += 1 * Time.deltaTime;

        if (timer > .1f)
        {
            PlayerLastMoved.Add(EnemyBrain.Target.transform.position);
            timer = 0;
        }
    }
    void FollowPlayerPath()
    {
        if (PlayerLastMoved.Count > 0)
        { 
            if (Vector3.Distance(thisGameObject.transform.position, PlayerLastMoved[0]) < 5)
            {
                PlayerLastMoved.Remove(PlayerLastMoved[0]);
            }
            else
            {
                GetEnemyPlayerDifference(PlayerLastMoved[0]);
            }
        }
    }
    void GetEnemyPlayerDifference(Vector3 TargetPosition)
    {
        EnemyPlayerXDifference = thisGameObject.transform.position.x - TargetPosition.x;
        EnemyPlayerXDifference = Mathf.Clamp(EnemyPlayerXDifference, -1, 1);
        EnemyPlayerYDifference = thisGameObject.transform.position.y - TargetPosition.y;
        EnemyPlayerYDifference = Mathf.Clamp(EnemyPlayerYDifference, -1, 1);
    }
    void MoveToLocation()
    {
        if (DualInput())
        {
            thisGameObject.transform.position += HorizontalMovement() / DualMovementDivider;
            thisGameObject.transform.position += VerticalMovement() / DualMovementDivider;
        }
        else
        {
            thisGameObject.transform.position += HorizontalMovement();
            thisGameObject.transform.position += VerticalMovement();
        }

    }
    Vector3 HorizontalMovement() => Vector3.right * MoveSpeed  * -EnemyPlayerXDifference  * Time.deltaTime ;
    Vector3 VerticalMovement() => Vector3.up * MoveSpeed  * -EnemyPlayerYDifference  * Time.deltaTime;
    bool DualInput()
    {
        if (EnemyPlayerXDifference > 1 && EnemyPlayerYDifference > 1 || EnemyPlayerXDifference < -1 && EnemyPlayerYDifference < -1 || EnemyPlayerXDifference < -1 && EnemyPlayerYDifference > 1 || EnemyPlayerXDifference > 1 && EnemyPlayerYDifference < -1)
        {
            return true;
        }
        return false;
    }
    public bool isMovingLeft()
    {
        if (EnemyPlayerXDifference < -.3f) return true;
        return false;
    }
    public bool isMovingRight()
    {
        if (EnemyPlayerXDifference > 0.3f) return true;
        return false;
    }
    public bool isMovingUp()
    {
        if (EnemyPlayerYDifference < -0.3f) return true;
        return false;
    }
    public bool isMovingDown()
    {
        if (EnemyPlayerYDifference > 0.3f) return true;
        return false;
    }
    public EnemyMovement(GameObject Enemy, EnemyBrain EnemyBrain, float MoveSpeed)
    {
        this.thisGameObject = Enemy;
        this.EnemyBrain = EnemyBrain;
        this.MoveSpeed = MoveSpeed;
    }
}
