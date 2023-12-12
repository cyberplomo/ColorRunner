using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed = 5f;

		void Update()
		{

			transform.Translate(0, 0, 1 * speed * Time.deltaTime);
			
			gameObject.GetComponent<Animator>().SetBool("isrunner", true);
		
		}
}
