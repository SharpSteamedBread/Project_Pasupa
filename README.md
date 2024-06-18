# Project_Pasupa
> **개발 기간:** 3학년 1학기(2023.03.01 ~ 2023.06.30)

> **게임 엔진:** Unity3D

> **사용 언어:** C#


- 해당 게임의 프로그래머로 작업에 참여하였습니다.
- 다이얼로그, 튜토리얼 연출을 제외한 프로그래밍을 담당하였습니다.
<br> </br> <br> </br>
# 게임 개요

> ## 반전성
파슈파 프로젝트는 **점프스케어 형식의 공포 연출**과 귀여운 도트 그래픽과 반대되는 **고어 그래픽**으로 공포가 기시감처럼 느껴지도록 긴장감 있는 게임 경험을 조성합니다.
+ 게임 시작 UI가 게임 클리어 전후로 각기 다른 연출을 포함합니다. 

■ 게임 클리어 전

<img width="960" alt="main_1" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/8ad6c28b-9210-4b44-aa7b-5ea8ba67ed04">

<br> </br>
■ 게임 클리어 후

<img width="960" alt="main_2" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/eeab238e-4569-4ed9-9914-ba10878cf05d">

<br> </br>
+ 몬스터를 처치할 시 5%의 확률로 BGM이 톤 다운 되면서 공포 분위기를 연출합니다.
  BGM 오브젝트가 포함한 AudioSource Component의 Pitch 속성을 기본값인 1에서 0.15씩 감소하여 구현합니다.

<div style= "text-align : center;">
  <img width="240" alt="main_1" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/fd38270b-4ed9-4ac0-b152-b73dc211e756">
</div>

<br> </br>

+ 특정 위치에 도달할 시, 주 그래픽인 귀여운 느낌의 도트 그래픽과는 다른 현실 묘사 그래픽을 출력하여 괴리감을 조성합니다.

<img width="960" alt="main_2" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/22bcca26-a2c4-4d48-bb73-b2ebab441c18">
<br> </br> <br> </br>

> ## 랜덤성
파슈파 프로젝트는 로그라이크 장르로, 스테이지 형식의 선형적 구조로 이루어져 있지만 맵의 가짓수를 늘려 같은 스테이지여도 다른 맵을 출력할 수 있도록 구현하였습니다. 유저가 반복되는 맵 구조에 피로감과 지루함을 느끼는 것을 방지합니다. 

<img width="960" alt="main_2" src="https://github.com/SharpSteamedBread/Project_Pasupa/assets/159697360/2587e3db-e991-4f2c-8732-7bf6bd73c191">
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

<br> </br> <br> </br>

# 개발 내용

> ## 스테이지 관련

> **StageController.cs**

스테이지 별로 몬스터 수량, Glitch 연출 여부를 결정하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Stage/StageController.cs)

> **RandomMapGenerator.cs**

프리팹으로 지정해준 스테이지의 프리셋을 랜덤으로 생성하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Stage/RandomMapGenerator.cs)

> **OpenBossStage.cs**

보스 스테이지에서 플레이어가 일정 지점에 도달하면 보스 전투 구역을 생성하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Stage/OpenBossStage.cs)

> **PortalOpenning.cs**

플레이어가 포탈의 콜라이더에 닿으면 다음 Scene으로 넘어가게 하는 스크립트입니다. 오프닝 연출 맵의 포탈에서만 사용됩니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/PortalOpenning.cs)

> **PlayerSpawner.cs**

스테이지 프리셋의 특정 지점에 플레이어를 스폰하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Spawner/PlayerSpawner.cs)

> **NextScene.cs**

포탈 애니메이션이 전부 재생된 후 플레이어를 다음 Scene으로 이동시키는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Stage/NextScene.cs)

> **PortalLink.cs**

스테이지에 존재하는 모든 몬스터를 처치했을 시 포탈을 활성화하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Stage/PortalLink.cs)

<br> </br>

> ## 플레이어 관련

> **PlayerStatus.cs**

플레이어의 스텟을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Player/PlayerStatus.cs)

> **PlayerMove.cs**

플레이어의 이동, 점프, 넉백을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Player/PlayerMove.cs)

> **BasicAttack.cs**

플레이어의 기본 공격을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Player/BasicAttack.cs)

> **CameraController.cs**

카메라가 플레이어를 추적하도록 하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Camera/CameraController.cs)

> **RefreshPlayer.cs**

보스 스테이지로 입장하기 전, 플레이어가 침대 오브젝트에 닿을 시 체력을 완전히 회복하게 하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/RefreshPlayer.cs)

> **HitSystemPlayer.cs**

플레이어의 일반 공격 계산 및 히트박스 관리, HUD Text(데미지 플로팅) 생성 기능을 가진 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Player/HitSystemPlayer.cs)

<br> </br>

> ## Glitch 연출 관련

> **GlitchController.cs**

글리치 UI를 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/GlitchController.cs)

<br> </br>

> ## Fade 연출 관련

> **ActivateFade.cs**

Fade 애니메이션을 관리하는 스크립트입니다. 

보스 패턴 중 번개의 메커니즘을 예로 들자면, 
1.	번개 예고 오브젝트 활성화
2.	번개 예고 오브젝트의 애니메이션이 끝나면 번개 예고 오브젝트의 자식으로 등록된 번개 오브젝트 활성화
3.	번개 오브젝트의 애니메이션이 끝나면 번개 예고 오브젝트(부모 오브젝트) 삭제
형식으로 작동합니다.

[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/Fade/ActivateFade.cs)

<br> </br>

> ## 피격 데미지 플로팅 UI 관련

> **UIHUDText.cs**

HUD Text(데미지 플로팅) 오브젝트의 애니메이션을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/HUD%20Text/UIHUDText.cs)

<br> </br>

> ## UI 관련

> **HPBar.cs**

플레이어 체력 바 UI를 실시간으로 업데이트하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/HPBar.cs)

> **HPBarBoss.cs**

보스 체력 바 UI를 실시간으로 업데이트하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/HPBarBoss.cs)

> **ButtonReturntoIngame.cs**

일시정지 패널을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/ButtonReturntoIngame.cs)

> **ButtonManager.cs**

메인 화면으로 돌아가는 버튼, 게임 종료 버튼을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/UI/ButtonManager.cs)

<br> </br>

> ## 몬스터 관련

> **MonsterStatus.cs**

몬스터의 스텟을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/MonsterStatus.cs)

> **MonsterIdle.cs / MonsterIdleMintbunny.cs**

몬스터의 IDLE 상태 로직이 담긴 스크립트입니다. 주된 기능은 자유 의지 움직임입니다. 
밑의 MonsterState.cs에서 공격이나 사망 등의 상태에서 몬스터가 이동하면 안 되기에 Inspector 창에서 스크립트 컴포넌트를 온오프 하는 형식으로 해당 스크립트를 이용합니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/MonsterIdle.cs)
[코드 상세 내용: Mintbunny](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/Mintbunny/MonsterIdleMintbunny.cs)

> **MonsterState.cs / MonsterStateMintbunny.cs**

몬스터의 행동 패턴을 관리하는 스크립트입니다. 
밑의 MonsterState.cs에서 공격이나 사망 등의 상태에서 몬스터가 이동하면 안 되기에 Inspector 창에서 스크립트 컴포넌트를 온오프 하는 형식으로 해당 스크립트를 이용합니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/MonsterState.cs)
[코드 상세 내용: Mintbunny](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/Mintbunny/MonsterStateMintbunny.cs)

> **MonsterSpawn.cs**

플레이어가 일정 좌표에 배치된 collider에 닿으면 몬스터를 스폰하는 스크립트입니다. 
콜라이더와 몬스터 스폰 지점을 따로 배치할 수 있어 기획자의 편의성을 높였습니다.
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Spawner/MonsterSpawn.cs)

> **PlayHitAnim.cs / PlayHitAnimMintbunny.cs**

몬스터가 플레이어의 히트박스에 닿으면 상태를 DAMAGED(피격 상태)로 전환하는 스크립트입니다.
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/PlayHitAnim.cs)
[코드 상세 내용: Mintbunny](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/Mintbunny/PlayHitAnimMintbunny.cs)

> **MonsterDie.cs**

몬스터가 DIE 상태에 들어가면 해당 오브젝트를 파괴하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/MonsterDie.cs)

> **Bullet.cs**

Mintbunny, PurpleJellyBear의 투사체 정보를 담은 스크립트입니다. 
투사체의 속도와 공격력 정보, 피격 판정과 방향을 판단하여 왼쪽, 오른쪽으로 이동하는 기능이 있습니다.
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/Bullet.cs)

> **BulletAttack.cs**

Mintbunny, PurpleJellyBear가 투사체를 발사하는 패턴을 관리하는 스크립트입니다. 
PurpleJellyBear는 일직선으로, Mintbunny는 원형으로 투사체 8발을 발사하는 로직입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/BulletAttack.cs)

> **HitSystemMonster.cs**

몬스터의 공격 판정 기능이 담긴 스크립트입니다. 
플레이어의 HP를 Update문에서 체크하여 0이 되면 게임 오버 UI를 활성화합니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/HitSystemMonster.cs)

> **BossState.cs**

보스의 행동 패턴을 관리하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Boss/BossState.cs)

> **BossStatus.cs**

보스의 스텟을 관리하는 스크립트입니다. 
보스의 패턴 공격은 각 공격과 관련된 오브젝트를 소환하는 로직만 구현하고, 오브젝트의 로직은 따로 구현합니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Boss/BossStatus.cs)

> **TanukiMove.cs**

너구리 석상 오브젝트의 스텟 정보와 이동 로직, 플레이어 타격을 구현한 스크립트입니다.
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Boss/TanukiMove.cs)

> **ThunderController.cs**

번개 오브젝트의 스텟 정보와 활성화 로직, 플레이어 타격을 구현한 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Boss/ThunderController.cs)

> **DalmaMove.cs**

달마와 공 오브젝트의 스텟 정보와 이동 로직, 플레이어 타격을 구현한 스크립트입니다. 
해당 오브젝트의 바운스는 유니티 물리엔진의 Physics Material 2D로 구현하였습니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Boss/DalmaMove.cs)

> **BossHitSystem.cs**

보스의 플레이어 타격 시스템을 구현한 스크립트입니다. 
플레이어의 체력을 Update문에서 체크하여 0이 될 시 게임 오버 UI를 출력합니다.
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Boss/BossHitSystem.cs)

<br> </br>

> ## 사운드 관련

> **TapSound.cs**

마우스 왼쪽 버튼 입력 시 소리를 재생하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Sounds/TapSound.cs)

> **BGMController.cs**

게임 시작 시 인트로 화면에서 연출에 따라 BGM을 재생하도록 제어하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Sounds/BGMController.cs)

> **PlayOtherSound.cs**

몬스터의 종류에 따라 사운드를 다르게 재생하는 스크립트입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Monster/PlayOtherSound.cs)

> **AudioManager.cs**

유니티의 Inspector창이 아닌 스크립트에서 제어할 SFX를 관리하는 스크립트입니다. 현재는 사운드를 싱글톤 패턴으로 구현했습니다. Static 접근자의 스크립트에 사용할 SoundClip을 할당해놓고 다른 오브젝트의 SoundSource를 배치시킨 뒤 해당 사운드 매니저 스크립트를 다른 스크립트에서 static으로 불러와 바로 사운드를 재생시키는 매커니즘입니다. 
[코드 상세 내용](https://github.com/SharpSteamedBread/Project_Pasupa/blob/main/PetitGore0611/Assets/Scripts/Sounds/AudioManager.cs)

<br> </br>
