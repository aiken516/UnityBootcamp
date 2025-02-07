**유니티 부트캠프 간단한 과제 진행용 레포지토리**
표적 맞추기를 이용하는 간단한 IDLE 게임
![image](https://github.com/user-attachments/assets/b9861ef6-2b98-46b4-a77d-c9772b7f4158)

----
250207

+ **Audio Source**
> **Priortiy** : 0 =  최우선, 128  = 기본, 256 = 최하위
> 
> **Volume** : 볼륨
> 
> **Pitch** : 재생속도가 느려질거나 빨라질 때 피치 변화량
> 
> **Stero Pan** : 소리 재생 시 좌우 스피커 간 소리 분포 -1 = 왼쪽, 0 = 가운데, 1 = 오른쪽
> 
> **Stero Blend** : 0 = 사운드가 거리와 무관, 1 = 사운드가 거리에 따라 변화
> 
> **Reverb Zone Mix** : 리버브 존에 대한 출력 정도, 0 = 영향 없음, 1 = 최대치, 1.1 = 10db 증폭
> 
> **3D Sound Setting**
> 
> **Doppler Level** : 거리에 따른 사운드 높낮이 표현, 0 = 효과 없음
> 
> **Spread** : 사운드가 퍼지는 각도 (0~360), 0 = 한 점, 360 = 모든 방향
> 
> **Rolloff Mode** : 그래프 설정,

+ **Audio Mixer**
> 오디오 소스에 대한 제어, 균형, 조정을 제공
> 
> Creat → Audio → AudioMixer로 생성 가능, 전용 에딧 윈도우가 존재
> 최초 생성 시 MasterGroup이 존재
> 
> 그룹을 추가해서 서로 다른 사운드를 관리 가능(보통 BGM, SFX)
> 각 그룹은 기본적으로 Parameter가 UnExpose 상태.
> 이를 Expose해야 스크립트로 수정 가능하며, Parameter 값도 수정 가능
> 
> 1. SetFloat(name, value)
> value는 -80에서 0까지의 값. 0과 1 사이의 값을 이용하기 위해선 Mathf.Log10(value) * 20, 최소값은 0.0001의 형태로 이용

+ Mathf
> 1. Mathf.Deg2Rad
> degree(60분법)을 라디안으로
> 
> 2. Mathf.Rad2Deg
> 라디안을 디그리로
> 3. Mathf.Abs
> 절대값
> 
> 4. Mathf.Atan
> 아크탄젠트
> 
> 5. Mathf.Ceil
> 소수점 올림
> 
> 6. Mathf.Clamp(value, min, max)
> 값을 최소값과 최대값 사이로 고정
> 
> 7. Mathf.Log10
> 베이스 10인 로그값으로 반환
