using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    private int Stick = 0;

	private void OnTriggerEnter(Collider other)
	{
		
			if(other.transform.tag == "Collectitem")
			{
				Stick++;
				Debug.Log(Stick);
				Destroy(other.gameObject);

			}	

	}
}
