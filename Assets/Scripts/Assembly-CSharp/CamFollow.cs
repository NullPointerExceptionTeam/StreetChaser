using UnityEngine;

public class CamFollow
{
	public Transform camTarget;

	public float CamdistFrmTarget;

	public float CamheightFrmGround;

	public float heightToAddinLookAt;

	public GameObject _Go_CamIntro;

	public Vector3 CamCurPos;

	public IGT_Hero pHero;

	private Vector3[] NeededPos;

	private Vector3 tempLookat;

	private float lookAtTotDistFrmTarget;

	private bool bMovingBtwPaths;

	public Vector3 camPrevDir_Lookat;

	public Vector3 camPrevDir_Pos;

	public Quaternion currentRotation;

	public float fAngleNeedtoRotate;

	public float fAvgAngleToRotate;

	public float fCamAvgFluct;

	public Vector3 mCamPrevPos;

	public IGT_Animator pAnim;

	public void initCamFollow()
	{
		camTarget = GameObject.FindGameObjectWithTag("Player").transform;
		pHero = camTarget.GetComponent<IGT_Hero>();
		_Go_CamIntro = new GameObject();
		_Go_CamIntro.name = IGT_Constants.CamIntroTarget;
		_Go_CamIntro.AddComponent<GameIntro>();
		lookAtTotDistFrmTarget = 3f;
		CamdistFrmTarget = 1f;
		CamheightFrmGround = 0.45f;
		heightToAddinLookAt = 0.3f;
		bMovingBtwPaths = false;
		camPrevDir_Lookat = new Vector3(camTarget.position.x - Camera.main.transform.position.x, camTarget.position.y - Camera.main.transform.position.y, camTarget.position.z - Camera.main.transform.position.z);
		camPrevDir_Lookat.Normalize();
		NeededPos = new Vector3[6];
		currentRotation = Quaternion.Euler(0f, Mathf.LerpAngle(Camera.main.transform.eulerAngles.y, camTarget.eulerAngles.y, 0.75f), 0f);
		mCamPrevPos = Camera.main.transform.position;
		fAvgAngleToRotate = (fAngleNeedtoRotate = 0f);
		fCamAvgFluct = 0f;
		pAnim = new IGT_Animator();
	}

	public void _LateUpdate()
	{
		if (GameIntro.bIntroOver && IGT_Hero.bStrtButton && IGT_Hero.bRobbingSceneFinished)
		{
			if (!camTarget || IGT_Hero.bPauseButton || (IGT_Hero.bGameOver && IGT_AnimStatesCntrler.nHeroAnimState != 8 && !IGT_Hero.bLevelUp))
			{
				return;
			}
			currentRotation = Quaternion.Euler(0f, Mathf.LerpAngle(Camera.main.transform.eulerAngles.y, camTarget.eulerAngles.y, 0.1f), 0f);
			CamCurPos = camTarget.position - currentRotation * Vector3.forward * CamdistFrmTarget;
			CamCurPos = CamCurPos * 0.8f + mCamPrevPos * 0.2f;
			Camera.main.transform.position = new Vector3(CamCurPos.x, camTarget.position.y + CamheightFrmGround + IGT_Constants.fDist_GroundTo_HeroHead * 0.75f, CamCurPos.z);
			mCamPrevPos = CamCurPos;
			tempLookat = camTarget.position;
			float num = Vector3.Distance(CamCurPos, tempLookat);
			Vector3 vector = CamCurPos + camPrevDir_Lookat * num;
			tempLookat = vector * 0.05f + tempLookat * 0.95f;
			Camera.main.transform.LookAt(new Vector3(tempLookat.x, tempLookat.y + heightToAddinLookAt + IGT_Constants.fDist_GroundTo_HeroHead, tempLookat.z));
			camPrevDir_Lookat = new Vector3(tempLookat.x - CamCurPos.x, tempLookat.y - CamCurPos.y, tempLookat.z - CamCurPos.z);
			camPrevDir_Lookat.Normalize();
			fAngleNeedtoRotate = 0f;
			if ((double)pHero.PlayerObj.fDistFrmStrtPnt > (double)CamdistFrmTarget + 1.25 && pHero.PlayerObj.pathLength[pHero.PlayerObj.currentPathIndex] - pHero.PlayerObj.fDistFrmStrtPnt > lookAtTotDistFrmTarget)
			{
				NeededPos = pHero.PlayerObj.findPos_FrmGivenDatas(pHero.PlayerObj.currentPathIndex, pHero.PlayerObj.currentPoint, pHero.fDistBw2Points + lookAtTotDistFrmTarget, pHero.PlayerObj.bTraverseReverse, ref bMovingBtwPaths);
				Vector3 rhs = new Vector3(NeededPos[0].x - NeededPos[1].x, NeededPos[0].y - NeededPos[1].y, NeededPos[0].z - NeededPos[1].z);
				rhs.Normalize();
				Vector3 vector2 = Vector3.Cross(Vector3.up, rhs);
				tempLookat = pHero.PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], Vector3.Distance(NeededPos[0], NeededPos[2])) + vector2 * pHero.offset_Laneoffset;
				Vector3 vector3 = Vector3.ProjectOnPlane(CamCurPos, Vector3.up);
				Vector3 vector4 = Vector3.ProjectOnPlane(camTarget.transform.position, Vector3.up);
				Vector3 vector5 = Vector3.ProjectOnPlane(tempLookat, Vector3.up);
				Vector3 vector6 = vector4 - vector3;
				vector6.Normalize();
				Vector3 vector7 = vector5 - vector3;
				vector7.Normalize();
				fAngleNeedtoRotate = Vector3.Angle(vector6, vector7);
				Vector3 vector8 = Vector3.Cross(vector6, vector7);
				float num2 = Vector3.Angle(vector8, Vector3.up);
				if (num2 >= 90f)
				{
					fAngleNeedtoRotate = 0f - fAngleNeedtoRotate;
				}
			}
			if (fAngleNeedtoRotate - fAvgAngleToRotate > 3f)
			{
				fAngleNeedtoRotate = fAvgAngleToRotate + 3f;
			}
			fAvgAngleToRotate = fAvgAngleToRotate * 0.96f + fAngleNeedtoRotate * 0.04f;
			Camera.main.transform.Rotate(Vector3.up, fAvgAngleToRotate);
		}
		else
		{
			if (!_Go_CamIntro)
			{
				return;
			}
			Camera.main.transform.position = _Go_CamIntro.transform.position;
			Camera.main.transform.position -= Vector3.forward * CamdistFrmTarget;
			if (!IGT_Hero.bCamStartFollow)
			{
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0.6f, Camera.main.transform.position.z);
				Camera.main.transform.LookAt(new Vector3(pHero.PlayerObj.pointPos[25, 1, 0], 0.65f, pHero.PlayerObj.pointPos[25, 1, 2]));
			}
			else
			{
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, IGT_EaseFunction.Linear_ease(IGT_Hero.fTime_CamJoint, 0.6f, 0.8f, 0.5f), Camera.main.transform.position.z);
				Camera.main.transform.LookAt(new Vector3(pHero.PlayerObj.pointPos[25, 1, 0], IGT_EaseFunction.Linear_ease(IGT_Hero.fTime_CamJoint, 0.65f, 0.75f, 0.5f), pHero.PlayerObj.pointPos[25, 1, 2]));
				IGT_Hero.fTime_CamJoint += Time.deltaTime;
				if (IGT_Hero.fTime_CamJoint > 0.5f)
				{
					IGT_Hero.fTime_CamJoint = 0.5f;
				}
			}
			mCamPrevPos = Camera.main.transform.position;
			camPrevDir_Lookat = new Vector3(0f, 0f, 1f);
		}
	}
}
