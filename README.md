# Chapter 1. 캐릭터 이동 
***
## [참고자료] Rigidbody로 캐릭터 움직임 구현
https://www.youtube.com/watch?v=e9D8W78ZgZ4
####
    캐릭터의 이동/점프/대시를 구현하고 Rigidbody에 대해 알아봅니다.
####
    Assets/HR/0.Scenes/CharacterMovement
#
## Rigidbody 컴포넌트
![캡처](https://user-images.githubusercontent.com/86524081/202970747-349b56f7-20ae-4247-b544-cce7935385e7.PNG)

**mass**

    질량

**drag**

    공기저항 (0이면 공기저항이 없다. 높아지면 공기저항으로 인해 떨어지는 속도가 느려진다.)

**angular drag**

    회전저항 (커질수록 회전할 때 더 오래 걸린다.)

**use gravity**

    체크하면 중력을 사용하겠다는 뜻

**is kinematic**

    체크하면 어떤 물체가 날라와도 플레이어는 영향을 받지 않음

**interpolate**

    물리계산을 어떻게 할 것인가
    
**collision detection**

    충돌 체크

**constraints**

    freeze position, freeze rotation 
    
    체크한 부분에 대해서 연산하지 않는다.
#
## Layer
![캡처2](https://user-images.githubusercontent.com/86524081/202973327-5490e8bb-16c7-4ad5-a3c3-1ef628c6c8f4.PNG)

    레이어는 씬의 일부분만을 렌더링 하거나, 물리적 충돌을 판정하는 데 사용됨
####
    이번 시간에는 레이가 바닥에 닿았는지를 판정하기 위해 Ground라는 임의의 레이어를 지정해주었다.
    
    카메라의 Culling Mask에서 체크해제한 Layer는 렌더링되지 않는다. 씬뷰에서는 보인다.
#
## Pivot 위치 변경
![캡처3](https://user-images.githubusercontent.com/86524081/202976148-b7a775fd-6582-469e-b344-235d7ab2951a.PNG)
![캡처4](https://user-images.githubusercontent.com/86524081/202975500-35a109e8-6275-4d14-bbcc-e53c1e239cb0.PNG)

    Capsule로 캐릭터 생성 시, 빈 오브젝트를 부모로 상속받아 피봇 위치를 조정해주도록 한다.
    캡슐은 피봇이 중앙에 있기 때문에 y 포지션을 0으로 주면 땅바닥에 파묻힌 모양이 된다.
