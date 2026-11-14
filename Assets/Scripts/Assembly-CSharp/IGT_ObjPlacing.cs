using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IGT_ObjPlacing : MonoBehaviour
{
	public static GameObject coin;

	public static GameObject coin_2x;

	public static GameObject coin_3x;

	public static GameObject Anim_coin;

	public static GameObject Anim_coin_2x;

	public static GameObject Anim_coin_3x;

	public static GameObject Bag;

	public static GameObject Suitcase;

	public static GameObject kick_Football_White;

	public static GameObject kick_Football_Yellow;

	public static GameObject kick_Rugby_Blue;

	public static GameObject Kick_Rugby_Brown;

	public static GameObject Throw_Bottle;

	public static GameObject Throw_BottleCrackAnim;

	public static GameObject Three_laneBlock_Orange;

	public static GameObject Three_laneBlock_Red;

	public static GameObject Single_LaneJump_Red;

	public static GameObject Single_LaneJump_Orange;

	public static GameObject Three_laneSlide_Red;

	public static GameObject Three_laneSlide_Orange;

	public static GameObject Three_laneSlide1_Red;

	public static GameObject Three_laneSlide1_Orange;

	public static GameObject Single_LaneSlide_Red;

	public static GameObject Single_LaneSlide_Orange;

	public static GameObject Two_LaneSlide;

	public static GameObject Single_LaneBlock_Barrel_B;

	public static GameObject Single_LaneBlock_Barrel_R;

	public static GameObject Single_LaneBlock_R;

	public static GameObject Single_LaneBlock_O;

	public static GameObject spl_MagnetYellow;

	public static GameObject spl_PotionGreen;

	public static GameObject spl_PotionBig;

	public static GameObject spl_Coin_2x;

	public static GameObject spl_Coin_3x;

	public static GameObject spl_Bomb;

	public static GameObject spl_Trap;

	public static GameObject spl_Auto;

	public static GameObject spl_SpdInc;

	public static GameObject spl_SpdDec;

	public static GameObject coll_Diamond;

	public static GameObject coll_Necklace;

	public static GameObject coll_Necklace1;

	public static GameObject coll_Necklace2;

	public static GameObject coll_Chain;

	public static GameObject coll_Ring;

	public static GameObject coll_Hat;

	public static GameObject coll_Cooler;

	public static GameObject EndWall;

	public static GameObject Glow_Spin;

	public static GameObject BB_DestinationArea;

	public static GameObject[] Alphabetics_Gameobjects = new GameObject[26];

	public static int[] Alphabetics = new int[26];

	public static GameObject prefab = null;

	public static List<GameObject> dynObjList = new List<GameObject>();

	public static List<GameObject> Coin_PlacingList = new List<GameObject>();

	public static List<GameObject> missionObjInstanceList = new List<GameObject>();

	public static List<GameObject> splPowersInstanceList = new List<GameObject>();

	public static List<GameObject> GlowInstanceList = new List<GameObject>();

	public static void objInstantiating()
	{
		Vector3 position = new Vector3(300f, -100f, 300f);
		kick_Football_White = Object.Instantiate(Resources.Load("Objects/Kick_FootBall-white"), position, Quaternion.identity) as GameObject;
		kick_Football_Yellow = Object.Instantiate(Resources.Load("Objects/Kick_FootBall-yellow"), position, Quaternion.identity) as GameObject;
		kick_Rugby_Blue = Object.Instantiate(Resources.Load("Objects/Kick_Rugby-blue"), position, Quaternion.identity) as GameObject;
		Kick_Rugby_Brown = Object.Instantiate(Resources.Load("Objects/Kick_Rugby-brown"), position, Quaternion.identity) as GameObject;
		Throw_Bottle = Object.Instantiate(Resources.Load("Objects/Throw_Bottle"), position, Quaternion.identity) as GameObject;
		Throw_BottleCrackAnim = Object.Instantiate(Resources.Load("Objects/Throw_BottleCrackAnim"), position, Quaternion.identity) as GameObject;
		Three_laneBlock_Orange = Object.Instantiate(Resources.Load("Objects/3_laneBlock_O"), position, Quaternion.identity) as GameObject;
		Three_laneBlock_Red = Object.Instantiate(Resources.Load("Objects/3_laneBlock_R"), position, Quaternion.identity) as GameObject;
		Single_LaneJump_Red = Object.Instantiate(Resources.Load("Objects/1_LaneJump_R"), position, Quaternion.identity) as GameObject;
		Single_LaneJump_Orange = Object.Instantiate(Resources.Load("Objects/1_LaneJump_O"), position, Quaternion.identity) as GameObject;
		Three_laneSlide_Red = Object.Instantiate(Resources.Load("Objects/3_laneSlide_R"), position, Quaternion.identity) as GameObject;
		Three_laneSlide_Orange = Object.Instantiate(Resources.Load("Objects/3_laneSlide_O"), position, Quaternion.identity) as GameObject;
		Three_laneSlide1_Red = Object.Instantiate(Resources.Load("Objects/3_laneSlide1_R"), position, Quaternion.identity) as GameObject;
		Three_laneSlide1_Orange = Object.Instantiate(Resources.Load("Objects/3_laneSlide1_O"), position, Quaternion.identity) as GameObject;
		Single_LaneSlide_Red = Object.Instantiate(Resources.Load("Objects/1_LaneSlide_R"), position, Quaternion.identity) as GameObject;
		Single_LaneSlide_Orange = Object.Instantiate(Resources.Load("Objects/1_LaneSlide_O"), position, Quaternion.identity) as GameObject;
		Two_LaneSlide = Object.Instantiate(Resources.Load("Objects/2_LaneSlide"), position, Quaternion.identity) as GameObject;
		Single_LaneBlock_Barrel_B = Object.Instantiate(Resources.Load("Objects/1_LaneBlock_Barrel_B"), position, Quaternion.identity) as GameObject;
		Single_LaneBlock_Barrel_R = Object.Instantiate(Resources.Load("Objects/1_LaneBlock_Barrel_R"), position, Quaternion.identity) as GameObject;
		Single_LaneBlock_R = Object.Instantiate(Resources.Load("Objects/1_LaneBlock_R"), position, Quaternion.identity) as GameObject;
		Single_LaneBlock_O = Object.Instantiate(Resources.Load("Objects/1_LaneBlock_O"), position, Quaternion.identity) as GameObject;
		spl_MagnetYellow = Object.Instantiate(Resources.Load("Objects/spl_MagnetYellow"), position, Quaternion.identity) as GameObject;
		spl_PotionGreen = Object.Instantiate(Resources.Load("Objects/spl_MedPlus"), position, Quaternion.identity) as GameObject;
		spl_PotionBig = Object.Instantiate(Resources.Load("Objects/spl_MedKit"), position, Quaternion.identity) as GameObject;
		spl_Bomb = Object.Instantiate(Resources.Load("Objects/spl_Bomb"), position, Quaternion.identity) as GameObject;
		spl_Trap = Object.Instantiate(Resources.Load("Objects/spl_Trap"), position, Quaternion.identity) as GameObject;
		spl_Auto = Object.Instantiate(Resources.Load("Objects/spl_Auto"), position, Quaternion.identity) as GameObject;
		spl_SpdInc = Object.Instantiate(Resources.Load("Objects/spl_SpdInc"), position, Quaternion.identity) as GameObject;
		spl_SpdDec = Object.Instantiate(Resources.Load("Objects/spl_SpdDec"), position, Quaternion.identity) as GameObject;
		coll_Diamond = Object.Instantiate(Resources.Load("Objects/col_Dimond"), position, Quaternion.identity) as GameObject;
		coll_Necklace = Object.Instantiate(Resources.Load("Objects/col_Carcanet"), position, Quaternion.identity) as GameObject;
		coll_Necklace1 = Object.Instantiate(Resources.Load("Objects/col_Torc"), position, Quaternion.identity) as GameObject;
		coll_Necklace2 = Object.Instantiate(Resources.Load("Objects/col_Necklaces"), position, Quaternion.identity) as GameObject;
		coll_Chain = Object.Instantiate(Resources.Load("Objects/col_Chain"), position, Quaternion.identity) as GameObject;
		coll_Cooler = Object.Instantiate(Resources.Load("Objects/col_Cooler"), position, Quaternion.identity) as GameObject;
		coll_Ring = Object.Instantiate(Resources.Load("Objects/col_Ring"), position, Quaternion.identity) as GameObject;
		coll_Hat = Object.Instantiate(Resources.Load("Objects/col_Hat"), position, Quaternion.identity) as GameObject;
		Bag = Object.Instantiate(Resources.Load("Objects/Bag"), position, Quaternion.identity) as GameObject;
		Bag.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		Suitcase = Object.Instantiate(Resources.Load("Objects/suitcase"), position, Quaternion.identity) as GameObject;
		Suitcase.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		EndWall = Object.Instantiate(Resources.Load("Objects/EndWall"), position, Quaternion.identity) as GameObject;
		BB_DestinationArea = Object.Instantiate(Resources.Load("Objects/BB_Destination"), position, Quaternion.identity) as GameObject;
		Glow_Spin = Object.Instantiate(Resources.Load("Objects/Glow_Spin"), position, Quaternion.identity) as GameObject;
		load_CoinDatas();
		loadAllAlphabetics();
	}

	public static void objPlaceAtRuntime(ref List<IGT_ObjInfo> objData)
	{
		for (int i = 0; i < objData.Count; i++)
		{
			if (objData[i].objPlaceType == 0)
			{
				continue;
			}
			switch (objData[i].objID)
			{
			case 100:
				prefab = Three_laneBlock_Orange;
				break;
			case 101:
				prefab = Three_laneBlock_Red;
				break;
			case 102:
				prefab = Single_LaneJump_Red;
				break;
			case 103:
				prefab = Single_LaneJump_Orange;
				break;
			case 200:
				prefab = Three_laneSlide_Red;
				break;
			case 201:
				prefab = Three_laneSlide_Orange;
				break;
			case 202:
				prefab = Three_laneSlide1_Red;
				break;
			case 203:
				prefab = Three_laneSlide1_Orange;
				break;
			case 204:
				prefab = Single_LaneSlide_Red;
				break;
			case 205:
				prefab = Single_LaneSlide_Orange;
				break;
			case 206:
				prefab = Two_LaneSlide;
				break;
			case 605:
				prefab = Single_LaneBlock_Barrel_B;
				break;
			case 606:
				prefab = Single_LaneBlock_Barrel_R;
				break;
			case 607:
				prefab = Single_LaneBlock_R;
				break;
			case 608:
				prefab = Single_LaneBlock_O;
				break;
			case 500:
				prefab = Kick_Rugby_Brown;
				break;
			case 501:
				prefab = kick_Football_White;
				break;
			case 502:
				prefab = kick_Football_Yellow;
				break;
			case 503:
				prefab = kick_Rugby_Blue;
				break;
			case 700:
				prefab = Throw_Bottle;
				break;
			case 400:
				prefab = IGT_MovingObjPlacing.Car_Cop;
				break;
			case 401:
				prefab = IGT_MovingObjPlacing.Car_FoodVan;
				break;
			case 402:
				prefab = IGT_MovingObjPlacing.Car_Taxi;
				break;
			case 403:
				prefab = IGT_MovingObjPlacing.Car_IceVan;
				break;
			}
			dynObjList.Add(Object.Instantiate(prefab, new Vector3(objData[i].ObjPos.x, objData[i].ObjPos.y, objData[i].ObjPos.z), Quaternion.Euler(0f, objData[i].objRot.z, 0f)));
			dynObjList.ElementAt(i).layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
			dynObjList[i].name = objData[i].objID.ToString();
			if (objData[i].objType != 6 && objData[i].objType != 4)
			{
				dynObjList[i].tag = IGT_Constants.Tag_DynamicObj;
			}
			if (objData[i].objType == 3)
			{
				dynObjList[i].AddComponent<AudioSource>();
				if (IGT_GameView.pHero.nSound == 0)
				{
					if (objData[i].objID == 401 || objData[i].objID == 402)
					{
						dynObjList[i].GetComponent<AudioSource>().clip = IGT_GameView.pHero._AudioClips[17];
						dynObjList[i].GetComponent<AudioSource>().volume = 0.6f;
					}
					else if (objData[i].objID == 400)
					{
						dynObjList[i].GetComponent<AudioSource>().clip = IGT_GameView.pHero._AudioClips[20];
						dynObjList[i].GetComponent<AudioSource>().volume = 0.2f;
					}
					else
					{
						dynObjList[i].GetComponent<AudioSource>().clip = IGT_GameView.pHero._AudioClips[19];
						dynObjList[i].GetComponent<AudioSource>().volume = 0.6f;
					}
					dynObjList[i].GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
					dynObjList[i].GetComponent<AudioSource>().playOnAwake = false;
					dynObjList[i].GetComponent<AudioSource>().spatialBlend = 1f;
					dynObjList[i].GetComponent<AudioSource>().minDistance = 4f;
					dynObjList[i].GetComponent<AudioSource>().maxDistance = 6f;
					dynObjList[i].GetComponent<AudioSource>().loop = true;
					dynObjList[i].GetComponent<AudioSource>().Play();
				}
			}
			if (dynObjList[i].GetComponent<BoxCollider>() == null)
			{
				dynObjList[i].AddComponent<BoxCollider>();
			}
			if (IGT_Objects.ThrowObj_Placed_Pos == objData[i].ObjPos)
			{
				IGT_Objects.PickedObj_InstanceID = i;
			}
		}
	}

	public static void objDestruction()
	{
		foreach (GameObject dynObj in dynObjList)
		{
			if (dynObj != null && (dynObj.tag == IGT_Constants.Tag_ThrowObj || dynObj.tag == IGT_Constants.Tag_KickObj) && dynObj.GetComponent<Rigidbody>() != null && dynObj.GetComponent<Rigidbody>().velocity != Vector3.zero)
			{
				if ((IGT_Objects.PickedObj_InstanceID != -1 && IGT_Objects.ThrowObj_Placed_Pos != Vector3.zero) || IGT_Objects.kickObj_InstanceID != -1)
				{
					Object.Destroy(dynObj, 5f);
				}
			}
			else
			{
				Object.Destroy(dynObj);
			}
		}
		dynObjList.Clear();
		if (IGT_SurpriseAIplayer.SurpriseAI == null || (IGT_SurpriseAIplayer.SurpriseAI != null && IGT_SurpriseAIplayer.playerAction != 1))
		{
			Object.Destroy(GameObject.Find(IGT_Constants.SurpriseAIplayer + IGT_Constants.Tag_ThrowObj));
		}
	}

	public static void CollectionItemPlacing(ref List<IGT_ObjInfo> objData)
	{
		for (int i = 0; i < objData.Count; i++)
		{
			switch (objData[i].objID)
			{
			case 0:
				if (IGT_GameView.pHero.bCoin_2x)
				{
					prefab = coin_2x;
				}
				else if (IGT_GameView.pHero.bCoin_3x)
				{
					prefab = coin_3x;
				}
				else
				{
					prefab = coin;
				}
				break;
			case 1:
				prefab = coll_Diamond;
				break;
			case 6:
				prefab = coll_Necklace;
				break;
			case 7:
				prefab = coll_Necklace1;
				break;
			case 8:
				prefab = coll_Necklace2;
				break;
			case 2:
				prefab = coll_Chain;
				break;
			case 3:
				prefab = coll_Ring;
				break;
			case 5:
				prefab = coll_Cooler;
				break;
			case 4:
				prefab = coll_Hat;
				break;
			}
			missionObjInstanceList.Add(Object.Instantiate(prefab, new Vector3(objData[i].ObjPos.x, objData[i].ObjPos.y + objData[i].fHeight / 2f, objData[i].ObjPos.z), Quaternion.Euler(0f, objData[i].objRot.z, 0f)));
			if (objData[i].objID != 0)
			{
				missionObjInstanceList.ElementAt(i).name = objData[i].objID.ToString();
				missionObjInstanceList.ElementAt(i).tag = IGT_Constants.Tag_CollectionObj;
				missionObjInstanceList.ElementAt(i).layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
				if (missionObjInstanceList.ElementAt(i).GetComponent<BoxCollider>() == null)
				{
					missionObjInstanceList.ElementAt(i).AddComponent<BoxCollider>();
				}
				missionObjInstanceList.ElementAt(i).GetComponent<BoxCollider>().size = new Vector3(missionObjInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.x * 2f, missionObjInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.y, missionObjInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.z);
				if (objData[i].objID == 6 || objData[i].objID == 8 || objData[i].objID == 7 || objData[i].objID == 2)
				{
					if (missionObjInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>() == null)
					{
						missionObjInstanceList.ElementAt(i).AddComponent<IGT_CoinRotation>().RotateSpeed += Random.Range(5, 10);
					}
				}
				else if (missionObjInstanceList.ElementAt(i).GetComponent<IGT_ObjBouncing>() == null)
				{
					missionObjInstanceList.ElementAt(i).AddComponent<IGT_ObjBouncing>();
				}
			}
			else
			{
				missionObjInstanceList.ElementAt(i).name = "MissionCoins";
			}
		}
	}

	public static void collectionItemsDestruction()
	{
		foreach (GameObject missionObjInstance in missionObjInstanceList)
		{
			Object.Destroy(missionObjInstance);
		}
		missionObjInstanceList.Clear();
	}

	public static void splPowersobjDestruction()
	{
		foreach (GameObject splPowersInstance in splPowersInstanceList)
		{
			Object.Destroy(splPowersInstance);
		}
		splPowersInstanceList.Clear();
		glowObjDestruction();
	}

	public static void splPowersPlacing(ref List<IGT_ObjInfo> objData)
	{
		for (int i = 0; i < objData.Count; i++)
		{
			switch (objData[i].objID)
			{
			case 900:
				prefab = spl_MagnetYellow;
				break;
			case 901:
				prefab = spl_PotionGreen;
				break;
			case 902:
				prefab = spl_PotionBig;
				break;
			case 903:
				prefab = spl_Coin_2x;
				break;
			case 904:
				prefab = spl_Coin_3x;
				break;
			case 905:
				prefab = spl_Bomb;
				break;
			case 906:
				prefab = spl_Trap;
				break;
			case 907:
				prefab = spl_Auto;
				break;
			case 908:
				prefab = spl_SpdInc;
				break;
			case 909:
				prefab = spl_SpdDec;
				break;
			}
			splPowersInstanceList.Add(Object.Instantiate(prefab, new Vector3(objData[i].ObjPos.x, objData[i].ObjPos.y + objData[i].fHeight / 2f, objData[i].ObjPos.z), Quaternion.Euler(0f, objData[i].objRot.z, 0f)));
			splPowersInstanceList.ElementAt(i).name = objData[i].objID.ToString();
			splPowersInstanceList.ElementAt(i).tag = IGT_Constants.Tag_SplPowers;
			splPowersInstanceList.ElementAt(i).layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
			if (splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>() == null)
			{
				splPowersInstanceList.ElementAt(i).AddComponent<BoxCollider>();
			}
			if (objData[i].objID == 905)
			{
				addGlow(objData[i].ObjPos, objData[i].objRot, objData[i].fHeight);
				splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size = new Vector3(splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.x, 0.5f, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.z);
			}
			else if (objData[i].objID == 901)
			{
				splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size = new Vector3(0.003f, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.y, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.z);
			}
			else if (objData[i].objID == 909)
			{
				splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size = new Vector3(0.0035f, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.y, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.z);
			}
			else if (objData[i].objID == 907)
			{
				splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size = new Vector3(0.0025f, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.y, splPowersInstanceList.ElementAt(i).GetComponent<BoxCollider>().size.z);
			}
		}
		splPowersAnimation(objData);
	}

	public static void splPowersAnimation(List<IGT_ObjInfo> objData)
	{
		for (int i = 0; i < objData.Count; i++)
		{
			if (objData[i].objID == 900 || objData[i].objID == 901)
			{
				if (splPowersInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>() == null)
				{
					splPowersInstanceList.ElementAt(i).AddComponent<IGT_CoinRotation>();
				}
				splPowersInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>().RotateSpeed = 18f;
			}
			else if ((objData[i].objID == 902 || objData[i].objID == 907 || objData[i].objID == 908 || objData[i].objID == 909 || objData[i].objID == 905 || objData[i].objID == 903 || objData[i].objID == 904) && splPowersInstanceList.ElementAt(i).GetComponent<IGT_ObjBouncing>() == null)
			{
				splPowersInstanceList.ElementAt(i).AddComponent<IGT_ObjBouncing>();
			}
		}
	}

	private static void load_CoinDatas()
	{
		Vector3 position = new Vector3(300f, -100f, 300f);
		coin = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		coin.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		coin.tag = IGT_Constants.Tag_Coin;
		coin.AddComponent<IGT_CoinRotation>();
		coin.AddComponent<Rigidbody>().useGravity = false;
		coin.AddComponent<CapsuleCollider>().isTrigger = true;
		coin.GetComponent<CapsuleCollider>().height = 0.005f;
		coin_2x = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		coin_2x.GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + "Coin_2x", typeof(Texture));
		coin_2x.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		coin_2x.tag = IGT_Constants.Tag_Coin;
		coin_2x.AddComponent<IGT_CoinRotation>();
		coin_2x.AddComponent<Rigidbody>().useGravity = false;
		coin_2x.AddComponent<CapsuleCollider>().isTrigger = true;
		coin_2x.GetComponent<CapsuleCollider>().height = 0.005f;
		coin_3x = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		coin_3x.GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + "Coin_3x", typeof(Texture));
		coin_3x.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		coin_3x.tag = IGT_Constants.Tag_Coin;
		coin_3x.AddComponent<IGT_CoinRotation>();
		coin_3x.AddComponent<Rigidbody>().useGravity = false;
		coin_3x.AddComponent<CapsuleCollider>().isTrigger = true;
		coin_3x.GetComponent<CapsuleCollider>().height = 0.005f;
		Anim_coin = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		Anim_coin_2x = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		Anim_coin_2x.GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + "Coin_2x", typeof(Texture));
		Anim_coin_3x = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		Anim_coin_3x.GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + "Coin_3x", typeof(Texture));
		spl_Coin_2x = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		spl_Coin_2x.GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + "Coin2X_Multiplier", typeof(Texture));
		spl_Coin_2x.transform.localScale = new Vector3(200f, 200f, 200f);
		spl_Coin_3x = Object.Instantiate(Resources.Load("Objects/coin"), position, Quaternion.identity) as GameObject;
		spl_Coin_3x.GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + "Coin3X_Multiplier", typeof(Texture));
		spl_Coin_3x.transform.localScale = new Vector3(200f, 200f, 200f);
	}

	private static void loadAllAlphabetics()
	{
		int num = 0;
		for (int i = 65; i <= 90; i++)
		{
			GameObject letterPrefab = Resources.Load<GameObject>(IGT_Constants.Path_Alphabetics + (char)i);
			if (letterPrefab == null)
			{
				letterPrefab = Resources.Load<GameObject>("Objects/Dimond");
			}
			if (letterPrefab == null)
			{
				letterPrefab = new GameObject("Letter_" + (char)i);
			}
			Alphabetics_Gameobjects[num] = Object.Instantiate(letterPrefab, new Vector3(300f, -100f, 300f), Quaternion.identity) as GameObject;
			if (Alphabetics_Gameobjects[num] != null)
			{
				Alphabetics_Gameobjects[num].layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
			}
			Alphabetics[num] = i;
			num++;
		}
	}

	public static void wordPlacing(ref List<IGT_ObjInfo> objData)
	{
		foreach (GameObject missionObjInstance in missionObjInstanceList)
		{
			Object.Destroy(missionObjInstance);
		}
		missionObjInstanceList.Clear();
		for (int i = 0; i < objData.Count; i++)
		{
			missionObjInstanceList.Add(Object.Instantiate(Alphabetics_Gameobjects[objData[i].objID], new Vector3(objData[i].ObjPos.x, objData[i].ObjPos.y + objData[i].fHeight / 2f, objData[i].ObjPos.z), Quaternion.Euler(0f, objData[i].objRot.z, 0f)));
			missionObjInstanceList.ElementAt(i).name = ((char)Alphabetics[objData[i].objID]/*cast due to .constrained prefix*/).ToString();
			missionObjInstanceList.ElementAt(i).tag = IGT_Constants.Tag_Letter;
			missionObjInstanceList.ElementAt(i).layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
			if (missionObjInstanceList.ElementAt(i).GetComponent<BoxCollider>() == null)
			{
				missionObjInstanceList.ElementAt(i).AddComponent<BoxCollider>();
			}
			if (missionObjInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>() == null)
			{
				missionObjInstanceList.ElementAt(i).AddComponent<IGT_CoinRotation>();
			}
			missionObjInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>().RotateSpeed = 20f;
		}
	}

	public static void Coin_Placing(ref List<IGT_ObjInfo> CoinsDatas)
	{
		for (int i = 0; i < CoinsDatas.Count; i++)
		{
			if (CoinsDatas[i].nPathId == IGT_GameView.pHero.PlayerObj.currentPathIndex)
			{
				float num = CoinsDatas[i].fDistFrmStrtPnt;
				if (IGT_GameView.pHero.PlayerObj.bTraverseReverse)
				{
					num = IGT_GameView.pHero.PlayerObj.pathLength[IGT_GameView.pHero.PlayerObj.currentPathIndex] - num;
				}
				if (num < IGT_GameView.pHero.PlayerObj.fDistFrmStrtPnt + 0.5f)
				{
					continue;
				}
			}
			if (IGT_GameView.pHero.bCoin_2x)
			{
				prefab = coin_2x;
			}
			else if (IGT_GameView.pHero.bCoin_3x)
			{
				prefab = coin_3x;
			}
			else
			{
				prefab = coin;
			}
			Coin_PlacingList.Add(Object.Instantiate(prefab, new Vector3(CoinsDatas[i].ObjPos.x, CoinsDatas[i].ObjPos.y + CoinsDatas[i].fHeight, CoinsDatas[i].ObjPos.z), Quaternion.Euler(0f, CoinsDatas[i].objRot.z, 0f)));
		}
	}

	public static void Coin_Destruction()
	{
		foreach (GameObject coin_Placing in Coin_PlacingList)
		{
			Object.Destroy(coin_Placing);
		}
		Coin_PlacingList.Clear();
	}

	public static void Rotate_CollectionItems_Coins()
	{
		float num = 60f;
		float num3;
		float num2 = (num3 = 30f);
		for (int i = 0; i < missionObjInstanceList.Count; i++)
		{
			if (missionObjInstanceList.ElementAt(i) != null && missionObjInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>() != null)
			{
				IGT_CoinRotation component = missionObjInstanceList.ElementAt(i).GetComponent<IGT_CoinRotation>();
				component.RotateSpeed += num2;
				num2 += 2f;
				if (num2 > num)
				{
					num2 = num3;
				}
			}
		}
	}

	public static void Rotation_Coin()
	{
		float num = 60f;
		float num3;
		float num2 = (num3 = 30f);
		for (int i = 0; i < Coin_PlacingList.Count; i++)
		{
			if (Coin_PlacingList.ElementAt(i) != null && Coin_PlacingList.ElementAt(i).GetComponent<IGT_CoinRotation>() != null)
			{
				IGT_CoinRotation component = Coin_PlacingList.ElementAt(i).GetComponent<IGT_CoinRotation>();
				component.RotateSpeed += num2;
				num2 += 2f;
				if (num2 > num)
				{
					num2 = num3;
				}
			}
		}
	}

	public static void Change_CoinTexture(int idx)
	{
		string text = "Coin";
		switch (idx)
		{
		case 2:
			text = "Coin_2x";
			break;
		case 3:
			text = "Coin_3x";
			break;
		default:
			text = "Coin";
			break;
		}
		for (int i = 0; i < Coin_PlacingList.Count; i++)
		{
			if (Coin_PlacingList.ElementAt(i) != null)
			{
				Coin_PlacingList.ElementAt(i).GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + text, typeof(Texture));
			}
		}
		if (IGT_GameView.pHero.nGameMode != 1 || IGT_GameView.pHero.pMissionData.nMissionType != 0 || IGT_GameView.pHero.pMissionData.nCollectionInnerItemType != 0)
		{
			return;
		}
		for (int j = 0; j < missionObjInstanceList.Count; j++)
		{
			if (missionObjInstanceList.ElementAt(j) != null)
			{
				missionObjInstanceList.ElementAt(j).GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load(IGT_Constants.Path_ObjTextures + text, typeof(Texture));
			}
		}
	}

	public static void addGlow(Vector3 position, Vector3 rotation, float height)
	{
		GameObject gameObject = Object.Instantiate(Glow_Spin, new Vector3(position.x, position.y + height / 2f, position.z), Quaternion.Euler(0f, rotation.z, 0f));
		gameObject.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		gameObject.tag = IGT_Constants.Tag_Glow;
		gameObject.AddComponent<IGT_Rotation_X_axis>().RotateSpeed = 25f;
		gameObject.AddComponent<BoxCollider>();
		gameObject.GetComponent<BoxCollider>().size = new Vector3(gameObject.GetComponent<BoxCollider>().size.x / 2.5f, gameObject.GetComponent<BoxCollider>().size.y / 2.5f, gameObject.GetComponent<BoxCollider>().size.z);
		gameObject.AddComponent<IGT_ObjBouncing>();
		GlowInstanceList.Add(gameObject);
	}

	public static void glowObjDestruction()
	{
		foreach (GameObject glowInstance in GlowInstanceList)
		{
			Object.Destroy(glowInstance);
		}
		GlowInstanceList.Clear();
	}

	public static void destroy_GlowObjBased_GivenPos(Vector3 pos)
	{
		int num = 0;
		foreach (GameObject glowInstance in GlowInstanceList)
		{
			if (glowInstance.transform.position.x == pos.x && glowInstance.transform.position.z == pos.z)
			{
				Object.Destroy(glowInstance);
				GlowInstanceList.RemoveAt(num);
				break;
			}
			num++;
		}
	}
}
