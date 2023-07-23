//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerAttackState : PlayerBaseState
//{
//    private readonly int AttackHash = Animator.StringToHash("Attack");
//    private const float CrossFadeDuration = 0.1f;
//    private bool hasAttacked = false;

//    public PlayerAttackState(PlayerStateMachine statemachine) : base(statemachine) { }

//    public override void Enter()
//    {
//        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, CrossFadeDuration);
//        hasAttacked = false;
//        stateMachine.IsAttacking = true;
//    }

//    public void OnAnimationFinished()
//    {
//        stateMachine.IsAttacking = false;
//        stateMachine.SwitchState(new PlayerMoveState(stateMachine));
//    }

//    public override void Tick()
//    {
//        ApplyGravity();

//        if (!stateMachine.IsAttacking)
//        {
//            Move();
//        }
//    }

//    public override void Exit() { }
//}
