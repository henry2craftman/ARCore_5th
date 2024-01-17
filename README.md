## 📌 ARCore 프로젝트란?
- ARCore의 기능들을 사용하여 기능을 구현하였습니다.
- Face, Image, Plane, Point cloud, GPS, Compass, Geospatial API, Geospatial Creator 등 

<br>

<h2 id="table-of-contents">📌 목 차</h2>

- ### 프로젝트 리스트

  - [Face Detection](https://github.com/henry2craftman/ARCore_5th/tree/main/Assets/Main/FaceDetection)
  - [Image Detection](https://github.com/henry2craftman/ARCore_5th/tree/main/Assets/Main/ImageDetection)
  - [Plane Detection](https://github.com/henry2craftman/ARCore_5th/tree/main/Assets/Main/PlaneDetection)
  - [GPS와 Compass](https://github.com/henry2craftman/ARCore_5th/tree/main/Assets/Main/PlaneDetection)
  - [Geospatial](https://github.com/henry2craftman/ARCore_5th/tree/main/Assets/Main/GeoSpatial)

<br>

## 📌 프로젝트 세부내용
- ### Face Detection
- AR Core의 AR Face Manager를 사용하여 전방 카메라의 얼굴을 감지, 얼굴의 모든 468개의 Facial features를 정점으로 갖는 Mesh 생성
- 얼굴의 특정 위치에 Animation이 있는 3D 오브젝트를 놓아 필터를 생성
- 자세한 내용은 Link를 클릭해 주세요.

<br>
  
- ### Image Detection
<img src="/Assets/Main/FaceDetection/screenshot1.png" width="100%" height="100%" title="px(픽셀) 크기 설정" alt="FaceDetectionApp"></img>
- AR Core의 AR Tracked Image Manager를 사용하여 Reference Image Library에 등록된 Logo 이미지 감지
- 자세한 내용은 Link를 클릭해 주세요.

<br>
 
- ### Plane Detection
<img src="/Assets/Main/FaceDetection/screenshot1.png" width="100%" height="100%" title="px(픽셀) 크기 설정" alt="FaceDetectionApp"></img>
- AR Core의 AR Plane Manager를 사용하여 Plane을 감지하여 바닥에 Mesh 생성
- AR Raycast Manager와 Screen touch를 이용하여 스크린으로 부터 쏜 레이가 바닥에 닿을 때 Indicator를 위치
- 자세한 내용은 Link를 클릭해 주세요.

<br>
 
- ### GPS Manager & Compass Manager
<img src="/Assets/Main/FaceDetection/screenshot1.png" width="100%" height="100%" title="px(픽셀) 크기 설정" alt="FaceDetectionApp"></img>
- 내 Mobile Device의 GPS센서를 사용하여, 내 현재 위도, 경도를 화면에 그릴 수 있다.
- Compass 센서를 사용하여 화면에 나침반을 그릴 수 있다.

<br>
 
- ### Geospatial ASI & Geospatial Creator
<img src="/img.png" width="100%" height="100%" title="px(픽셀) 크기 설정" alt="FaceDetectionApp"></img>
- Google Cloud Platform의 Geospatial API를 사용하여 특정 위치에 물체를 놓을 수 있다.
- Google Cloud Platform의 Geospatial Creator를 사용하여 특정 위도, 경도, 고도에 3D Mesh를 생성할 수 있다.

[목차로 돌아가기](#table-of-contents)
