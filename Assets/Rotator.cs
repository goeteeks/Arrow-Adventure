using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public GameObject pivot;
	//max rotation, degrees
	public float angMax;
	public float angSpeed;

	private Transform pTransform;
	private Vector3 pRotation;
	//angular velocity
	private float angV;
	//angular position
	private float angP;

	// Use this for initialization
	void Start () {
		pTransform = pivot.GetComponent<Transform> ();
		pRotation = new Vector3 (0, 0, 0);
		angV = 0f;
		while (angV == 0f) {
			angV = Random.Range ((int)-1, (int)1) * angSpeed;
		}
		angP = Random.value * Random.Range((int)-1,(int)1) * angMax;

		pRotation.Set (0, 0, angP);
		pTransform.eulerAngles = pRotation;
	}
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0f) {
			//only swing when the actual monkey part is alive
			if (this.GetComponentInChildren<EnemyBasic> () != null) {
				angP += angV;
				if (Mathf.Abs (angP) >= angMax) {
					angP -= angV;
					//reverse velocity
					angV = (angV > 0 ? -angSpeed : angSpeed);
				}
				pRotation.Set (0, 0, angP);
				pTransform.eulerAngles = pRotation;
			} else { //reset vine position 
				pRotation = Vector3.zero;
				pTransform.eulerAngles = pRotation;
			}
		}
	}
}
