using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subel_Openning_Move : MonoBehaviour
{
    public GameObject EventObj;
    public float movementSpeed = 1f; // �̵� �ӵ�
    public Transform targetPosition1; // �̵��� ��ǥ ��ġ1
    public bool isMoving = true; // ������Ʈ �̵� ����


    [SerializeField]
    private Animator SubelAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // ���� ��ġ���� ��ǥ ��ġ���� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition1.position, movementSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� �����ϸ� �̵� ����
            if (transform.position == targetPosition1.position)
            {
                isMoving = false;
                // �ִϸ��̼� ��ȯ�� ���� �Լ� ȣ��
                StartAnimation();
                //manager.Action(scanObj);
                EventObj.GetComponent<EventManager>().animCount++;
                isMoving = false;
                GetComponent<Subel_Openning_Move>().enabled = false;
            }
        }
    }
    private void StartAnimation()
    {
        SubelAnim.SetBool("IsMoving", false); // �ִϸ��̼� �Ķ���� ���� ����
    }
}
