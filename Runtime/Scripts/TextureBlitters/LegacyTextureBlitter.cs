﻿using UnityEngine;

namespace Unity.StreamingImageSequence {

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
internal class LegacyTextureBlitter : MonoBehaviour {    
    
    void Awake() {
        m_camera = GetComponent<Camera>();
        
        //Render nothing
        m_camera.clearFlags  = CameraClearFlags.Depth;
        m_camera.cullingMask = 0;        
    }

//----------------------------------------------------------------------------------------------------------------------    
    
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (null == m_texture) 
            return;

        if (null == m_blitMaterial) {
            Graphics.Blit(m_texture, destination);
            return;
        }
        
        Graphics.Blit(m_texture, destination, m_blitMaterial);
    }    

//----------------------------------------------------------------------------------------------------------------------    

    internal void SetTexture(Texture tex) { m_texture = tex; }
    internal void SetBlitMaterial(Material blitMat) { m_blitMaterial = blitMat; }
    internal void SetCameraDepth(int depth) { m_camera.depth = depth; }
    
//----------------------------------------------------------------------------------------------------------------------    

    [SerializeField] private Texture  m_texture;    
    [SerializeField] Material m_blitMaterial = null;
    
    private Camera m_camera;
}

} //end namespace