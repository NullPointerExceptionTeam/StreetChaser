using UnityEngine;

public class IGT_KickObjects : MonoBehaviour
{
	public Rigidbody Rb;

	public float fForce;

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
		Rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
	}

	private void FixedUpdate()
	{
		if (!IGT_Hero.bGameOver)
		{
			if (IGT_Hero.bkickObjFly && !btest)
			{
				Rb.isKinematic = false;
				Rb.useGravity = true;
				btest = true;
				Rb.velocity = vel;
				Rb.AddTorque(vel / 2f);
			}
			if (IGT_Hero.bKickObjMoving && !btest && IGT_AnimStatesCntrler.nHeroAnimState != 2)
			{
				Rb.isKinematic = false;
				Rb.AddForce(dir * fMovForce, ForceMode.Impulse);
				Rb.useGravity = true;
				btest = true;
			}
		}
	}
}
