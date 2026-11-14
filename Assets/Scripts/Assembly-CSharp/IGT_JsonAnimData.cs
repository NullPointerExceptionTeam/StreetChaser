using UnityEngine;

public class IGT_JsonAnimData
{
	public Vector3 location;

	public Vector3 rotation;

	public Vector3 scaling;

	public Vector3 dimensions;

	public int framestep;

	public IGT_JsonAnimData(Vector3 loc, Vector3 rot, Vector3 scal, Vector3 dim, int frmstp)
	{
		location = loc;
		rotation = rot;
		scaling = scal;
		dimensions = dim;
		framestep = frmstp;
	}
}
