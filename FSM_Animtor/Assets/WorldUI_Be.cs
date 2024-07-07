using UnityEngine;

public class WorldUI_Be : StateMachineBehaviour, IUI_Be
{

    //public void Enter()  {  }
    //public void Exit() { }
    //public void Update() { }

    public GameObject WorldUIObj;

    public void Init(GameObject p_uiobj)
    {
        WorldUIObj = p_uiobj;
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WorldUIObj.SetActive(true);
        // 추가적인 작업 적용하기
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 추가적인 작업 지우기
        WorldUIObj.SetActive(false);
        //animator.SetBool("World", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
