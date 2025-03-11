using sound.sfx;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    int collisionCount = 0;

    void OnCollisionEnter(Collision collision)
    {
        collisionCount++;

        if (collisionCount == 2)
        {
            _SFX.instance.PlaySFX(_SFX.Sfx.AmmoShell);
        }
    }

    public void ResetCollisionCount()
    {
        collisionCount = 0;
    }

}