using UnityEngine;

public class IGT_ThrowObjects : MonoBehaviour
{
	public Rigidbody Rb;

	public float fForce = 10f;

	public float fMovForce = 1.5f;

	public Vector3 dir;

	public Vector3 vel;

	private bool btest;

	private void Start()
	{
		Rb = GetComponent<Rigidbody>();
		Rb.mass = 1f;
		Rb.drag = 0f;
		Rb.angularDrag = 0f;
		Rb.isKinematic = true;
		Rb.useGravity = false;
	}

	private void FixedUpdate()
	{
		Rb.AddTorque(1000f, 1000f, 1000f, ForceMode.VelocityChange);
		if (!IGT_Hero.bGameOver)
		{
			if (IGT_Hero.bPickdObjCanThrow && !btest)
			{
				Rb.isKinematic = false;
				Rb.useGravity = true;
				Rb.velocity = vel;
				btest = true;
			}
			if (IGT_Hero.bThrowObjMoving && !btest && IGT_AnimStatesCntrler.nHeroAnimState != 2)
			{
				Rb.isKinematic = false;
				Rb.AddForce(dir * fMovForce, ForceMode.Impulse);
				Rb.useGravity = true;
				btest = true;
			}
		}
	}
}
