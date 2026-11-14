using System.Linq;
using UnityEngine;

public class IGT_AnimStatesCntrler : MonoBehaviour
{
	public static Animator HeroAnimator;

	public static float feetPos;

	public static float HeadPos;

	public static int nHeroAnimState;

	private float fRunnigFeetPos;

	private float fRunningHeadPos;

	private float fJumpFeetPos;

	private float fSlideFeetPos;

	private float fSlideHeadpos;

	private float fJumpNormalizeTime;

	private float fSlideNormalizeTime;

	private float fAnimNormStrtTime;

	public static float fjmpFeetPosFrPit;

	private float fJumpIncreseFactor;

	private float fslideIncreseFactor;

	public static bool bAnimstrtNorTime;

	public static int nGameOverAnimFinshd;

	public static float fKickAnimFulLen = 0.92f;

	public static float fkickAnimHitLen = 0.72f;

	public static float fkickEnableAnimatorSpd;

	public static double objFlyTrueTime;

	public static double objMovTrueTime;

	public static double dThrowObjTrueTime;

	public static double dThrowObjMovTrueTime;

	public static float fKickThrowObjDuration = 1f;

	private IGT_Hero pHero;

	private void Start()
	{
		pHero = GameObject.FindGameObjectWithTag("Player").GetComponent<IGT_Hero>();
		HeroAnimator = pHero.player.GetComponent<Animator>();
		fjmpFeetPosFrPit = pHero.player.transform.position.y;
		fJumpNormalizeTime = 0.464f;
		fSlideNormalizeTime = 0.526f;
		fJumpIncreseFactor = (pHero.player.transform.position.y + IGT_Constants.HeroHeight) / (fJumpNormalizeTime / 2f) / 100f;
		fslideIncreseFactor = (pHero.player.transform.position.y + IGT_Constants.HeroHeight / 4f) / (fSlideNormalizeTime / 2f) / 100f;
		fAnimNormStrtTime = 0.3f;
		bAnimstrtNorTime = false;
		nGameOverAnimFinshd = 0;
	}

	private void FixedUpdate()
	{
		fJumpIncreseFactor = (pHero.player.transform.position.y + IGT_Constants.HeroHeight) / (fJumpNormalizeTime / 2f) / 100f;
		fslideIncreseFactor = (pHero.player.transform.position.y + IGT_Constants.HeroHeight / 4f) / (fSlideNormalizeTime / 2f) / 100f;
		if (IGT_Hero.bkickObjFly && (double)Time.timeSinceLevelLoad - objFlyTrueTime > (double)fKickThrowObjDuration)
		{
			if (IGT_Objects.kickObj_InstanceID != -1 && IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.kickObj_InstanceID).GetComponent<Rigidbody>() != null)
			{
				IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.kickObj_InstanceID).GetComponent<Rigidbody>().isKinematic = true;
				IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.kickObj_InstanceID).GetComponent<Rigidbody>().freezeRotation = true;
			}
			IGT_Hero.bkickObjFly = false;
			IGT_Hero.bKickobjCanMove = true;
		}
		else if (IGT_Hero.bKickObjMoving && (double)Time.timeSinceLevelLoad - objMovTrueTime > (double)fKickThrowObjDuration)
		{
			if (IGT_Objects.kickObj_InstanceID != -1 && IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.kickObj_InstanceID).GetComponent<Rigidbody>() != null)
			{
				IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.kickObj_InstanceID).GetComponent<Rigidbody>().isKinematic = true;
				IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.kickObj_InstanceID).GetComponent<Rigidbody>().freezeRotation = true;
			}
			IGT_Hero.bKickObjMoving = false;
			IGT_Hero.bKickobjCanMove = true;
		}
		if (IGT_Hero.bThrowObjMoving && (double)Time.timeSinceLevelLoad - dThrowObjMovTrueTime > (double)fKickThrowObjDuration)
		{
			IGT_Hero.bThrowObjMoving = false;
		}
		else if (IGT_Hero.bPickdObjCanThrow && (double)Time.timeSinceLevelLoad - dThrowObjTrueTime > (double)fKickThrowObjDuration)
		{
			IGT_Hero.bPickdObjCanThrow = false;
			IGT_Objects.PickedObj_InstanceID = -1;
			IGT_Objects.ThrowObj_Placed_Pos = Vector3.zero;
		}
	}

	private void Update()
	{
		if (!IGT_Hero.bGameOver && !IGT_Hero.bPauseButton)
		{
			if (HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
			{
				feetPos = pHero.player.transform.position.y;
				HeadPos = pHero.player.transform.position.y + IGT_Constants.HeroHeight;
				fjmpFeetPosFrPit = pHero.player.transform.position.y;
			}
			else if (HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !HeroAnimator.IsInTransition(0))
			{
				if (!bAnimstrtNorTime)
				{
					fAnimNormStrtTime = HeroAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
					bAnimstrtNorTime = true;
				}
				fjmpFeetPosFrPit = pHero.player.transform.position.y + IGT_Constants.HeroHeight;
				if (HeroAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= fAnimNormStrtTime + fJumpNormalizeTime / 2f)
				{
					feetPos += fJumpIncreseFactor * 4f;
					HeadPos += fJumpIncreseFactor * 4f;
				}
				else
				{
					feetPos -= fJumpIncreseFactor * 6f;
					HeadPos -= fJumpIncreseFactor * 6f;
				}
			}
			else if (HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sliding"))
			{
				if (!bAnimstrtNorTime)
				{
					fAnimNormStrtTime = HeroAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
					bAnimstrtNorTime = true;
				}
				feetPos = pHero.player.transform.position.y;
				fjmpFeetPosFrPit = pHero.player.transform.position.y;
				if (HeroAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= fAnimNormStrtTime + fSlideNormalizeTime / 2f)
				{
					if (HeadPos >= pHero.player.transform.position.y + IGT_Constants.HeroHeight)
					{
						HeadPos = pHero.player.transform.position.y + IGT_Constants.HeroHeight;
					}
					HeadPos -= fslideIncreseFactor * 5f;
				}
				else
				{
					HeadPos += fslideIncreseFactor * 6f;
					if (HeadPos >= pHero.player.transform.position.y + IGT_Constants.HeroHeight)
					{
						HeadPos = pHero.player.transform.position.y + IGT_Constants.HeroHeight;
					}
				}
			}
		}
		HeroAnimator.SetInteger("AnimState", nHeroAnimState);
	}

	public void EndOfAnimCheck(int val)
	{
		switch (val)
		{
		case 1:
			nGameOverAnimFinshd = val;
			break;
		case 2:
			IGT_Hero.nUserInput = 0;
			if (IGT_GameView.nScreenMode == 0)
			{
				HeroAnimator.Play("Idle", 0);
				nHeroAnimState = 0;
			}
			else if (!IGT_Hero.bGameOver)
			{
				nHeroAnimState = 1;
			}
			break;
		case 3:
			pHero.Throw_pickedObjects();
			IGT_Hero.bThrwObjPicked = false;
			IGT_Hero.nUserInput = 0;
			if (IGT_GameView.nScreenMode == 0)
			{
				HeroAnimator.Play("Idle", 0);
				nHeroAnimState = 0;
				Debug.Log(" idle aniam ");
			}
			else if (!IGT_Hero.bGameOver)
			{
				nHeroAnimState = 1;
			}
			break;
		case 5:
			nHeroAnimState = 18;
			pHero.PlayerObj.speed = 2f;
			IGT_AIPlayer.AI_PlayerObj.speed = 2.85f;
			pHero.playSound(5, 0.1f);
			pHero.Game_LevelUp();
			break;
		case 49:
			HeroAnimator.Play("RunBlend", 0);
			break;
		case 50:
			pHero.playSound(27);
			break;
		}
	}
}
