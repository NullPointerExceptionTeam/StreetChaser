using UnityEngine;

public class GetBounds : MonoBehaviour
{
	public float height;

	public float width;

	public float length;

	public Vector3 center;

	private void Start()
	{
		width = 0f;
		height = 0f;
		length = 0f;
		center = Vector3.zero;
	}

	private void LateUpdate()
	{
		Bounds bounds = GetComponent<MeshRenderer>().bounds;
		center = bounds.center;
		height = bounds.size.y;
		width = bounds.size.x;
		length = bounds.size.z;
	}
}
