using System;
using System.Collections.Generic;
using System.IO;
using SQLite4Unity3d;
using UnityEngine;

public class MapAPI
{
	private SQLiteConnection sqlliteConn;

	public static string sDBName = "scmapleveldata.db";

	public static string kCurrentCameraPosIndex = "kcurrentcameraposindex";

	public static string kUNLOCKLEVELPOINT = "unlocklevelpointkey";

	public double fCameraTravesTotalDistance = 284.761712014675;

	public double fCameraTravesDistance;

	public int nCurrentClickedBtnPosIdx;

	public bool bButtonClick;

	public int nClickedBtnId;

	public int nBtnUnlockedCnt;

	private List<GameObject> gameobject_Btn;

	private List<string> vectPos;

	private Vector3 prevPosVect;

	public IGT_File fileObj;

	private Vector3 localScaleVect = Vector3.zero;

	private GameObject clickedGameObj;

	private Material BtnMaterial;

	private Material BtnLockMaterial;

	private Material BtnLockBaseMaterial;

	private Material GoldStarMaterial;

	private Material currBtnMaterial;

	private Material BringBackMaterial;

	private Material BottleMaterial;

	private Material JumpingSlideMaterial;

	private Material CollectionMaterial;

	private Material ChaseMaterial;

	private Material WordSearchMaterial;

	private Material BallMaterial;

	private Material DefaultMaterial;

	private Material[] mats;

	public List<Vector3> listVectorPos;

	public List<float> rotationAngleForPoints;

	public int idx = 1;

	public float[] charValues;

	public float[] charFrontSpace;

	public float[] charSize;

	public float direction = 1f;

	public MapAPI()
	{
		BtnMaterial = Resources.Load<Material>("Objects/Map/base_mbtn");
		BtnLockBaseMaterial = Resources.Load<Material>("Objects/Map/locked_base_mbtn");
		currBtnMaterial = Resources.Load<Material>("Objects/Map/base_current_mbtn");
		BringBackMaterial = Resources.Load<Material>("Objects/Map/bringback_mbtn");
		BottleMaterial = Resources.Load<Material>("Objects/Map/challenge_bottle_mbtn");
		JumpingSlideMaterial = Resources.Load<Material>("Objects/Map/challenge_jumpingslide_mbtn");
		CollectionMaterial = Resources.Load<Material>("Objects/Map/collection_mbtn");
		WordSearchMaterial = Resources.Load<Material>("Objects/Map/wordsearch_mbtn");
		DefaultMaterial = Resources.Load<Material>("Objects/Map/default_mbtn");
		BallMaterial = Resources.Load<Material>("Objects/Map/ball_mbtn");
		BtnLockMaterial = Resources.Load<Material>("Objects/Map/locked_mbtn");
		ChaseMaterial = Resources.Load<Material>("Objects/Map/chase_mbtn");
		GoldStarMaterial = Resources.Load<Material>("Objects/Num/Materials/Star");
		gameobject_Btn = new List<GameObject>();
		rotationAngleForPoints = new List<float>();
		fileObj = new IGT_File();
		vectPos = fileObj.readFile("Info/MapPoint");
		prevPosVect = new Vector3(float.Parse(vectPos[0]), float.Parse(vectPos[1]) + 0.02f, float.Parse(vectPos[2]));
		listVectorPos = new List<Vector3>();
		for (int i = 0; i < vectPos.Count; i += 4)
		{
			listVectorPos.Add(new Vector3(float.Parse(vectPos[i]), float.Parse(vectPos[i + 1]) + 0.02f, float.Parse(vectPos[i + 2])));
			rotationAngleForPoints.Add(float.Parse(vectPos[i + 3]));
		}
		DBSettings(sDBName);
		sqlliteConn.CreateTable<SQL_LevelStarCount>();
		nBtnUnlockedCnt = getUnlockedLevel();
		charValues = new float[10] { 0.045f, 0.03f, 0.04f, 0.04f, 0.04f, 0.04f, 0.045f, 0.035f, 0.045f, 0.045f };
		charFrontSpace = new float[10] { 0.03f, 0.02f, 0.03f, 0.03f, 0.03f, 0.04f, 0.035f, 0.03f, 0.04f, 0.035f };
		charSize = new float[10] { 0.0812f, 0.0547f, 0.0745f, 0.078f, 0.0773f, 0.0703f, 0.0755f, 0.0615f, 0.0812f, 0.0758f };
	}

	private void DBSettings(string DatabaseName)
	{
		string text = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
		if (!File.Exists(text))
		{
			Debug.Log("Database not in Persistent path ");
			WWW wWW = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);
			while (!wWW.isDone)
			{
			}
			File.WriteAllBytes(text, wWW.bytes);
			Debug.Log("Database written");
		}
		string databasePath = text;
		sqlliteConn = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
	}

	public int getUnlockedLevel()
	{
		return IGT_Preference.getInstance()._Get(kUNLOCKLEVELPOINT, 1);
	}

	private int getLevelStarDetails(int _levelId)
	{
		TableQuery<SQL_LevelStarCount> tableQuery = sqlliteConn.Table<SQL_LevelStarCount>();
		foreach (SQL_LevelStarCount item in tableQuery)
		{
			if (item.LevelID == _levelId)
			{
				return item.LevelStarCount;
			}
		}
		return 0;
	}

	public int getCurrentClickedBtnPosIdx()
	{
		nCurrentClickedBtnPosIdx = IGT_Preference.getInstance()._Get(kCurrentCameraPosIndex, 0);
		return nCurrentClickedBtnPosIdx;
	}

	private void setClickedPoint(int ClickedBtnId)
	{
		IGT_Preference.getInstance()._Set(kCurrentCameraPosIndex, ClickedBtnId);
	}

	public void levUnlockPoints(int _cmpltLevelPoint)
	{
		if (_cmpltLevelPoint >= getUnlockedLevel())
		{
			IGT_Preference.getInstance()._Set(kUNLOCKLEVELPOINT, _cmpltLevelPoint + 1);
			setClickedPoint(_cmpltLevelPoint + 1);
		}
		else
		{
			setClickedPoint(_cmpltLevelPoint + 1);
		}
	}

	public void updateRotationAngle()
	{
		if (nBtnUnlockedCnt <= 0)
		{
			return;
		}
		int num = nBtnUnlockedCnt % (gameobject_Btn.Count - 1) - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (gameobject_Btn != null && gameobject_Btn.Count > 0)
		{
			Transform transform = gameobject_Btn[num].transform.Find("star1");
			Transform transform2 = gameobject_Btn[num].transform.Find("star2");
			Transform transform3 = gameobject_Btn[num].transform.Find("star3");
			if (transform != null && transform2 != null && transform3 != null)
			{
				transform.Rotate(0f, Time.deltaTime * 80f, 0f);
				transform2.Rotate(0f, Time.deltaTime * 30f, 0f);
				transform3.Rotate(0f, Time.deltaTime * 50f, 0f);
			}
		}
	}

	public void processPlaceObjectsDetails()
	{
		int num = (int)(fCameraTravesDistance / fCameraTravesTotalDistance);
		if (num < 0)
		{
			num = 0;
		}
		double num2 = fCameraTravesDistance % fCameraTravesTotalDistance;
		double num3 = 0.0;
		int num4 = 0;
		for (int i = 0; i < listVectorPos.Count - 1; i++)
		{
			num3 += (double)Vector3.Distance(listVectorPos[i], listVectorPos[i + 1]);
			if (num3 >= num2)
			{
				num4 = i;
				break;
			}
		}
		int num5 = num4 + 1 + num * (listVectorPos.Count - 1);
		if (direction == 1f)
		{
			if (num4 > 4)
			{
				if (num4 == 5 && num5 > 200)
				{
					for (int j = 194; j <= 199; j++)
					{
						btnObjectDeActived(j, num - 1);
					}
				}
				btnObjectDeActived(num4 - 5, num);
			}
			if (num4 >= 194)
			{
				for (int k = 0; k < 7; k++)
				{
					if (MapLevelCamMove.bMapScreenStartAnim && nClickedBtnId == num * (listVectorPos.Count - 1) + 3)
					{
						btnObjectActived(k, num);
					}
					else if (num4 != 199 || MapLevelCamMove.bMapScreenStartAnim)
					{
						btnObjectActived(k, num + 1);
					}
				}
				for (int l = 196; l <= 199; l++)
				{
					if (MapLevelCamMove.bMapScreenStartAnim && nClickedBtnId == num * (listVectorPos.Count - 1) + 3)
					{
						btnObjectActived(l, num - 1);
					}
					else
					{
						btnObjectActived(l, num);
					}
				}
			}
			else
			{
				if (num4 >= 194)
				{
					return;
				}
				for (int m = num4 - 2; m < 200 && m < num4 + 10; m++)
				{
					if (m >= 0)
					{
						btnObjectActived(m, num);
					}
				}
			}
		}
		else
		{
			if (direction != -1f)
			{
				return;
			}
			if (num4 < 190)
			{
				btnObjectDeActived(num4 + 10, num);
			}
			else if (num4 == 190)
			{
				for (int n = 0; n < 10; n++)
				{
					btnObjectDeActived(n, num + 1);
				}
			}
			if (num4 == 0 && num5 >= 5)
			{
				for (int num6 = 196; num6 <= 199; num6++)
				{
					btnObjectActived(num6, num - 1);
				}
			}
			else if (num4 < 198)
			{
				int num7 = num4;
				while (num7 >= 0 && num7 > num4 - 3)
				{
					btnObjectActived(num7, num);
					num7--;
				}
			}
		}
	}

	private void destroyLevelID(int _currentID)
	{
		if (_currentID < 10)
		{
			if (_currentID == 9)
			{
				Transform transform = gameobject_Btn[gameobject_Btn.Count - 1].transform.Find("LevelID");
				if (transform != null)
				{
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
			_currentID = gameobject_Btn.Count + _currentID;
		}
		Transform transform2 = gameobject_Btn[_currentID - 10].transform.Find("LevelID");
		if (transform2 != null)
		{
			UnityEngine.Object.Destroy(transform2.gameObject);
		}
	}

	private void btnObjectDeActived(int currIdx, int indx)
	{
		int num = currIdx + 1 + indx * (listVectorPos.Count - 1);
		Transform transform = gameobject_Btn[currIdx].transform.Find("star1");
		Transform transform2 = gameobject_Btn[currIdx].transform.Find("star2");
		Transform transform3 = gameobject_Btn[currIdx].transform.Find("star3");
		transform.gameObject.SetActive(false);
		transform2.gameObject.SetActive(false);
		transform3.gameObject.SetActive(false);
		gameobject_Btn[currIdx].GetComponent<Renderer>().material = BtnLockMaterial;
		gameobject_Btn[currIdx].SetActive(false);
		gameobject_Btn[currIdx].name = num + "_mbtn";
	}

	private void btnObjectActived(int currIdx, int indx)
	{
		if (currIdx > listVectorPos.Count - 1)
		{
			return;
		}
		int num = currIdx + 1 + indx * (listVectorPos.Count - 1);
		if (gameobject_Btn[currIdx].activeSelf && gameobject_Btn[currIdx].name.Equals(num + "_mbtn"))
		{
			return;
		}
		gameobject_Btn[currIdx].SetActive(true);
		mats = gameobject_Btn[currIdx].GetComponent<Renderer>().materials;
		float y = gameobject_Btn[currIdx].transform.eulerAngles.y;
		float z = gameobject_Btn[currIdx].transform.eulerAngles.z;
		gameobject_Btn[currIdx].transform.rotation = Quaternion.Euler(new Vector3(-90f, y, z));
		if (num <= nBtnUnlockedCnt)
		{
			Transform transform = gameobject_Btn[currIdx].transform.Find("LevelID");
			if (!gameobject_Btn[currIdx].name.Equals(num + "_mbtn") || transform == null)
			{
				placeLevelNum(currIdx + 1, num);
			}
			gameobject_Btn[currIdx].name = num + "_mbtn";
			if (num < nBtnUnlockedCnt)
			{
				mats[1] = BtnMaterial;
			}
			else
			{
				mats[1] = currBtnMaterial;
			}
			switch (IGT_Hero.pGetMissionInfo(num - 1))
			{
			case 0:
				mats[0] = CollectionMaterial;
				break;
			case 2:
				mats[0] = BringBackMaterial;
				break;
			case 3:
				mats[0] = WordSearchMaterial;
				break;
			case 4:
				mats[0] = ChaseMaterial;
				break;
			case 5:
				mats[0] = BallMaterial;
				break;
			case 6:
				mats[0] = BottleMaterial;
				break;
			case 7:
				mats[0] = JumpingSlideMaterial;
				break;
			default:
				mats[0] = DefaultMaterial;
				break;
			}
			gameobject_Btn[currIdx].GetComponent<Renderer>().materials = mats;
			Transform transform2 = gameobject_Btn[currIdx].transform.Find("star1");
			Transform transform3 = gameobject_Btn[currIdx].transform.Find("star2");
			Transform transform4 = gameobject_Btn[currIdx].transform.Find("star3");
			switch (getLevelStarDetails(num))
			{
			case 3:
				transform2.GetComponent<Renderer>().material = GoldStarMaterial;
				transform3.GetComponent<Renderer>().material = GoldStarMaterial;
				transform4.GetComponent<Renderer>().material = GoldStarMaterial;
				transform2.transform.localPosition = new Vector3(0f, 0f, 0.0047f);
				transform3.transform.localPosition = new Vector3(-0.00091f, 0f, 0.004388f);
				transform4.transform.localPosition = new Vector3(0.00091f, 0f, 0.004388f);
				transform2.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				transform3.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				transform4.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				transform2.gameObject.SetActive(true);
				transform3.gameObject.SetActive(true);
				transform4.gameObject.SetActive(true);
				break;
			case 2:
				transform2.GetComponent<Renderer>().material = GoldStarMaterial;
				transform3.GetComponent<Renderer>().material = GoldStarMaterial;
				transform2.transform.localPosition = new Vector3(0.00052f, 0f, 0.00471f);
				transform3.transform.localPosition = new Vector3(-0.00052f, 0f, 0.00471f);
				transform2.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				transform3.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				transform2.gameObject.SetActive(true);
				transform3.gameObject.SetActive(true);
				transform4.gameObject.SetActive(false);
				break;
			case 1:
				transform2.GetComponent<Renderer>().material = GoldStarMaterial;
				transform2.transform.localPosition = new Vector3(0f, 0f, 0.0047f);
				transform2.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				transform2.gameObject.SetActive(true);
				transform3.gameObject.SetActive(false);
				transform4.gameObject.SetActive(false);
				break;
			default:
				transform2.gameObject.SetActive(false);
				transform3.gameObject.SetActive(false);
				transform4.gameObject.SetActive(false);
				break;
			}
		}
		else
		{
			mats[0] = BtnLockMaterial;
			mats[1] = BtnLockBaseMaterial;
			gameobject_Btn[currIdx].GetComponent<Renderer>().materials = mats;
		}
	}

	private void placeLevelNum(int _index, int _currentLevel)
	{
		int num = _index - 1;
		if (num <= 0)
		{
			num = listVectorPos.Count - 1;
		}
		if (_index > listVectorPos.Count - 1)
		{
			_index = 1;
		}
		Transform transform = gameobject_Btn[_index - 1].transform.Find("LevelID");
		if (transform != null)
		{
			UnityEngine.Object.Destroy(transform.gameObject);
		}
		Vector3 position = gameobject_Btn[_index - 1].transform.position;
		if (_currentLevel <= 0)
		{
			return;
		}
		char[] array = mapPointGen(_currentLevel);
		GameObject gameObject = new GameObject();
		gameObject.name = "LevelID";
		gameObject.transform.parent = gameobject_Btn[_index - 1].transform;
		gameObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Objects/Num/" + array[i]), gameObject.transform.position, Quaternion.identity) as GameObject;
			gameObject2.name = _currentLevel + "_" + i;
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			if (array.Length == 1)
			{
				gameObject2.transform.localPosition = new Vector3(0f, -0.038f, -0.04f);
			}
			if (array.Length == 2)
			{
				if (i == 0)
				{
					gameObject2.transform.localPosition = new Vector3(0.082f - charFrontSpace[int.Parse(array[i].ToString())], -0.038f, -0.04f);
					continue;
				}
				Transform transform2 = gameObject.transform.Find(_currentLevel + "_" + (i - 1));
				gameObject2.transform.localPosition = new Vector3(transform2.transform.localPosition.x - 0.02f - charSize[int.Parse(array[i - 1].ToString())] / 2f - charSize[int.Parse(array[i].ToString())] / 2f, -0.038f, -0.04f);
			}
			else if (array.Length == 3)
			{
				if (i == 0)
				{
					gameObject2.transform.localPosition = new Vector3(0.125f - charFrontSpace[int.Parse(array[i].ToString())], -0.038f, -0.04f);
					continue;
				}
				Transform transform3 = gameObject.transform.Find(_currentLevel + "_" + (i - 1));
				gameObject2.transform.localPosition = new Vector3(transform3.transform.localPosition.x - 0.02f - charSize[int.Parse(array[i - 1].ToString())] / 2f - charSize[int.Parse(array[i].ToString())] / 2f, -0.038f, -0.04f);
			}
			else if (array.Length == 4)
			{
				gameObject2.transform.localScale = new Vector3(62f, 62f, 62f);
				if (i == 0)
				{
					gameObject2.transform.localPosition = new Vector3(0.14f - charFrontSpace[int.Parse(array[i].ToString())] / 1.235f, -0.03f, -0.04f);
					continue;
				}
				Transform transform4 = gameObject.transform.Find(_currentLevel + "_" + (i - 1));
				gameObject2.transform.localPosition = new Vector3(transform4.transform.localPosition.x - 0.005f - charSize[int.Parse(array[i - 1].ToString())] / 2.47f - charSize[int.Parse(array[i].ToString())] / 2f, -0.03f, -0.04f);
			}
		}
		gameObject.transform.localPosition = new Vector3(0f, -0.00127f, 0.000704f);
	}

	private string splitLevelNum(string txt)
	{
		string[] array = txt.Split('_');
		return array[0];
	}

	private int currentLevelId()
	{
		int num = (int)(fCameraTravesDistance / fCameraTravesTotalDistance);
		if (num < 0)
		{
			num = 0;
		}
		double num2 = fCameraTravesDistance % fCameraTravesTotalDistance;
		double num3 = 0.0;
		int num4 = 0;
		for (int i = 0; i < listVectorPos.Count - 1; i++)
		{
			num3 += (double)Vector3.Distance(listVectorPos[i], listVectorPos[i + 1]);
			if (num3 >= num2)
			{
				num4 = i;
				break;
			}
		}
		return num4 + 1 + num * (listVectorPos.Count - 1);
	}

	public void placeLevelObjects1()
	{
		nBtnUnlockedCnt = getUnlockedLevel();
		for (int i = 1; i < listVectorPos.Count; i++)
		{
			if (i == 1)
			{
				prevPosVect = listVectorPos[0];
			}
			Vector3 vector = crossVector(listVectorPos[i], prevPosVect);
			vector = ((i % 2 != 0) ? (listVectorPos[i] + vector * 0.4f) : (listVectorPos[i] + vector * -0.4f));
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Objects/Map/map_level_btn"), vector, Quaternion.Euler(0f, rotationAngleForPoints[i], 0f)) as GameObject;
			gameObject.SetActive(false);
			gameobject_Btn.Add(gameObject);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Objects/Num/Star"), Vector3.zero, Quaternion.identity) as GameObject;
			gameObject2.name = "star1";
			gameObject2.SetActive(false);
			gameObject2.transform.parent = gameobject_Btn[i - 1].transform;
			GameObject gameObject3 = UnityEngine.Object.Instantiate(Resources.Load("Objects/Num/Star"), Vector3.zero, Quaternion.identity) as GameObject;
			gameObject3.name = "star2";
			gameObject3.SetActive(false);
			gameObject3.transform.parent = gameobject_Btn[i - 1].transform;
			GameObject gameObject4 = UnityEngine.Object.Instantiate(Resources.Load("Objects/Num/Star"), Vector3.zero, Quaternion.identity) as GameObject;
			gameObject4.name = "star3";
			gameObject4.SetActive(false);
			gameObject4.transform.parent = gameobject_Btn[i - 1].transform;
			prevPosVect = vector;
		}
	}

	public Vector3 crossVector(Vector3 _curr, Vector3 _prev)
	{
		Vector3 rhs = new Vector3(_curr.x - _prev.x, _curr.y - _prev.y, _curr.z - _prev.z);
		rhs.Normalize();
		return Vector3.Cross(Vector3.up, rhs);
	}

	public float findRotation(Vector3 pos, Vector3 prevpos)
	{
		Vector3 vector = new Vector3(pos.x - prevpos.x, pos.y - prevpos.y, pos.z - prevpos.z);
		vector.Normalize();
		float num = Vector3.Angle(vector, Vector3.forward);
		if (Vector3.Cross(vector, Vector3.up).z < 0f)
		{
			num = 0f - num;
		}
		return 0f - num;
	}

	public int getButtonClickedId()
	{
		return nClickedBtnId;
	}

	public void getStartAchivements()
	{
		if (IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFQ", 0) == 1 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFg", 0) == 1 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFw", 0) == 1 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQGA", 0) == 1)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		TableQuery<SQL_LevelStarCount> tableQuery = sqlliteConn.Table<SQL_LevelStarCount>();
		foreach (SQL_LevelStarCount item in tableQuery)
		{
			if (item.LevelID < 10)
			{
				num += item.LevelStarCount;
			}
			if (item.LevelStarCount == 3)
			{
				num2++;
			}
		}
	}

	public void insertLevelStarData(int _levelId, int _starCnt)
	{
		bool flag = false;
		int num = 0;
		TableQuery<SQL_LevelStarCount> tableQuery = sqlliteConn.Table<SQL_LevelStarCount>();
		foreach (SQL_LevelStarCount item in tableQuery)
		{
			if (item.LevelID == _levelId)
			{
				flag = true;
				num = item.LevelStarCount;
			}
		}
		if (!flag)
		{
			try
			{
				sqlliteConn.Insert(new SQL_LevelStarCount
				{
					LevelID = _levelId,
					LevelStarCount = _starCnt
				});
			}
			catch (SQLiteException ex)
			{
				Debug.Log("Excep:" + ex.Message);
			}
		}
		else if (num < _starCnt)
		{
			string query = "update SQL_LevelStarCount set LevelStarCount =" + _starCnt + " where LevelID =" + _levelId;
			sqlliteConn.Execute(query);
		}
		levUnlockPoints(_levelId);
	}

	private void getInsertedValues()
	{
		TableQuery<SQL_LevelStarCount> tableQuery = sqlliteConn.Table<SQL_LevelStarCount>();
		foreach (SQL_LevelStarCount item in tableQuery)
		{
			Debug.Log(item.ToString());
		}
	}

	public char[] mapPointGen(int _mapCurrPoint)
	{
		return _mapCurrPoint.ToString().ToCharArray();
	}

	private string sepName(string _btnName)
	{
		string[] array = _btnName.Split('_');
		return array[0];
	}

	public void mapButtonEventChecking(Vector3 _pos, TouchPhase _phase, Action<int> buttonClickPoint)
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector2 vector = Input.mousePosition;
		try
		{
			switch (_phase)
			{
			case TouchPhase.Began:
				if (Physics.Raycast(Camera.main.ScreenPointToRay(_pos), out hitInfo) && (vector.x > IGT_UIcommonFunc.ScaleX(50f) || vector.y > IGT_UIcommonFunc.ScaleX(55f)) && hitInfo.transform.name.EndsWith("_mbtn"))
				{
					int num = int.Parse(sepName(hitInfo.transform.name));
					if (num <= nBtnUnlockedCnt)
					{
						clickedGameObj = hitInfo.transform.gameObject;
						localScaleVect = hitInfo.transform.localScale;
						hitInfo.transform.localScale = localScaleVect * 0.8f;
						bButtonClick = true;
					}
				}
				break;
			case TouchPhase.Moved:
				if (!Physics.Raycast(Camera.main.ScreenPointToRay(_pos), out hitInfo))
				{
				}
				break;
			case TouchPhase.Ended:
				if (!bButtonClick)
				{
					break;
				}
				if (clickedGameObj != null)
				{
					clickedGameObj.transform.localScale = localScaleVect;
				}
				if (Physics.Raycast(Camera.main.ScreenPointToRay(_pos), out hitInfo) && (vector.x < IGT_UIcommonFunc.ScaleX(260f) || vector.y > IGT_UIcommonFunc.ScaleX(55f)) && hitInfo.transform.name.EndsWith("_mbtn") && clickedGameObj == hitInfo.transform.gameObject)
				{
					nClickedBtnId = int.Parse(sepName(hitInfo.transform.name));
					if (nClickedBtnId <= nBtnUnlockedCnt)
					{
						setClickedPoint(nClickedBtnId);
						buttonClickPoint(nClickedBtnId);
					}
				}
				bButtonClick = false;
				break;
			}
		}
		catch (FormatException ex)
		{
			Debug.Log("FormatException : " + ex.Message);
		}
	}

	public void destroyandReInitGameObj()
	{
		foreach (GameObject item in gameobject_Btn)
		{
			UnityEngine.Object.Destroy(item);
		}
		gameobject_Btn.Clear();
		gameobject_Btn = new List<GameObject>();
		nBtnUnlockedCnt = getUnlockedLevel();
	}

	public void destroyMapBtnObjs()
	{
		if (gameobject_Btn.Count <= 0)
		{
			return;
		}
		foreach (GameObject item in gameobject_Btn)
		{
			UnityEngine.Object.Destroy(item);
		}
		gameobject_Btn.Clear();
	}

	public void deleteMapData()
	{
		sqlliteConn.DeleteAll<SQL_LevelStarCount>();
		sqlliteConn.DropTable<SQL_LevelStarCount>();
	}
}
