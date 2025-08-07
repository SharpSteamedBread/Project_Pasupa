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

        //Debug.Log($"이거 {mapType[0]} 번째 맵임!");

        Instantiate(mapType[numbers[0]]);
    }

    //셔플 클래스
    public class Shuffle
    {
        public static int[] RandomNumbers(int maxCount, int n)
        {
            maxCount = 6;
            n = 1;

            int[] defaults = new int[maxCount];
            int[] results = new int[n];

            //배열 전체에 0부터 maxCount(맵 개수)의 값을 순서대로 저장
            for (int i = 0; i < maxCount; ++i)
            {
                defaults[i] = i;
            }

            //필요한 1개의 난수 생성
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
