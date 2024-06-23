using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    
    private float moveTimer;
    private float losePlayerTimer;
    private float attackTimer;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
       if (enemy.CanSeePlayer()) //player can be seen
        {
            //lock to lose player timer and increment the move and attack timer
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            attackTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            //if attack timer > attack rate
            if(attackTimer > enemy.attackRate) 
            {
                Attack();
            }
            //move the enemy to a random position after a random time
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else //lost sight of the player
        {
            losePlayerTimer -= Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                //change to the search state
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public void Attack()
    {
        Debug.Log("Attack");
        attackTimer = 0;
    }
}