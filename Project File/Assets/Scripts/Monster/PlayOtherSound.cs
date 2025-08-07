using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOtherSound : MonoBehaviour
{
    private void HitVoice()
    {
        if(gameObject.CompareTag("CakeCat"))
        {
            AudioManager.instance.PlaySFX("CakeAttackedVoice");
        }

        if (gameObject.CompareTag("YellowJellyBear"))
        {
            AudioManager.instance.PlaySFX("YellowAttackedVoice");
        }

        if (gameObject.CompareTag("PurpleJellyBear"))
        {
            AudioManager.instance.PlaySFX("PurpleAttackedVoice");
        }

        if (gameObject.CompareTag("MintBunny"))
        {
            AudioManager.instance.PlaySFX("MintAttackedVoice");
        }
    }
}
