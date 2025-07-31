using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleStateBehaviour : StateMachineBehaviour
{
	private static readonly int isInvincibleHash = Animator.StringToHash("isInvincible");

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool(isInvincibleHash, true);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool(isInvincibleHash, false);
	}
}

