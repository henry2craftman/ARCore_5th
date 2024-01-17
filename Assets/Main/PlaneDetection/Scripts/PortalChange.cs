using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PortalChange : MonoBehaviour
{
    [SerializeField] UniversalRendererData scriptableRendererData;
    

    public void OnBtnClkEvent()
    {
        UniversalRendererData data = GetUniversalRendererData(0);
        int mask = data.opaqueLayerMask;
        data.opaqueLayerMask ^= (1 << 7); // toggle opagueLayer
    }

    // �������������� ���� ����
    public static RenderPipelineAsset GetRenderPipelineAsset()
    {
        return GraphicsSettings.renderPipelineAsset;
    }

    // ���������� ���� ����Ʈ ����
    public static ScriptableRendererData[] GetScriptableRendererDatas()
    {
        RenderPipelineAsset pipelineAsset = GetRenderPipelineAsset();
        if (!pipelineAsset) return null;

        FieldInfo propertyInfo = pipelineAsset.GetType().GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic);
        ScriptableRendererData[] scriptableRendererDatas = propertyInfo.GetValue(pipelineAsset) as ScriptableRendererData[];
        return scriptableRendererDatas;
    }

    // Universal���� ������ ����(�⺻ ����)
    public static UniversalRendererData GetUniversalRendererData(int rendererListIndex = 0)
    {
        ScriptableRendererData[] scriptableRendererDatas = GetScriptableRendererDatas();
        if (scriptableRendererDatas == null || scriptableRendererDatas.Length <= 0) return null;

        UniversalRendererData universalRendererData =
            scriptableRendererDatas[rendererListIndex] as UniversalRendererData;
        return universalRendererData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Door"))
        {
            OnBtnClkEvent();
        }
    }
}
