# Project_Pasupa
3학년 1학기(2023.03.01 ~ 2023.06.30)에 제작한 로그라이크 게임입니다. 


- 해당 게임의 프로그래머로 작업에 참여하였습니다.
- 다이얼로그, 튜토리얼 연출을 제외한 프로그래밍을 담당하였습니다.
<br> </br> <br> </br>
# 게임 개요

> ## 반전성
파슈파 프로젝트는 **점프스케어 형식의 공포 연출**과 귀여운 도트 그래픽과 반대되는 **고어 그래픽**으로 공포가 기시감처럼 느껴지도록 긴장감 있는 게임 경험을 조성합니다.
<br> </br>
+ 게임 시작 UI가 게임 클리어 전후로 각기 다른 연출을 포함합니다. 

■ 게임 클리어 전

<img width="960" alt="main_1" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/8ad6c28b-9210-4b44-aa7b-5ea8ba67ed04">

<br> </br>
■ 게임 클리어 후

<img width="960" alt="main_2" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/eeab238e-4569-4ed9-9914-ba10878cf05d">

<br> </br>
+ 몬스터를 처치할 시 5%의 확률로 BGM이 톤 다운 되면서 공포 분위기를 연출합니다.
  BGM 오브젝트가 포함한 AudioSource Component의 Pitch 속성을 기본값인 1에서 0.15씩 감소하여 구현합니다.
<br> </br>

+ 특정 위치에 도달할 시, 주 그래픽인 귀여운 느낌의 도트 그래픽과는 다른 현실 묘사 그래픽을 출력하여 괴리감을 조성합니다.
<br> </br> <br> </br>

> ## 랜덤성
파슈파 프로젝트는 로그라이크 장르로, 스테이지 형식의 선형적 구조로 이루어져 있지만 맵의 가짓수를 늘려 같은 스테이지여도 다른 맵을 출력할 수 있도록 구현하였습니다. 유저가 반복되는 맵 구조에 피로감과 지루함을 느끼는 것을 방지합니다. 
<br> </br>
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] mapType;

    private void Awake()
    {
        MakeMap();
    }

    public void MakeMap()
    {
        int[] numbers = Shuffle.RandomNumbers(mapType.Length, 1);

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
```
mapType 변수에 각 스테이지를 Prefab으로 만들어 배열로 할당한 다음, Shuffle 클래스를 통하여 mapType의 배열 순서를 무작위로 변경합니다.
그 다음 재구성된 mapType의 0번 인덱스로 해당 Prefab을 생성합니다.
