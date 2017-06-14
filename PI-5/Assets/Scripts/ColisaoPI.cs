using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoPI : MonoBehaviour {

	public string Tag;
	public string Tag2;
	public float Increase;
	public float Decrease;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == Tag)
		{
			transform.localScale += new Vector3(Decrease, Decrease, Decrease);
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == Tag2) 
		{
			transform.localScale -= new Vector3 (Increase, Increase, Increase);
			Destroy (other.gameObject);
		}
	}
}
