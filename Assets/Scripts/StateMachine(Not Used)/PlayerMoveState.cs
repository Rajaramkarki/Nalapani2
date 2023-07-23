//using UnityEngine;

//public class PlayerMoveState : PlayerBaseState
//{
//    //parameter for MoveSpeed and MoveBlendTree 
//    //creates a numerical value from the string
//    private readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
//    private readonly int MoveBlendTreeHash = Animator.StringToHash("MoveBlendTree");

//    private const float AnimationDampTime = 0.1f;
//    private const float CrossFadeDuration = 0.1f;

//    //constructor
//    //passes to the parent constructor - PlayerBaseState
//    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

//    public override void Enter()
//    {

//        //while moving, we want the player to be constantly pulled downward. 
//        stateMachine.Velocity.y = Physics.gravity.y;

//        //for smooth transition
//        stateMachine.Animator.CrossFadeInFixedTime(MoveBlendTreeHash, CrossFadeDuration);

//        //Jump 
//        stateMachine.InputReader.OnJumpPerformed += SwitchtoJumpState;

//        //attack removed to another script
//        //stateMachine.InputReader.OnAttackPerformed = SwitchtoAttackState;
//    }

//    public override void Tick()
//    {

//        if(!stateMachine.Controller.isGrounded)
//        {
//            stateMachine.SwitchState(new PlayerJumpState(stateMachine));
//        }

//        //calls all these functions from PlayerBaseState     
//        CalculateMoveDirection();
//        FaceMoveDirection();
//        if (!stateMachine.IsAttacking)
//        {
//            Move();
//        }


//        //MoveSpeed is set to either 0 or 1
//        //MoveComposite taken from the InputReader
//        //AnimationDampTime and Time.deltaTime to make the transition and animation smooth
//        stateMachine.Animator.SetFloat(MoveSpeedHash, stateMachine.InputReader.MoveComposite.sqrMagnitude > 0f ? 1f : 0f, AnimationDampTime, Time.deltaTime);
//    }

//    public override void Exit() 
//    {
//        stateMachine.InputReader.OnJumpPerformed -= SwitchtoJumpState;
//        //stateMachine.InputReader.OnAttackPerformed -= SwitchtoAttackState;

//    }

//    private void SwitchtoJumpState()
//    {
//        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
//    }

//    //private void SwitchtoAttackState()
//    //{
//    //    stateMachine.SwitchState(new PlayerAttackState(stateMachine));
//    //}
//}