using UnityEngine;

public class IGT_CamFollow : MonoBehaviour
{
	private IGT_Hero pHero;

	public Transform camTarget;

	private float heightDamping = 2.75f;

	public GameObject CamIntroTarget;

	public Transform CamIntroLookat;

	private Vector3 CamPos;

	private Vector3 camLookAt;

	public static Vector3 CameraStartingPos;

	public static Vector3 CamBeforePrevPos;

	public static Vector3 CamPrevPos;

	public static Vector3 CamCurPos;

	private Vector3 dir_PrevToBeforePrev;

	private Vector3 dir_NewToPrev;

	private Vector3 CamDir;

	private float fCamdistFrmTarget = 1.5f;

	private float fXtraDistFrmTar = 0.25f;

	public float chec;

	private void Start()
	{
		camTarget = GameObject.FindGameObjectWithTag("Player").transform;
		pHero = camTarget.GetComponent<IGT_Hero>();
		CamPos = Vector3.zero;
		chec = 0.9f;
	}

	private void LateUpdate()
	{
		if (GameIntro.bIntroOver && IGT_Hero.bStrtButton && IGT_Hero.bRobbingSceneFinished)
		{
			if ((bool)camTarget)
			{
				CamPos = FindCamPos_BasedGivenDistFrm_camTarget(fCamdistFrmTarget);
				Vector3 vector = new Vector3(CamPos.x - CamCurPos.x, CamPos.y - CamCurPos.y, CamPos.z - CamCurPos.z);
				float magnitude = vector.magnitude;
				vector.Normalize();
				Vector3 vector2 = new Vector3(pHero.nextExpectedPos.x - CamCurPos.x, pHero.nextExpectedPos.y - CamCurPos.y, pHero.nextExpectedPos.z - CamCurPos.z);
				vector2.Normalize();
				float num = Vector3.Angle(vector, vector2);
				Debug.Log("Angle: " + num);
				Vector3 vector3 = vector * 0.8f + vector2 * 0.2f;
				CamCurPos += vector3 * magnitude;
				Camera.main.transform.position = CamCurPos + Vector3.up * 0.65f;
				Vector3 nextExpectedPos = pHero.nextExpectedPos;
				Camera.main.transform.LookAt(new Vector3(nextExpectedPos.x, nextExpectedPos.y + IGT_Constants.HeroHeight, nextExpectedPos.z));
				RemovingXtraValFrmList(fCamdistFrmTarget + fCamdistFrmTarget * fXtraDistFrmTar);
			}
		}
		else if ((bool)CamIntroTarget)
		{
			float b = CamIntroTarget.transform.position.y + 0.5f;
			float y = Camera.main.transform.position.y;
			y = Mathf.Lerp(y, b, heightDamping * Time.deltaTime);
			Camera.main.transform.position = CamIntroTarget.transform.position;
			Camera.main.transform.position -= Vector3.forward * 0.6f;
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, y, Camera.main.transform.position.z);
			Camera.main.transform.LookAt(new Vector3(CamIntroLookat.transform.position.x, chec, CamIntroLookat.transform.position.z));
		}
	}

	public Vector3 FindAvgPosFrCamera(Vector3 CameraPrevPos, Vector3 CameraCurPos, Vector3 PlayerPos)
	{
		Vector3 vector = new Vector3(CameraCurPos.x - CameraPrevPos.x, CameraCurPos.y - CameraPrevPos.y, CameraCurPos.z - CameraPrevPos.z);
		vector.Normalize();
		Vector3 vector2 = new Vector3(PlayerPos.x - CameraPrevPos.x, PlayerPos.y - CameraPrevPos.y, PlayerPos.z - CameraPrevPos.z);
		vector2.Normalize();
		Vector3 vector3 = (new Vector3(vector.x * 0.8f, vector.y * 0.8f, vector.z * 0.8f) + new Vector3(vector2.x * 0.2f, vector2.y * 0.2f, vector2.z * 0.2f)) * 0.5f;
		vector3.Normalize();
		return CameraPrevPos + vector3 * Vector3.Distance(CameraPrevPos, CameraCurPos);
	}

	public Vector3 FindCamPos_BasedGivenDistFrm_camTarget(float givenDist)
	{
		float num = 0f;
		float num2 = 0f;
		Vector3 vector = Vector3.zero;
		Vector3 result = CameraStartingPos;
		int count = IGT_Hero.pIgtCamPos.Count;
		int num3 = count - 1;
		while (num3 >= 0)
		{
			IGT_CamPositions iGT_CamPositions = IGT_Hero.pIgtCamPos[num3];
			num2 += iGT_CamPositions.fDistFrmLastPos;
			if (num2 < givenDist)
			{
				num = num2;
				vector = iGT_CamPositions.centerPosition;
				num3--;
				continue;
			}
			float num4 = givenDist - num;
			if (!iGT_CamPositions.bMovingBetweenPath && !pHero.PlayerObj.bMovingFinishdInPath)
			{
				Vector3 vector2 = iGT_CamPositions.centerPosition;
				Vector3 vector3;
				if (num3 - 1 >= 0)
				{
					vector3 = IGT_Hero.pIgtCamPos[num3 - 1].centerPosition;
				}
				else
				{
					vector3 = vector2;
					vector2 = vector;
				}
				Vector3 vector4 = new Vector3(vector3.x - vector2.x, vector3.y - vector2.y, vector3.z - vector2.z);
				vector4.Normalize();
				result = iGT_CamPositions.centerPosition + vector4 * num4;
				Vector3 vector5 = Vector3.Cross(vector4, Vector3.up);
				result += vector5 * pHero.offset_Laneoffset;
			}
			else
			{
				Vector3 vector6 = iGT_CamPositions.MovingPosition;
				Vector3 vector7;
				if (num3 - 1 >= 0)
				{
					vector7 = IGT_Hero.pIgtCamPos[num3 - 1].MovingPosition;
				}
				else
				{
					vector7 = vector6;
					vector6 = vector;
				}
				Vector3 vector8 = new Vector3(vector7.x - vector6.x, vector7.y - vector6.y, vector7.z - vector6.z);
				vector8.Normalize();
				result = iGT_CamPositions.MovingPosition + vector8 * num4;
			}
			break;
		}
		return result;
	}

	public void RemovingXtraValFrmList(float GivenDist)
	{
		float num = 0f;
		for (int num2 = IGT_Hero.pIgtCamPos.Count - 1; num2 >= 0; num2--)
		{
			IGT_CamPositions iGT_CamPositions = IGT_Hero.pIgtCamPos[num2];
			num += iGT_CamPositions.fDistFrmLastPos;
			if (num > GivenDist)
			{
				IGT_Hero.pIgtCamPos.RemoveAt(num2);
			}
		}
	}
}
