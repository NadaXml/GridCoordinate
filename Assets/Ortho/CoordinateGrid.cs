using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CoordinateGrid : MonoBehaviour {
    public Transform ModelSpace;
    public Material lineMaterial;

    private void OnEnable() {
        RenderPipelineManager.endCameraRendering += RenderGrid;
    }

    private void OnDisable() {
        RenderPipelineManager.endCameraRendering -= RenderGrid;
    }

    void RenderGrid(ScriptableRenderContext context, Camera camera) {
        RenderGridImp();
    }

    void RenderGridImp() {
        if (lineMaterial == null) {
            return;
        }
        GL.PushMatrix();
        lineMaterial.SetPass(0);
        GL.Begin(GL.LINES);
        Vector3 xGrid = ModelSpace.transform.forward;
        Vector3 zGrid = ModelSpace.transform.right;
        int gridNum = 20;
        // 绘制世界空间网格
        Vector3 origin = ModelSpace.transform.position;
        // x轴
        for (int i = -gridNum; i < gridNum; i++) {
            GL.Vertex(origin + i * xGrid - zGrid * gridNum);
            GL.Vertex(origin + i * xGrid + zGrid * gridNum);
        }
        // z轴
        for (int i = -gridNum; i < gridNum; i++) {
            GL.Vertex(origin + i * zGrid - xGrid * gridNum);
            GL.Vertex(origin + i * zGrid + xGrid * gridNum);
        }
        GL.End();
        GL.PopMatrix();
    }
    
    private void OnRenderObject() {
        // RenderGridImp();
    }
}
