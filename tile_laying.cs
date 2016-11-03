using UnityEngine;
using System.Collections;

public class tile_laying : MonoBehaviour {

	/*
	 * this class lays the specified tile 
	 * as much as it can in a complete square
	 * between the specified coordinates 
	 */

	public GameObject tile_sprite;
	public float x_start, x_stop;
	public float y_start, y_stop;
	public bool start;

	bool begin;

	void lay_tiles () {
		if (begin) {
			begin = false;
			place ();
		}
	}

	void place () {
		float placeholder;
		Vector3 pos;
		Debug.Log ("laying tiles...");

		// starting x needs to be less than stopping x
		if (x_start > x_stop) {
			placeholder = x_start;
			x_start = x_stop;
			x_stop = placeholder;
		} 

		// starting y needs to be less than stopping y
		if (y_start > y_stop) {
			placeholder = y_start;
			y_start = y_stop;
			y_stop = placeholder;
		}

		// fill area
		for (float x = x_start; x <= x_stop; x += 0.5f) {
			for (float y = y_start; y <= y_stop; y += 0.5f) {	
				pos = new Vector3(x, y, 0);
				Instantiate (tile_sprite, pos, Quaternion.identity);
				//Debug.Log ("x:" + x + " y:" + y);
			}
		}
	}

	void Start () {
		// initialize values with something
		Debug.Log ("starting...");
		Debug.Log ("x_start:" + x_start + " x_stop:" + x_stop);
		begin = true;
	}

	void Update () {
		if (start) {
			lay_tiles();
		}
	}
}
