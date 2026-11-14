using UnityEngine;

public class GameIntro : MonoBehaviour
{
	private IGT_PathInfo pPathinfo;

	private Transform player;

	private float offset;

	public static bool bIntroOver;

	private float[,] camJointPoints;

	private int currentCamJointIdx;

	private void Start()
	{
		pPathinfo = new IGT_PathInfo();
		pPathinfo.PathInit(28, 0);
		player = base.transform;
		offset = 0f;
		bIntroOver = false;
		pPathinfo.speed = 2.5f;
		if (!pPathinfo.bTraverseReverse)
		{
			pPathinfo.animPointX = pPathinfo.waypoints[pPathinfo.currentPoint].position.x;
			pPathinfo.animPointY = pPathinfo.waypoints[pPathinfo.currentPoint].position.y;
			pPathinfo.animPointZ = pPathinfo.waypoints[pPathinfo.currentPoint].position.z;
			player.transform.position = pPathinfo.waypoints[pPathinfo.currentPoint].position;
			player.transform.LookAt(pPathinfo.waypoints[pPathinfo.currentPoint + 1].position);
		}
		else
		{
			pPathinfo.animPointX = pPathinfo.waypoints[pPathinfo.currentPoint - 1].position.x;
			pPathinfo.animPointY = pPathinfo.waypoints[pPathinfo.currentPoint - 1].position.y;
			pPathinfo.animPointZ = pPathinfo.waypoints[pPathinfo.currentPoint - 1].position.z;
			player.transform.position = pPathinfo.waypoints[pPathinfo.currentPoint - 1].position;
			player.transform.LookAt(pPathinfo.waypoints[pPathinfo.currentPoint - 1].position);
		}
		camJointPoints = new float[4, 3];
		camJointPoints[0, 0] = 0.475f;
		camJointPoints[0, 1] = 0.04f;
		camJointPoints[0, 2] = -70.146f;
		camJointPoints[1, 0] = 0.711f;
		camJointPoints[1, 1] = 0.04f;
		camJointPoints[1, 2] = -69.749f;
		camJointPoints[2, 0] = 0.72f;
		camJointPoints[2, 1] = 0.04f;
		camJointPoints[2, 2] = -69.087f;
		camJointPoints[3, 0] = 0.719f;
		camJointPoints[3, 1] = 0.04f;
		camJointPoints[3, 2] = -68.788f;
	}

	private void FixedUpdate()
	{
		if (!bIntroOver)
		{
			PlayerMovement();
		}
		else if (!IGT_Hero.bRobbingSceneFinished)
		{
			CameraJointMovement();
		}
	}

	private void CameraJointMovement()
	{
		if (!IGT_Hero.bCamStartFollow || currentCamJointIdx >= camJointPoints.GetLength(0) - 1)
		{
			return;
		}
		Vector3 curpos = new Vector3(camJointPoints[currentCamJointIdx, 0], camJointPoints[currentCamJointIdx, 1], camJointPoints[currentCamJointIdx, 2]);
		Vector3 nextpos = new Vector3(camJointPoints[currentCamJointIdx + 1, 0], camJointPoints[currentCamJointIdx + 1, 1], camJointPoints[currentCamJointIdx + 1, 2]);
		if (!MovingInPath(curpos, nextpos) && pPathinfo.bTargetReached)
		{
			pPathinfo.bTargetReached = false;
			currentCamJointIdx++;
			if (currentCamJointIdx == camJointPoints.GetLength(0) - 1)
			{
				pPathinfo.bTotalTarReached = true;
			}
		}
	}

	public void resetAll()
	{
		if (player != null)
		{
			player.transform.position = new Vector3(camJointPoints[0, 0], camJointPoints[0, 1], camJointPoints[0, 2]);
		}
		if (pPathinfo != null)
		{
			pPathinfo.animPointX = camJointPoints[0, 0];
			pPathinfo.animPointY = camJointPoints[0, 1];
			pPathinfo.animPointZ = camJointPoints[0, 2];
			pPathinfo.bTotalTarReached = false;
			pPathinfo.bTargetReached = false;
			pPathinfo.speed = 1.5f;
			currentCamJointIdx = 0;
		}
	}

	private void PlayerMovement()
	{
		if (!pPathinfo.bTraverseReverse && !pPathinfo.bTotalTarReached)
		{
			pPathinfo._curPos.x = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint, 0];
			pPathinfo._curPos.y = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint, 1];
			pPathinfo._curPos.z = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint, 2];
			pPathinfo._nextPos.x = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint + 1, 0];
			pPathinfo._nextPos.y = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint + 1, 1];
			pPathinfo._nextPos.z = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint + 1, 2];
		}
		if (pPathinfo.bTraverseReverse && !pPathinfo.bTotalTarReached)
		{
			pPathinfo._curPos.x = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint - 1, 0];
			pPathinfo._curPos.y = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint - 1, 1];
			pPathinfo._curPos.z = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint - 1, 2];
			pPathinfo._nextPos.x = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint - 2, 0];
			pPathinfo._nextPos.y = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint - 2, 1];
			pPathinfo._nextPos.z = pPathinfo.pointPos[pPathinfo.currentPathIndex, pPathinfo.nStartPoint - 2, 2];
		}
		if (!pPathinfo.bTotalTarReached && !MovingInPath(pPathinfo._curPos, pPathinfo._nextPos) && pPathinfo.bTargetReached)
		{
			pPathinfo.noOfTargetReached++;
			pPathinfo.bTargetReached = false;
			if (!pPathinfo.bTraverseReverse)
			{
				pPathinfo.nStartPoint++;
				pPathinfo.currentPoint++;
			}
			else
			{
				pPathinfo.nStartPoint--;
				pPathinfo.currentPoint--;
			}
			if (pPathinfo.waypoints.Length == pPathinfo.noOfTargetReached)
			{
				pPathinfo.bTotalTarReached = true;
			}
		}
		if (!pPathinfo.bTraverseReverse && pPathinfo.bTotalTarReached)
		{
			IGT_GameView.setScreenMode(0);
			bIntroOver = true;
			player.transform.position = new Vector3(camJointPoints[0, 0], camJointPoints[0, 1], camJointPoints[0, 2]);
			pPathinfo.animPointX = player.transform.position.x;
			pPathinfo.animPointY = player.transform.position.y;
			pPathinfo.animPointZ = player.transform.position.z;
			pPathinfo.bTotalTarReached = false;
			pPathinfo.bTargetReached = false;
			pPathinfo.speed = 1.5f;
		}
	}

	private bool MovingInPath(Vector3 curpos, Vector3 nextpos)
	{
		float x = nextpos.x - curpos.x;
		float y = nextpos.y - curpos.y;
		float z = nextpos.z - curpos.z;
		Vector3 rhs = new Vector3(x, y, z);
		rhs.Normalize();
		pPathinfo.animPointX += rhs.x * pPathinfo.speed * Time.deltaTime;
		pPathinfo.animPointY += rhs.y * pPathinfo.speed * Time.deltaTime;
		pPathinfo.animPointZ += rhs.z * pPathinfo.speed * Time.deltaTime;
		Vector3 vector = new Vector3(pPathinfo.animPointX, pPathinfo.animPointY, pPathinfo.animPointZ);
		Vector3 vector2 = Vector3.Cross(Vector3.up, rhs);
		Vector3 vector3 = vector + vector2 * offset;
		if (pPathinfo.isTargetReached(curpos, vector, nextpos))
		{
			pPathinfo.bTargetReached = true;
			float num = Vector3.Distance(player.transform.position, vector3);
			pPathinfo.fDistFrmStrtPnt += num;
			pPathinfo.fTotDistTraveled += num;
			player.transform.position = vector3;
			if (!pPathinfo.bTraverseReverse)
			{
				if (pPathinfo.waypoints.Length > pPathinfo.currentPoint + 2)
				{
					Vector3 worldPosition = pPathinfo.waypoints[pPathinfo.currentPoint + 2].position + vector2 * offset;
					player.transform.LookAt(worldPosition);
				}
			}
			else if (pPathinfo.currentPoint - 2 > 0)
			{
				Vector3 worldPosition2 = pPathinfo.waypoints[pPathinfo.currentPoint - 3].position + vector2 * offset;
				player.transform.LookAt(worldPosition2);
			}
			return false;
		}
		float num2 = Vector3.Distance(player.transform.position, vector3);
		pPathinfo.fDistFrmStrtPnt += num2;
		pPathinfo.fTotDistTraveled += num2;
		player.transform.position = vector3;
		return false;
	}
}
