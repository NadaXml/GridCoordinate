using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class ProjCoordinate : MonoBehaviour {

    public Camera SceneCamera;
    public Transform BgSpace;
    public Transform ModelSpace;
    /// <summary>
    /// 没有转成斜坐标系的坐标系点
    /// </summary>
    public Transform testPoint;

    /// <summary>
    /// init for coordinate and setup Transform
    /// </summary>
    public void InitCoordinate() {
        
    }
    
    
    
    public void OnDrawGizmos() {
        DrawGizmos_Camera();
        DrawGizmos_Model();
        DrawGizmos_BgSpace();
    }

    /// <summary>
    /// 绘制背景图空间辅助线
    /// </summary>
    void DrawGizmos_BgSpace() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BgSpace.transform.position, 0.2f);
        Gizmos.DrawRay(BgSpace.transform.position - SceneCamera.transform.forward * 200f, SceneCamera.transform.forward * 1000f);
        
        // 绘制测试点
        Gizmos.DrawSphere(testPoint.transform.position, 0.2f);
        // 绘制穿越射线
        Gizmos.DrawRay(testPoint.transform.position, SceneCamera.transform.forward * 1000f);
    }

    /// <summary>
    /// 绘制摄像机空间辅助线
    /// </summary>
    void DrawGizmos_Camera() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(SceneCamera.transform.position, 0.2f);
        Gizmos.DrawRay(SceneCamera.transform.position, SceneCamera.transform.forward * 1000f);
        
    }

    /// <summary>
    /// 绘制模型空间辅助线
    /// </summary>
    void DrawGizmos_Model() {
        // 绘制远点和坐标轴
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ModelSpace.transform.position, 0.2f);
        Gizmos.DrawRay(ModelSpace.transform.position, ModelSpace.transform.forward * 200f);
        Gizmos.DrawRay(ModelSpace.transform.position, ModelSpace.transform.right * 200f);
        Gizmos.DrawRay(ModelSpace.transform.position, ModelSpace.transform.up * 200f);


        // Vector3 xGrid = ModelSpace.transform.forward;
        // Vector3 zGrid = ModelSpace.transform.right;
        // int gridNum = 20;
        // // 绘制世界空间网格
        // Gizmos.color = Color.black;
        // Vector3 origin = ModelSpace.transform.position;
        // // x轴
        // for (int i = -gridNum; i < gridNum; i++) {
        //     Gizmos.DrawLine(origin + i * xGrid - zGrid * gridNum, origin + i * xGrid + zGrid * gridNum);
        // }
        // // z轴
        // for (int i = -gridNum; i < gridNum; i++) {
        //     Gizmos.DrawLine(origin + i * zGrid - xGrid * gridNum, origin + i * zGrid + xGrid * gridNum);
        // }
        
        Gizmos.color = Color.cyan;
        // 绘制测试点焦点
        Plane plane = new Plane();
        plane.Translate(ModelSpace.transform.position);
        plane.normal = ModelSpace.transform.up;
        Ray ray = new Ray(testPoint.transform.position, SceneCamera.transform.forward * -10000f);
        float enter;
        if (plane.Raycast(ray, out enter)) {
            var hitPoint = ray.GetPoint(enter);
            Gizmos.DrawCube(hitPoint, new Vector3(0.3f,0.3f,0.3f));
        }
    }
}
