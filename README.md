# 3DFPSGame
3D로 만든 간단한 게임입니다(아직은... 프로토 타입입니다..)

----
## 기본 게임 키 사용

이동 : W A S D

구르기 : Ctrl

점프 : Space

아이템 사용 : T

----

## 카메라 이동

카메라 이동에는 Cinemachine을 사용했습니다.

다음과 같이 카메라가 벽에 부딪힐 경우, 통과하는 것이 아닌 밀려나는 식으로 연출했습니다.

![back](https://github.com/Be-bell/3DFPSGame/assets/127826912/e0ecd641-e5cf-45d2-8bdb-39ca76f4e66b)

----

## 움직임

움직임에는 inputSystem을 사용하였습니다.

blend Tree를 사용하여 입력된 값에 따라 다른 애니매이션이 사용되도록 하였습니다.

![move](https://github.com/Be-bell/3DFPSGame/assets/127826912/930bcc54-e8eb-49dd-a8cc-19e47563bf8e)

----

## 구르기

구르기도 inputSystem을 사용했습니다.

애니메이션 동작 시 Coroutine을 이용하여 잠깐동안의 이동속도가 빨라지는 형식으로 구르기를 구현했습니다.

![roll](https://github.com/Be-bell/3DFPSGame/assets/127826912/9c34f0cf-a9a5-45bc-ad70-3e4f5a130175)

----

## 아이템 발견

아이템 발견은 Raycast를 이용했습니다.

Raycast를 통해 비춰진 물체의 layerMask가 특정된 layerMask이면, 그 물체의 정보가 띄워지도록 하였습니다.

![ItemCursor](https://github.com/Be-bell/3DFPSGame/assets/127826912/7ea90575-2f3e-4fd6-85fc-baf257188f9d)

----

## 아이템 사용

아이템에 가까이 가게 되면 우즉 상단에 아이템 인벤토리에 저장이 됩니다.

T키를 입력하면 아이템을 사용하게 되고, 종류에 따라 효과가 플레이어에게 적용됩니다. 

아이템은 먹은 순서대로 사용하게 하였고, 이는 Queue를 이용하여 구현했습니다.

아이템의 종류는 다음과 같습니다.

Steak : 체력을 10 회복.
Soda : 스테미나를 10 회복.

![ItemUse](https://github.com/Be-bell/3DFPSGame/assets/127826912/c1d8127a-9a89-4360-82d7-7e014ce2a83b)

----

# 추가적으로 구현해야 할 사항들? (개인적인 의견입니다.)

1. 총 쏘기 : Ray를 이용하여 구현할 것 같습니다.
2. 장전 : inputSystem으로 사용하고, 자동적으로 재장전하는 것은 조금 더 고려해봐야 할 사항입니다.
3. 총 바꾸기 : 다른 item들과 비슷하지만, 닿으면 애니메이션이 바뀌고, 총알이 바뀌어야 합니다.
4. 적 생성 및 승리, 패배 : GameManager를 생성하여 구현해야 할 것 같습니다.
5. 시작화면, 저장 및 불러오기 : DataManager를 통해 시작씬에서부터 데이터를 불러오고 저장해야 합니다.
