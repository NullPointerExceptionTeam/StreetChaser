using UnityEngine;

public class IGT_EnergyItemCollision : MonoBehaviour
{
	private IGT_Hero pHero;

	private void Start()
	{
		pHero = GameObject.FindGameObjectWithTag("Player").GetComponent<IGT_Hero>();
	}

	private void OnTriggerEnter(Collider col)
	{
		if (pHero != null)
		{
			pHero._OnTriggerEnter(col);
		}
	}
}
