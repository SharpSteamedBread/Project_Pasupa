using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ShuffleCardMake
public class RandomMapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mapType;

    private void Awake()
    {
        MakeMap();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeMap()
    {
        int[] numbers = Shuffle.RandomNumbers(mapType.Length, 1);

        //Debug.Log($"�̰� {mapType[0]} ��° ����!");

        Instantiate(mapType[numbers[0]]);
    }

    //���� Ŭ����
    public class Shuffle
    {
        public static int[] RandomNumbers(int maxCount, int n)
        {
            maxCount = 6;
            n = 1;

            int[] defaults = new int[maxCount];
            int[] results = new int[n];

            //�迭 ��ü�� 0���� maxCount(�� ����)�� ���� ������� ����
            for (int i = 0; i < maxCount; ++i)
            {
                defaults[i] = i;
            }

            //�ʿ��� 1���� ���� ����
            for (int i = 0; i < n; ++i)
            {
                int index = Random.Range(0, maxCount);
                results[i] = defaults[index];
                defaults[index] = defaults[maxCount - 1];

                maxCount--;
            }

            return results;
        }
    }
}
