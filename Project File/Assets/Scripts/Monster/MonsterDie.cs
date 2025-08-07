using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    private void Die()
    {
        Destroy(transform.parent.gameObject);
    }

    private void PlayCakeCatDie()
    {
        AudioManager.instance.PlaySFX("CakeDeadVoice");
    }

    private void PlayYellowJellyBearDie()
    {
        AudioManager.instance.PlaySFX("YellowDeadVoice");
    }

    private void PlayPurpleJellyBearDie()
    {
        AudioManager.instance.PlaySFX("PurpleDeadVoice");
    }

    private void PlayMintBunnyDie()
    {
        AudioManager.instance.PlaySFX("MintDeadVoice");
    }
}
