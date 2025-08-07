using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHitAnim : MonoBehaviour
{
    [SerializeField] private GameObject objMonState;

    private void Awake()
    {
        //objMonState.GetComponent<MonsterState>().StateChange(MonsterState.EnemyState.IDLE);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.CompareTag("PlayerHitbox"))
        {
            objMonState.GetComponent<MonsterState>().StateChange(MonsterState.EnemyState.DAMAGED);
        }
    }
}
