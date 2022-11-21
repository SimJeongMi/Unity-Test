# Chapter 1. 캐릭터 이동 
***
## [참고자료] Rigidbody로 캐릭터 움직임 구현
https://www.youtube.com/watch?v=e9D8W78ZgZ4
####
    캐릭터의 이동/점프/대시를 구현하고 Rigidbody에 대해 알아봅니다.
    
    씬 경로 : Assets/HR/0.Scenes/CharacterMovement
#
## Rigidbody 컴포넌트
![캡처](https://user-images.githubusercontent.com/86524081/202970747-349b56f7-20ae-4247-b544-cce7935385e7.PNG)

**mass**

    질량

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
    
