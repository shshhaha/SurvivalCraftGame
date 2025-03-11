using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_Light : MonoBehaviour
{
	public float time = 0.05f;
	
	private float timer;
	
    void Start ()
    {
        GetComponent<Light>().enabled = true; // 빛을 켭니다.
    }

}
