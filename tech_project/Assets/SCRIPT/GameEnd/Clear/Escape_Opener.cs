using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape_Opener : MonoBehaviour
{
    private GameObject EscapeOpener;
    public GameObject EscapeUI;

    public void Start()
    {
        EscapeOpener = this.gameObject;
        EscapeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EscapeUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EscapeUI.SetActive(false);
        }
    }
}
