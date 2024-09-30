using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(DestroyTarget());
	}

	void Update()
	{
		if (AimTask.isTaskStart != true)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator DestroyTarget()
	{
		yield return new WaitForSeconds(2);
		AimTask.targetsMissed = AimTask.targetsMissed + 1;
		if (AimTask.isTaskStart == true)
		{
			AimTask.instance.SpawnTargets();
		}
		if (gameObject != null)
		{
			Destroy(gameObject);
		}
	}

	private void OnMouseDown()
	{
		DataLogger.Instance.WriteTime();
		AimTask.targetsHit = AimTask.targetsHit + 1;

		if (gameObject != null)
		{
			Destroy(gameObject);
		}
		if (AimTask.isTaskStart == true)
		{
			AimTask.instance.SpawnTargets();
			DataLogger.Instance.StartTiming();
		}
	}
}
