# 🎮 Unity Enemy Spawner Shooter

엔진프로그래밍 Unity 기말 프로젝트.

Unity에서 **Instantiate 함수**와 **Prefab**을 활용하여 적(Enemy)을 생성하고 플레이어 이동과 총알 발사 시스템을 구현한 간단한 슈팅 게임입니다.

적이 죽으면 자동으로 다시 생성되며 플레이어는 WASD 키로 자유롭게 이동하고 마우스 클릭으로 총알을 발사할 수 있습니다.



## 주요 특징

- **Enemy Spawner**  
  7개의 무지개 색 큐브 적이 계속 스폰 & 제거 → 최대 70명까지 로테이션

- **플레이어 이동**  
  Rigidbody와 AddForce를 활용하여 스피어 모양 플레이어가 자연스럽게 굴러감  
  WASD 키로 상하좌우 자유 이동

- **총알 발사**  
  마우스 클릭한 방향으로 총알 Prefab 발사, AddForce 적용

- **상황 표시 UI**  
  적 숫자, 죽인 적 수, 포인트, 플레이어 HP 등 실시간 정보 표시

- **엔딩 처리**  
  일정 점수 도달 시 엔딩 처리되며, 플레이어 사망 시 게임 종료



## 실행 방법

1. Unity Hub에서 프로젝트 열기
2. Unity 2021.3 LTS 이상 권장
3. 'Assets/Scenes
/SampleScene.unity' 씬 실행.
4. **Play 버튼** 클릭 후:
 - WASD 키로 이동
 - 마우스 클릭으로 총알 발사
 - 적 스폰 & UI 상황 표시 확인


## 시연 영상


https://github.com/user-attachments/assets/5a0c95fe-4b7d-40cf-9be7-8d376be0d7a8




