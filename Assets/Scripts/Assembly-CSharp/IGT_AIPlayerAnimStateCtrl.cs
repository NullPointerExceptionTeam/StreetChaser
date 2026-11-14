using UnityEngine;

public class IGT_AIPlayerAnimStateCtrl : MonoBehaviour
{
	public Animator AIHeroAnimator;

	public int nHeroAnimState;

	private void Update()
	{
		if (AIHeroAnimator != null)
		{
			AIHeroAnimator.SetInteger("AnimState", nHeroAnimState);
		}
		else
		{
			Debug.Log("animator null ");
		}
	}

	public void EndOfAnimCheck(int val)
	{
		switch (val)
		{
		case 1:
			IGT_AnimStatesCntrler.nGameOverAnimFinshd = val;
			break;
		case 2:
			if (!IGT_AIPlayer.bUTurnAnimationPlaying)
			{
				nHeroAnimState = 1;
			}
			break;
		case 4:
			nHeroAnimState = 1;
			IGT_Hero.bBagMovingInCurve = false;
			break;
		case 5:
			nHeroAnimState = 1;
			AIHeroAnimator.Play("Running", 0);
			IGT_AIPlayer.bUTurnAnimationPlaying = false;
			IGT_AIPlayer.bAttacked = true;
			IGT_AIPlayer.dAttackedStartTime = Time.time;
			IGT_AIPlayer.AI_PlayerObj.speed = IGT_AIPlayer.pHero.PlayerObj.speed;
			break;
		case 6:
			IGT_AnimStatesCntrler.nGameOverAnimFinshd = val;
			break;
		case 24:
			IGT_Hero.bBagInHeroinHand = true;
			IGT_GameView.pHero.Heroine.GetComponent<Animator>().SetInteger("GirlState", 14);
			break;
		case 25:
			IGT_Hero.bAIplayerStart = true;
			IGT_Hero.fTime_robbScene = 0f;
			IGT_Hero.fTime_CamJoint = 0f;
			nHeroAnimState = 1;
			break;
		}
	}
}
