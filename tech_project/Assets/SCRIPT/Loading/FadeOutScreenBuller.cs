using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScreenBuller : MonoBehaviour
{
    
    [SerializeField] Image fadeOutImage;
    private void Start()
    {
        Color opaqueColor = new Color(fadeOutImage.color.r, fadeOutImage.color.g, fadeOutImage.color.b, 1);
        fadeOutImage.color = opaqueColor;

        FadeOut();
    }

    private void FadeOut(){
        fadeOutImage.DOFade(0, 3f).OnComplete(() => {
            Destroy(gameObject);
        });
    }
}
