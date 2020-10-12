﻿#if AT_USE_HDRP

using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace Unity.StreamingImageSequence {

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(HDAdditionalCameraData))]

internal class HDRPTextureEndFrameBlitter : MonoBehaviour {


    private void Awake() {
        m_camera = GetComponent<Camera>();
        m_hdData = GetComponent<HDAdditionalCameraData>();

        //Render nothing
        m_camera.clearFlags            = CameraClearFlags.Nothing;
        m_camera.cullingMask           = 0;
        m_hdData.fullscreenPassthrough = true;
    }
//----------------------------------------------------------------------------------------------------------------------

    private void OnEnable() {
        UnityEngine.Rendering.RenderPipelineManager.endFrameRendering += BlitEndFrame;                
    }

    private void OnDisable() {
        UnityEngine.Rendering.RenderPipelineManager.endFrameRendering -= BlitEndFrame; 
        
    }

    
//----------------------------------------------------------------------------------------------------------------------
    void BlitEndFrame(UnityEngine.Rendering.ScriptableRenderContext context, Camera[] cams) {
        
        if (null == m_texture)
            return;
        
        //only blit for specified camera type
        foreach (Camera cam in cams) {
            if (cam.cameraType != m_targetCameraType)
                return;            
        }
        
        if (null == m_blitMaterial) {
            Graphics.Blit(m_texture, (RenderTexture) null);
            return;
        }
        Graphics.Blit(m_texture, (RenderTexture) null, m_blitMaterial);
        
    }         

//----------------------------------------------------------------------------------------------------------------------

    internal void SetTexture(Texture tex) { m_texture = tex; }

    internal void SetBlitMaterial(Material blitMat) { m_blitMaterial = blitMat; }

    internal void SetCameraDepth(int depth) { m_camera.depth = depth; }

    internal void SetTargetCameraType(CameraType cameraType) { m_targetCameraType = cameraType; }

//----------------------------------------------------------------------------------------------------------------------    

    [SerializeField] private Texture    m_texture;
    [SerializeField] private Material   m_blitMaterial     = null;
    [SerializeField] private CameraType m_targetCameraType = CameraType.Game;

    private Camera                 m_camera;
    private HDAdditionalCameraData m_hdData;
}

} //end namespace 

#endif // AT_USE_HDRP