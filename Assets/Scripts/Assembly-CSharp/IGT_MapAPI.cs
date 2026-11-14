using System;
using System.Collections.Generic;
using System.IO;
using SQLite4Unity3d;
using UnityEngine;

public class IGT_MapAPI
{
	private GUIStyle lblStyle;

	private string kUnlockedLevelPointPrefs = "keyunlockedlevelpoint";

	private string kCharAnimCurrentPointPrefs = "kCharAnimCurrentPointPrefs";

	private SQLiteConnection sqlliteConn;

	public string sDBName = "StreetChaserMap.db";

	private Vector2 pTouchPos;

	private TouchPhase pTouchPhase;

	private Vector2 vectCharAnimPos;

	private Vector2[] vectPoints;

	private int nNOOFLVLOBJ;

	private int nNoOfLevelsPerScrn;

	private int nNoOfLevels;

	private Rect mapView;

	private Texture2D[] bgImgMaps;

	private Texture2D btnPointImgEnable;

	private Texture2D btnPointImgDisable;

	private Texture2D pStar;

	private Texture2D pStarBg;

	private int nBtnEnableCount;

	private Vector2 touchBeganPos;

	private Vector2 prevPos;

	private Vector2 currPos;

	private Vector2 diffPos;

	private float imgY;

	private int nWidth;

	private int nHeight;

	private int nBtnCnt;

	private int[] ntxt;

	private bool bAnimChar;

	private int nEnable;

	private float fPointWidth;

	private float fPointHeight;

	private float fMapBgWidth;

	private float fMapBgHeight;

	private float fStarWidth;

	private float fStarHeight;

	private float[] fPointX;

	private float[] fPointY;

	private float[] fMapBgY;

	private float[] fPointLvlX;

	private float[,] fPointStarX;

	private float[] fPointStarY;

	private List<int> lstStarCount;

	private int nCharAnimIndex = -1;

	public IGT_MapAPI(Rect _mapViewRect, Vector2[] _points, Texture2D[] _mapBGImages, string _btnPointDActTxt, string _btnPointActTxt, int _noOfLevels, int _noOfBtnsPerScrn)
	{
		setButtonSize(35, 35);
		imgY = 0f;
		setButtonAnimCharInfo(false);
		pStar = Resources.Load<Texture2D>("mapImages/star");
		pStarBg = Resources.Load<Texture2D>("mapImages/bg_star");
		nBtnEnableCount = getUnlockedLevelPoint();
		vectPoints = _points;
		mapView = _mapViewRect;
		bgImgMaps = new Texture2D[_mapBGImages.Length];
		bgImgMaps = _mapBGImages;
		btnPointImgDisable = Resources.Load<Texture2D>("mapImages/" + _btnPointDActTxt);
		btnPointImgEnable = Resources.Load<Texture2D>("mapImages/" + _btnPointActTxt);
		prevPos = default(Vector2);
		currPos = default(Vector2);
		DBSettings(sDBName);
		sqlliteConn.CreateTable<SQL_LevelStarCount>();
		updateNoOFLevels(_noOfBtnsPerScrn, _noOfLevels);
	}

	public void updateNoOFLevels(int _noOfBtnsPerScrn, int _totNoofLevels)
	{
		nNoOfLevelsPerScrn = _noOfBtnsPerScrn;
		nNoOfLevels = _totNoofLevels;
		nNOOFLVLOBJ = (int)Mathf.Ceil((float)nNoOfLevels / (float)nNoOfLevelsPerScrn);
		ntxt = new int[nNOOFLVLOBJ];
		for (int i = 0; i < nNOOFLVLOBJ; i++)
		{
			ntxt[i] = UnityEngine.Random.Range(0, bgImgMaps.Length);
		}
		fMapBgWidth = IGT_UIcommonFunc.ScaleX(mapView.width);
		fMapBgHeight = IGT_UIcommonFunc.ScaleY(mapView.height);
		fStarWidth = IGT_UIcommonFunc.ScaleX(18f);
		fStarHeight = IGT_UIcommonFunc.ScaleY(18f);
		fPointX = new float[nNoOfLevels];
		fMapBgY = new float[nNOOFLVLOBJ];
		fPointY = new float[nNoOfLevels];
		fPointLvlX = new float[nNoOfLevels];
		fPointStarX = new float[nNoOfLevels, 3];
		fPointStarY = new float[nNoOfLevels];
		lstStarCount = new List<int>();
		getLevelStarCount();
		processMapPointsPos();
	}

	public void setButtonSize(int _width, int _height)
	{
		nWidth = _width;
		nHeight = _height;
		fPointWidth = IGT_UIcommonFunc.ScaleX(nWidth);
		fPointHeight = IGT_UIcommonFunc.ScaleX(nHeight);
	}

	public void setButtonAnimCharInfo(bool _isAnimChar, int _nNoofFrameInX = 1, int _nNoofFrameInY = 1, int _spriteWidth = 40)
	{
		bAnimChar = _isAnimChar;
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

	public int getUnlockedLevelPoint()
	{
		return IGT_Preference.getInstance()._Get(kUnlockedLevelPointPrefs, 0);
	}

	public void setUnlockedLevelPoint(int _unlockedLevel)
	{
		IGT_Preference.getInstance()._Set(kCharAnimCurrentPointPrefs, _unlockedLevel);
		if (nBtnEnableCount <= _unlockedLevel)
		{
			nBtnEnableCount = _unlockedLevel;
			IGT_Preference.getInstance()._Set(kUnlockedLevelPointPrefs, nBtnEnableCount);
		}
	}

	public void setDefaultUnlockedLevelPoint()
	{
		sqlliteConn.DropTable<SQL_LevelStarCount>();
		sqlliteConn.CreateTable<SQL_LevelStarCount>();
		nBtnEnableCount = 0;
		IGT_Preference.getInstance()._Set(kUnlockedLevelPointPrefs, nBtnEnableCount);
	}

	public void updateMap(Vector2 _touchPos, TouchPhase _touchPhase, Action<int> buttonClickPoint)
	{
		pTouchPos = _touchPos;
		pTouchPhase = _touchPhase;
		Rect rect = new Rect
		{
			x = IGT_UIcommonFunc.ScaleX(mapView.x),
			y = IGT_UIcommonFunc.ScaleY(mapView.y),
			width = IGT_UIcommonFunc.ScaleX(mapView.width),
			height = IGT_UIcommonFunc.ScaleY(mapView.height)
		};
		if (rect.Contains(new Vector2(pTouchPos.x, (float)Screen.height - pTouchPos.y)) && pTouchPhase != TouchPhase.Stationary)
		{
			if (pTouchPhase == TouchPhase.Began)
			{
				prevPos = pTouchPos;
				touchBeganPos = pTouchPos;
			}
			else if (pTouchPhase == TouchPhase.Moved)
			{
				currPos = pTouchPos;
				diffPos.x = currPos.x - prevPos.x;
				diffPos.y = 0.5f * IGT_UIcommonFunc.reScaleY((float)Screen.height - currPos.y - ((float)Screen.height - prevPos.y));
				prevPos = currPos;
			}
			else if (pTouchPhase == TouchPhase.Ended)
			{
				currPos = pTouchPos;
				diffPos.x = currPos.x - prevPos.x;
				diffPos.y = 1f * IGT_UIcommonFunc.reScaleY((float)Screen.height - currPos.y - ((float)Screen.height - prevPos.y));
			}
			imgY += diffPos.y;
			if (imgY < 0f)
			{
				imgY = 0f;
			}
			if (imgY > (float)(nNOOFLVLOBJ - 1) * mapView.height)
			{
				imgY = (float)(nNOOFLVLOBJ - 1) * mapView.height;
			}
			if (pTouchPhase == TouchPhase.Ended)
			{
				calculateClickPoint(buttonClickPoint);
			}
			processMapPointsPos();
		}
	}

	private void processMapPointsPos()
	{
		for (int i = 0; i < nNOOFLVLOBJ; i++)
		{
			fMapBgY[i] = IGT_UIcommonFunc.ScaleY(calculateScrolDistance()) - fMapBgHeight * (float)i;
			for (int j = 0; j < nNoOfLevelsPerScrn; j++)
			{
				int num = nNoOfLevelsPerScrn * i + j;
				if (num < nNoOfLevels)
				{
					fPointX[num] = processPosX(j);
					fPointY[num] = processPosY(i, j);
					fPointLvlX[num] = processStarPosX(j, 10);
					int num2 = 12;
					for (int k = 0; k < 3; k++)
					{
						fPointStarX[num, k] = processStarPosX(j, num2 * k);
					}
					fPointStarY[num] = processStarPosY(i, j, -18);
				}
			}
		}
	}

	private void calculateClickPoint(Action<int> buttonClickPoint)
	{
		if (!(touchBeganPos.x <= pTouchPos.x) || !(touchBeganPos.x + fPointWidth >= pTouchPos.x) || !(touchBeganPos.y <= pTouchPos.y) || !(touchBeganPos.y + fPointHeight >= pTouchPos.y))
		{
			return;
		}
		for (int i = 0; i < nNOOFLVLOBJ; i++)
		{
			for (int j = 0; j < nNoOfLevelsPerScrn; j++)
			{
				if (!(pTouchPos.x >= processPosX(j)) || !(pTouchPos.x <= processPosX(j) + fPointWidth))
				{
					continue;
				}
				float num = (float)Screen.height - pTouchPos.y;
				if (!(num >= processPosY(i, j)) || !(num <= processPosY(i, j) + fPointHeight))
				{
					continue;
				}
				int num2 = nNoOfLevelsPerScrn * i + j;
				if (num2 < nEnable)
				{
					if (bAnimChar)
					{
						IGT_Preference.getInstance()._Set(kCharAnimCurrentPointPrefs, num2);
					}
					buttonClickPoint(num2);
				}
			}
		}
	}

	private float calculateScrolDistance()
	{
		return mapView.height - mapView.height + imgY;
	}

	private float processPosX(int idx)
	{
		return IGT_UIcommonFunc.ScaleX(vectPoints[idx].x);
	}

	private float processPosY(int idxI, int idxJ)
	{
		return IGT_UIcommonFunc.ScaleY(mapView.height - vectPoints[idxJ].y - (float)nHeight + calculateScrolDistance()) - IGT_UIcommonFunc.ScaleY(mapView.height) * (float)idxI + (float)idxJ;
	}

	public void drawMap()
	{
		GUI.BeginScrollView(new Rect(IGT_UIcommonFunc.ScaleX(mapView.x), IGT_UIcommonFunc.ScaleY(mapView.y), IGT_UIcommonFunc.ScaleX(mapView.width), IGT_UIcommonFunc.ScaleY(mapView.height)), mapView.position, default(Rect));
		drawMapItemsOnScrollView();
		GUI.EndScrollView();
	}

	public void drawMapItemsOnScrollView()
	{
		nEnable = 0;
		nBtnCnt = 1;
		for (int i = 0; i < nNoOfLevels; i++)
		{
			if (i < nNOOFLVLOBJ)
			{
				GUI.DrawTexture(new Rect(0f, fMapBgY[i], fMapBgWidth, fMapBgHeight), bgImgMaps[0]);
			}
			if (nBtnEnableCount >= nEnable)
			{
				GUI.DrawTexture(new Rect(fPointX[i], fPointY[i], fPointWidth, fPointHeight), btnPointImgEnable);
				drawLabelLevelInfo(i);
				drawStarCalculations(i);
				nEnable++;
			}
			else
			{
				GUI.DrawTexture(new Rect(fPointX[i], fPointY[i], fPointWidth, fPointHeight), btnPointImgDisable);
			}
			if (bAnimChar && nBtnEnableCount < nEnable)
			{
				if (nCharAnimIndex == -1)
				{
					IGT_Preference.getInstance()._Set(kCharAnimCurrentPointPrefs, i);
				}
				nCharAnimIndex = IGT_Preference.getInstance()._Get(kCharAnimCurrentPointPrefs, 0);
				vectCharAnimPos.x = fPointX[nCharAnimIndex];
				vectCharAnimPos.y = fPointY[nCharAnimIndex];
			}
		}
	}

	private void drawLabelLevelInfo(int _idxI)
	{
		if (lblStyle == null)
		{
			lblStyle = new GUIStyle();
		}
		lblStyle.fontSize = (int)IGT_UIcommonFunc.ScaleX(16f);
		lblStyle.fontStyle = FontStyle.BoldAndItalic;
		lblStyle.normal.textColor = Color.black;
		GUI.Label(new Rect(fPointLvlX[_idxI], fPointY[_idxI], fPointWidth, fPointHeight), string.Empty + nBtnCnt++, lblStyle);
	}

	private void touchTestDraw()
	{
		if (pTouchPhase == TouchPhase.Ended)
		{
			if (lblStyle == null)
			{
				lblStyle = new GUIStyle();
			}
			lblStyle.fontSize = (int)IGT_UIcommonFunc.ScaleX(34f);
			lblStyle.fontStyle = FontStyle.BoldAndItalic;
			lblStyle.normal.textColor = Color.red;
			GUI.Label(new Rect(pTouchPos.x, (float)Screen.height - pTouchPos.y, fPointWidth, fPointHeight), "X", lblStyle);
		}
	}

	public void dropLevelStarTable()
	{
		sqlliteConn.DropTable<SQL_LevelStarCount>();
	}

	public void insertLevelStarData(int _LevelNo, int _LevelStar)
	{
		string query = "update SQL_LevelStarCount set LevelStarCount =" + _LevelStar + " where LevelID =" + _LevelNo + " and LevelStarCount < " + _LevelStar;
		if (sqlliteConn.SQLitePassByQuery(query) <= 0)
		{
			try
			{
				sqlliteConn.Insert(new SQL_LevelStarCount
				{
					LevelID = _LevelNo,
					LevelStarCount = _LevelStar
				});
			}
			catch (SQLiteException ex)
			{
				Debug.Log("Excep:" + ex.Message);
			}
		}
		getLevelStarCount();
	}

	private void getLevelStarCount()
	{
		TableQuery<SQL_LevelStarCount> tableQuery = sqlliteConn.Table<SQL_LevelStarCount>();
		foreach (SQL_LevelStarCount item in tableQuery)
		{
			lstStarCount.Add(item.LevelStarCount);
		}
	}

	private void drawStarCalculations(int _idx)
	{
		for (int i = 0; i < 3; i++)
		{
			if (lstStarCount.Count > _idx && lstStarCount[_idx] >= i + 1 && lstStarCount[_idx] > 0)
			{
				GUI.DrawTexture(new Rect(fPointStarX[_idx, i], fPointStarY[_idx], fStarWidth, fStarHeight), pStar);
			}
			else
			{
				GUI.DrawTexture(new Rect(fPointStarX[_idx, i], fPointStarY[_idx], fStarWidth, fStarHeight), pStarBg);
			}
		}
	}

	private float processStarPosX(int idx, int _starPos)
	{
		return IGT_UIcommonFunc.ScaleX(vectPoints[idx].x + (float)_starPos);
	}

	private float processStarPosY(int idxI, int idxJ, int _starPosAdj)
	{
		return IGT_UIcommonFunc.ScaleY(mapView.height - vectPoints[idxJ].y - (float)nHeight + calculateScrolDistance()) - IGT_UIcommonFunc.ScaleY(mapView.height) * (float)idxI + (float)idxJ + IGT_UIcommonFunc.ScaleY(_starPosAdj);
	}

	private void drawCharPointMoveAnim()
	{
	}
}
