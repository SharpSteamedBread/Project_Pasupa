using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHitAnimMintbunny : MonoBehaviour
{
    [SerializeField] private GameObject objMonState;

    private void Awake()
    {
        //objMonState.GetComponent<MonsterState>().StateChange(MonsterState.EnemyState.IDLE);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);

        /*
        if (collision.gameObject.CompareTag("PlayerHitbox")
           && objMonState.GetComponent<MonsterStateMintbunny>().iWokeup == 0)
        {
            objMonState.GetComponent<MonsterStateMintbunny>().StateChange(MonsterStateMintbunny.EnemyState.WAKEUP);
        }
        */

        if (collision.gameObject.CompareTag("PlayerHitbox") 
            && objMonState.GetComponent<MonsterStateMintbunny>().iWokeup >= 1)
        {
            objMonState.GetComponent<MonsterStateMintbunny>().StateChange(MonsterStateMintbunny.EnemyState.DAMAGED);
        }
    }
}
