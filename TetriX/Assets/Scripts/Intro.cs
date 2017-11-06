using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {
		RectTransform m_RectTransform;
		float m_XAxis, m_YAxis;

		void Start()
		{
			m_RectTransform = GameObject.Find("IntroText").GetComponent<RectTransform>();
		}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (5);
	}
	void Update()
	{
		//	
		Wait ();
		m_RectTransform.pivot += new Vector2 (0, 1);
	}
}
