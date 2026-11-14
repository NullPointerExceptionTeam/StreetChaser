using System.Collections.Generic;
using UnityEngine;

public class IGT_MovingObjPlacing : MonoBehaviour
{
	public static GameObject Car_Taxi;

	public static GameObject Car_Cop;

	public static GameObject Car_FoodVan;

	public static GameObject Car_IceVan;

	public static GameObject prefab = null;

	public static List<GameObject> MovObjList = new List<GameObject>();

	public static void MovingObjInstantiating()
	{
		Vector3 position = new Vector3(300f, -100f, 300f);
		Car_Taxi = Object.Instantiate(Resources.Load("Objects/Car_Taxi"), position, Quaternion.identity) as GameObject;
		Car_Cop = Object.Instantiate(Resources.Load("Objects/Car_Cop"), position, Quaternion.identity) as GameObject;
		Car_FoodVan = Object.Instantiate(Resources.Load("Objects/Car_FoodVan"), position, Quaternion.identity) as GameObject;
		Car_IceVan = Object.Instantiate(Resources.Load("Objects/Car_IceVan"), position, Quaternion.identity) as GameObject;
	}

	public static void MovObjPlaceAtRuntime(ref List<IGT_ObjInfo> objData)
	{
		for (int i = 0; i < objData.Count; i++)
		{
			switch (objData[i].objID)
			{
			case 400:
				prefab = Car_Cop;
				break;
			case 401:
				prefab = Car_FoodVan;
				break;
			case 402:
				prefab = Car_Taxi;
				break;
			case 403:
				prefab = Car_IceVan;
				break;
			}
			MovObjList.Insert(i, Object.Instantiate(prefab, new Vector3(objData[i].VehicleAnimPoint.x, objData[i].VehicleAnimPoint.y, objData[i].VehicleAnimPoint.z), Quaternion.Euler(0f, objData[i].objRot.z, 0f)));
			if (IGT_GameView.pHero.nSound == 0)
			{
				MovObjList[i].AddComponent<AudioSource>();
				switch (objData[i].objID)
				{
				case 400:
					MovObjList[i].GetComponent<AudioSource>().clip = IGT_GameView.pHero._AudioClips[20];
					break;
				case 401:
				case 402:
					MovObjList[i].GetComponent<AudioSource>().clip = IGT_GameView.pHero._AudioClips[17];
					break;
				case 403:
					MovObjList[i].GetComponent<AudioSource>().clip = IGT_GameView.pHero._AudioClips[19];
					break;
				}
				MovObjList[i].GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
				MovObjList[i].GetComponent<AudioSource>().spatialBlend = 1f;
				MovObjList[i].GetComponent<AudioSource>().minDistance = 4f;
				MovObjList[i].GetComponent<AudioSource>().maxDistance = 6f;
				MovObjList[i].GetComponent<AudioSource>().volume = 0.6f;
				MovObjList[i].GetComponent<AudioSource>().loop = false;
				MovObjList[i].GetComponent<AudioSource>().Play();
			}
			MovObjList[i].name = objData[i].objID.ToString();
			MovObjList[i].tag = IGT_Constants.Tag_DynamicObj;
			MovObjList[i].layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		}
	}

	public static void MovObjDestruction()
	{
		foreach (GameObject movObj in MovObjList)
		{
			Object.Destroy(movObj);
		}
		MovObjList.Clear();
	}
}
