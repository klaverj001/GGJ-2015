using UnityEngine;
using System.Collections;

public class OnCollideScript : MonoBehaviour {

	void OnCollisionEnter2D ()
	{
		Destroy (gameObject);
	}
}