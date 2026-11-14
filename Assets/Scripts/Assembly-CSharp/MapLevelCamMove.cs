using System.Collections.Generic;
using UnityEngine;

public class MapLevelCamMove
{
	private bool TestingEnable;

	private List<GameObject> testObj;

	private int nUnlockedLevel;

	private int idx;

	private int prevIdx;

	private int cameraStartIdx;

	private int _idx;

	private List<Vector3> cameraPosList;

	private List<Vector3> tmpCameraPosList;

	private IGT_File fileObj;

	private float velocityFact;

	private float ftouchVelocityFact;

	private float touchBegenY;

	private float touchEndY;

	private float touchDistance;

	private float prevTouchY;

	private float pPrevY;

	private float fTimeDiff;

	private float fStartTime;

	private float fEndTime;

	public static bool bMapScreenStartAnim;

	private int testPara;

	private float camMoveDist;

	public MapLevelCamMove()
	{
		bMapScreenStartAnim = true;
		velocityFact = 0f;
		ftouchVelocityFact = 0f;
		fileObj = new IGT_File();
		List<string> list = fileObj.readFile("Info/MapPoint");
		cameraPosList = new List<Vector3>();
		tmpCameraPosList = new List<Vector3>();
		for (int i = 0; i <= list.Count - 3; i += 4)
		{
			cameraPosList.Add(new Vector3(float.Parse(list[i]), float.Parse(list[i + 1]), float.Parse(list[i + 2])));
		}
		for (int j = cameraPosList.Count - 3; j < cameraPosList.Count; j++)
		{
			tmpCameraPosList.Add(cameraPosList[j]);
		}
	}

	public void setCameraStartPos()
	{
		idx = 0;
		_idx = 0;
		velocityFact = 0f;
		IGT_GameView.pMapObj.nClickedBtnId = IGT_GameView.pMapObj.getCurrentClickedBtnPosIdx();
		if (IGT_GameView.pMapObj.nClickedBtnId == 0)
		{
			IGT_GameView.pMapObj.nClickedBtnId = IGT_GameView.pMapObj.nBtnUnlockedCnt;
		}
		IGT_GameView.pMapObj.direction = 1f;
		ftouchVelocityFact = 0.75f;
		bMapScreenStartAnim = true;
		if (IGT_GameView.pMapObj.getButtonClickedId() % 200 > 3)
		{
			cameraStartIdx = IGT_GameView.pMapObj.getCurrentClickedBtnPosIdx() - 4;
		}
		else
		{
			cameraStartIdx = IGT_GameView.pMapObj.getCurrentClickedBtnPosIdx() - 3;
		}
		if (cameraStartIdx % (cameraPosList.Count - 1) > 0)
		{
			idx = cameraStartIdx % (cameraPosList.Count - 1);
		}
		else
		{
			idx = 0;
		}
		prevIdx = idx;
		updateTravesDistance();
		nUnlockedLevel = IGT_GameView.pMapObj.getUnlockedLevel();
		Camera.main.rect = new Rect(0f, 0f, 8f, 1f);
		Camera.main.transform.position = cameraPosList[idx];
		Camera.main.transform.position += Vector3.up;
		int num = idx + 2;
		if (num > cameraPosList.Count - 1)
		{
			num %= cameraPosList.Count - 1;
		}
		if (num == 2)
		{
			Camera.main.transform.LookAt(new Vector3(cameraPosList[num].x, cameraPosList[num].y + 1f, cameraPosList[num].z));
		}
		else
		{
			Camera.main.transform.LookAt(cameraPosList[num]);
		}
		IGT_GameView.pMapObj.processPlaceObjectsDetails();
	}

	public void updateTravesDistance()
	{
		IGT_GameView.pMapObj.fCameraTravesDistance = 0.0;
		if (idx != 0)
		{
			for (int i = 0; i < idx; i++)
			{
				IGT_GameView.pMapObj.fCameraTravesDistance += Vector3.Distance(cameraPosList[i], cameraPosList[i + 1]);
			}
		}
		int num = (IGT_GameView.pMapObj.getCurrentClickedBtnPosIdx() - 3) / (cameraPosList.Count - 1);
		IGT_GameView.pMapObj.fCameraTravesDistance += (double)num * IGT_GameView.pMapObj.fCameraTravesTotalDistance;
	}

	public void checkLateUpdate()
	{
		if (bMapScreenStartAnim)
		{
			moveCameraToMapPoint();
		}
		else
		{
			checkLateUpdateTouchPos();
		}
	}

	private void switchSwipeDirection(float currY)
	{
		float num = prevTouchY - pPrevY;
		if (num > 0f && currY < prevTouchY)
		{
			touchBegenY = prevTouchY;
		}
		if (num < 0f && currY > prevTouchY)
		{
			touchBegenY = prevTouchY;
		}
		pPrevY = prevTouchY;
	}

	private void checkLateUpdateTouchPos()
	{
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.phase == TouchPhase.Began)
			{
				velocityFact = 0f;
				fStartTime = Time.time;
				touchBegenY = (float)Screen.height - Input.mousePosition.y;
				pPrevY = (prevTouchY = touchBegenY);
			}
			if (touch.phase == TouchPhase.Moved)
			{
				float num = (float)Screen.height - touch.position.y;
				if (prevTouchY != num)
				{
					touchDistance = touchBegenY - num;
					findCameraMovePos(touchDistance);
					switchSwipeDirection(num);
				}
				prevTouchY = num;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				fEndTime = Time.time;
				touchEndY = (float)Screen.height - Input.mousePosition.y;
				touchDistance = touchBegenY - touchEndY;
				fTimeDiff = fEndTime - fStartTime;
				velocityFact = 0.75f;
				setVelocityForTouchDistance();
			}
		}
		if (velocityFact > 0f)
		{
			findCameraMovePosVelocity(touchDistance);
		}
		if (TestingEnable)
		{
			checkTraves();
		}
		setCameTraveDistance(touchDistance);
	}

	private void setCameTraveDistance(float dist)
	{
		if (IGT_GameView.pMapObj.fCameraTravesDistance < 0.0 || dist == 0f || idx == prevIdx)
		{
			return;
		}
		if (idx > prevIdx)
		{
			if (dist < 0f)
			{
				IGT_GameView.pMapObj.fCameraTravesDistance += Vector3.Distance(cameraPosList[prevIdx], cameraPosList[idx]);
			}
			else if (dist > 0f)
			{
				IGT_GameView.pMapObj.fCameraTravesDistance -= Vector3.Distance(cameraPosList[prevIdx], cameraPosList[idx]);
			}
		}
		else if (idx < prevIdx)
		{
			if (dist < 0f)
			{
				IGT_GameView.pMapObj.fCameraTravesDistance += Vector3.Distance(cameraPosList[prevIdx], cameraPosList[idx]);
			}
			else if (dist > 0f)
			{
				IGT_GameView.pMapObj.fCameraTravesDistance -= Vector3.Distance(cameraPosList[prevIdx], cameraPosList[idx]);
			}
		}
		if (IGT_GameView.pMapObj.fCameraTravesDistance < 0.0)
		{
			IGT_GameView.pMapObj.fCameraTravesDistance = 0.0;
		}
		IGT_GameView.pMapObj.processPlaceObjectsDetails();
		prevIdx = idx;
	}

	private void setVelocityForTouchDistance()
	{
		velocityFact = Mathf.Abs(touchDistance / (float)Screen.height / fTimeDiff * 0.75f);
		if (velocityFact > 2f)
		{
			velocityFact = 2f;
		}
	}

	private void checkTraves()
	{
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.phase == TouchPhase.Moved)
			{
				if (touchBegenY - ((float)Screen.height - touch.position.y) < 0f)
				{
					testPara = -1;
				}
				if (touchBegenY - ((float)Screen.height - touch.position.y) > 0f)
				{
					testPara = 1;
				}
				if (touchBegenY - ((float)Screen.height - touch.position.y) == 0f)
				{
					testPara = 0;
				}
			}
		}
		ftouchVelocityFact = 1.5f;
		findCameraMovePos(testPara);
	}

	public int getCurrButtonIndex()
	{
		int num = (int)(IGT_GameView.pMapObj.fCameraTravesDistance / IGT_GameView.pMapObj.fCameraTravesTotalDistance);
		if (num < 0)
		{
			num = 0;
		}
		double num2 = IGT_GameView.pMapObj.fCameraTravesDistance % IGT_GameView.pMapObj.fCameraTravesTotalDistance;
		double num3 = 0.0;
		int num4 = 0;
		for (int i = 0; i < cameraPosList.Count - 1; i++)
		{
			num3 += (double)Vector3.Distance(cameraPosList[i], cameraPosList[i + 1]);
			if (num3 >= num2)
			{
				num4 = i;
				break;
			}
		}
		if (num4 == 199)
		{
			num--;
		}
		return num4 + 1 + num * (cameraPosList.Count - 1);
	}

	private void findCameraMovePosVelocity(float _distance)
	{
		if (IGT_GameView.pMapObj.bButtonClick || _distance == 0f)
		{
			return;
		}
		if (_distance < 0f && getCurrButtonIndex() >= nUnlockedLevel - 1)
		{
			bMapScreenStartAnim = false;
			return;
		}
		Vector3 vector = cameraPosList[idx];
		Vector3 vector2 = cameraPosList[idx + 1];
		float num = Vector3.Distance(vector, vector2);
		float num2 = num * Time.deltaTime + velocityFact;
		velocityFact -= 0.018f;
		if (_distance > 0f)
		{
			camMoveDist -= 0.1f * num2;
			if (camMoveDist <= 0f)
			{
				if (idx > 0)
				{
					idx--;
					IGT_GameView.pMapObj.direction = -1f;
					vector = cameraPosList[idx];
					vector2 = cameraPosList[idx + 1];
					camMoveDist = Vector3.Distance(vector, vector2) + camMoveDist;
				}
				else if (idx == 0 && IGT_GameView.pMapObj.fCameraTravesDistance > 0.0 && getCurrButtonIndex() > 1)
				{
					idx = 199;
					vector = cameraPosList[idx];
					vector2 = cameraPosList[idx + 1];
					camMoveDist = Vector3.Distance(vector, vector2) + camMoveDist;
				}
				else
				{
					camMoveDist = 0f;
				}
			}
		}
		else
		{
			camMoveDist += 0.1f * num2;
			if (camMoveDist > num)
			{
				if (idx < cameraPosList.Count - 2)
				{
					idx++;
					IGT_GameView.pMapObj.direction = 1f;
				}
				else
				{
					idx = 0;
				}
				camMoveDist -= Vector3.Distance(vector, vector2);
			}
			vector = cameraPosList[idx];
			vector2 = cameraPosList[idx + 1];
		}
		Vector3 vector3 = vector2 - vector;
		vector3.Normalize();
		resetCameraPos(vector + vector3 * camMoveDist);
	}

	private void findCameraMovePos(float _distance)
	{
		if (IGT_GameView.pMapObj.bButtonClick || _distance == 0f)
		{
			return;
		}
		if ((_distance < 0f && getCurrButtonIndex() >= nUnlockedLevel - 1) || (getCurrButtonIndex() == IGT_GameView.pMapObj.getButtonClickedId() && bMapScreenStartAnim))
		{
			bMapScreenStartAnim = false;
			return;
		}
		int num = (int)(IGT_GameView.pMapObj.fCameraTravesDistance / IGT_GameView.pMapObj.fCameraTravesTotalDistance);
		if (num == 0)
		{
			if (IGT_GameView.pMapObj.getButtonClickedId() == 1 && idx + 1 == IGT_GameView.pMapObj.getButtonClickedId() && bMapScreenStartAnim)
			{
				bMapScreenStartAnim = false;
			}
			else if (IGT_GameView.pMapObj.getButtonClickedId() == 2 && idx + 1 == IGT_GameView.pMapObj.getButtonClickedId() && bMapScreenStartAnim)
			{
				bMapScreenStartAnim = false;
			}
		}
		if (idx + 1 + 2 * (num + 1) * 100 == IGT_GameView.pMapObj.getButtonClickedId() && bMapScreenStartAnim)
		{
			bMapScreenStartAnim = false;
		}
		else if (idx == 1 && IGT_GameView.pMapObj.getCurrentClickedBtnPosIdx() == idx + 2 + 2 * num * 100)
		{
			bMapScreenStartAnim = false;
		}
		Vector3 vector = cameraPosList[idx];
		Vector3 vector2 = cameraPosList[idx + 1];
		float num2 = Vector3.Distance(vector, vector2);
		float num3 = num2 * Time.deltaTime + ftouchVelocityFact;
		if (_distance > 0f)
		{
			camMoveDist -= 0.1f * num3;
			if (camMoveDist <= 0f)
			{
				if (idx > 0)
				{
					idx--;
					IGT_GameView.pMapObj.direction = -1f;
					vector = cameraPosList[idx];
					vector2 = cameraPosList[idx + 1];
					camMoveDist = Vector3.Distance(vector, vector2) + camMoveDist;
				}
				else if (idx == 0 && IGT_GameView.pMapObj.fCameraTravesDistance > 0.0 && getCurrButtonIndex() > 1)
				{
					idx = 199;
					vector = cameraPosList[idx];
					vector2 = cameraPosList[idx + 1];
					camMoveDist = Vector3.Distance(vector, vector2) + camMoveDist;
				}
				else
				{
					camMoveDist = 0f;
				}
			}
		}
		else
		{
			camMoveDist += 0.1f * num3;
			if (camMoveDist > num2)
			{
				if (idx < cameraPosList.Count - 2)
				{
					idx++;
					IGT_GameView.pMapObj.direction = 1f;
				}
				else
				{
					idx = 0;
				}
				camMoveDist -= Vector3.Distance(vector, vector2);
			}
			vector = cameraPosList[idx];
			vector2 = cameraPosList[idx + 1];
		}
		Vector3 vector3 = vector2 - vector;
		vector3.Normalize();
		resetCameraPos(vector + vector3 * camMoveDist);
	}

	private void moveCameraFromImg(float _distance)
	{
		if (!IGT_GameView.pMapObj.bButtonClick && _distance != 0f)
		{
			if (!(_distance < 0f) || getCurrButtonIndex() >= nUnlockedLevel - 2)
			{
			}
			int num = (int)(IGT_GameView.pMapObj.fCameraTravesDistance / IGT_GameView.pMapObj.fCameraTravesTotalDistance);
			if (idx + 1 + 2 * (num + 1) * 100 == IGT_GameView.pMapObj.getCurrentClickedBtnPosIdx() && bMapScreenStartAnim)
			{
				bMapScreenStartAnim = false;
			}
			Vector3 vector = cameraPosList[0];
			Vector3 vector2 = cameraPosList[3];
			float num2 = Vector3.Distance(vector, vector2);
			float num3 = num2 * Time.deltaTime + ftouchVelocityFact - 0.5f;
			camMoveDist += 0.1f * num3;
			Vector3 vector3 = vector2 - vector;
			vector3.Normalize();
			resetCameraPos(vector + vector3 * camMoveDist);
		}
	}

	private void findCameraPosForImagin()
	{
		Vector3 a = tmpCameraPosList[_idx];
		Vector3 b = tmpCameraPosList[_idx + 1];
		float num = Vector3.Distance(a, b);
		float num2 = num * Time.deltaTime + 0.6f;
		camMoveDist += 0.1f * num2;
		if (camMoveDist > num)
		{
			if (_idx < tmpCameraPosList.Count - 1)
			{
				_idx++;
			}
			camMoveDist -= Vector3.Distance(a, b);
		}
		a = tmpCameraPosList[_idx];
		b = ((_idx >= tmpCameraPosList.Count - 1) ? cameraPosList[idx] : tmpCameraPosList[_idx + 1]);
		Vector3 vector = b - a;
		vector.Normalize();
		resetCameraPos(a + vector * camMoveDist);
	}

	private void resetCameraPos(Vector3 camPos)
	{
		Camera.main.transform.position = camPos;
		Camera.main.transform.position += Vector3.up;
		Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, Quaternion.LookRotation(getCameraLookAtPos() - Camera.main.transform.position), 3.25f * Time.smoothDeltaTime);
	}

	private Vector3 getCameraLookAtPos()
	{
		int num = 0;
		num = ((idx != cameraPosList.Count - 3) ? ((idx == cameraPosList.Count - 2) ? 1 : (idx + 3)) : 0);
		if (num > cameraPosList.Count - 2)
		{
			num = 0;
		}
		if (IGT_GameView.pMapObj.direction == -1f)
		{
			num = idx + 1;
		}
		Vector3 vector = cameraPosList[num] + Vector3.up - Camera.main.transform.position;
		vector.Normalize();
		if (camMoveDist != 0f)
		{
			vector *= camMoveDist;
		}
		return Camera.main.transform.position + vector;
	}

	private void moveCameraToMapPoint()
	{
		if (getCurrButtonIndex() >= IGT_GameView.pMapObj.getButtonClickedId() - 1)
		{
		}
		if (idx <= cameraStartIdx % (cameraPosList.Count - 1) + 1)
		{
			findCameraMovePos(-1f);
			IGT_GameView.pMapObj.fCameraTravesDistance += Vector3.Distance(cameraPosList[prevIdx], cameraPosList[idx]);
			prevIdx = idx;
		}
		else
		{
			bMapScreenStartAnim = false;
		}
	}
}
