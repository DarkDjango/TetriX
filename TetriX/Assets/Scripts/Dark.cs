using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dark : MonoBehaviour {

	Image sr;
	public bool visible = false;
	public float fadingTime, fadingUnit;
	public int maxFade;
	// Use this for initialization
	private SpawnBlock spawner;

	private IEnumerator FadeIn () {
		int c = 0;
		while (c < maxFade) {
				sr.color += new Color (0, 0, 0, fadingUnit);
				yield return new WaitForSeconds (fadingTime);
				c++;
			}
		}
	private IEnumerator FadeOut () {
		int c = 0;
		while (c < maxFade) {
			sr.color -= new Color (0, 0, 0, fadingUnit);
			yield return new WaitForSeconds (fadingTime);
			c++;
		}
	}
	void Start() {
		sr = gameObject.GetComponent<Image>(); 
		spawner = GameObject.Find ("Spawner").GetComponent<SpawnBlock> ();

	}
	void Update () {
		if ((spawner.MagneticPressure)&&(!visible)) {
			StartCoroutine (FadeIn ());
			visible = true;
		}
		if ((visible) && (!spawner.MagneticPressure)) {
			StartCoroutine(FadeOut());
			visible = false;
		}
	}
}