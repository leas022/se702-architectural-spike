using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	void Start()
	{
		// Do nothing here
	}

	void Update()
	{
		if (AimTask.isTaskStart != true)
		{
			Destroy(gameObject);
		}
	}

	private void OnMouseDown()
	{
		DataLogger.Instance.WriteTime();

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
