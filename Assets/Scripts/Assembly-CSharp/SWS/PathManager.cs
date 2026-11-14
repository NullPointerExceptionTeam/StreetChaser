using UnityEngine;

namespace SWS
{
	public class PathManager : MonoBehaviour
	{
		public Transform[] waypoints = new Transform[0];

		public bool drawCurved = true;

		public Color color1 = new Color(1f, 0f, 1f, 0.5f);

		public Color color2 = new Color(1f, 47f / 51f, 0.015686275f, 0.5f);

		public Vector3 size = new Vector3(0.7f, 0.7f, 0.7f);

		public float radius = 0.4f;

		public bool skipCustomNames = true;

		public GameObject replaceObject;

		public virtual float GetHandleSize(Vector3 pos)
		{
			return 1f;
		}

		public virtual Vector3[] GetPathPoints(bool local = false)
		{
			Vector3[] array = new Vector3[waypoints.Length];
			if (local)
			{
				for (int i = 0; i < waypoints.Length; i++)
				{
					array[i] = waypoints[i].localPosition;
				}
			}
			else
			{
				for (int j = 0; j < waypoints.Length; j++)
				{
					array[j] = waypoints[j].position;
				}
			}
			return array;
		}

		public virtual int GetWaypointIndex(int point)
		{
			return point;
		}

		public virtual int GetEventsCount()
		{
			return waypoints.Length;
		}
	}
}
