using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyPathfindingMovement : MonoBehaviour
{
    /*
    private const float speed = 30f;

    private EnemyMain enemyMain;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float pathfindingTimer;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Start()
    {
        enemyMain = GetComponent<EnemyMain>();


    }

    private void Update()
    {
        pathfindingTimer -= Time.deltaTime;

        HandleMovement();
    }

    private void FixedUpdate()
    {
        enemyMain.EnemyRigidbody.velocity = moveDir * speed;
    }

    private void HandleMovement()
    {
        PrintPathfindingPath();
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            float reachedTargetDistance = 5f;
            if (Vector3.Distance(GetPosition(), targetPosition) > reachedTargetDistance)
            {
                moveDir = (targetPosition - GetPosition()).normalized;
                lastMoveDir = moveDir;
                enemyMain.CharacterAnims.PlayMoveAnim(moveDir);

            }
        }
    }
    */

}
