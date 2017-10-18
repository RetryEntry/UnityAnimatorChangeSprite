using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappedTextures : MonoBehaviour {
    public Texture2D swappedTexture = null;

    private SpriteRenderer thisRenderer;
    private void Awake()
    {
        thisRenderer = GetComponent<SpriteRenderer>();
        if (thisRenderer)
        {
            Shader _swapShader = Shader.Find("Custom/SwapTwo");
            if (!_swapShader)
            {
                Debug.LogError("You dont have shader... ");
            }
            else
            {
                Material _newMat = new Material(_swapShader);
                thisRenderer.material = _newMat;
                thisRenderer.material.SetTexture("_MainTex2", swappedTexture);
            }
        }
        else
        {
            Debug.LogError("There is NO spriterenderer attached to gameobject " + this.name);
        }
    }

    /// <summary>
    /// this will swap our used animator texture to another one
    /// </summary>
    /// <param name="_toWhat"></param>
    public void SwapTexture(Texture2D _toWhat)
    {
        swappedTexture = _toWhat;
        if (thisRenderer)
        {
            Shader _swapShader = Shader.Find("Custom/SwapTwo");
            if (!_swapShader)
            {
                Debug.LogError("You dont have shader... ");
            }
            else
            {
                Material _newMat = new Material(_swapShader);
                thisRenderer.material = _newMat;
                thisRenderer.material.SetTexture("_MainTex2", swappedTexture);
            }
        }
        else
        {
            Debug.LogError("There is NO spriterenderer attached to gameobject " + this.name);
        }
    }

    public void Update()
    {
        if (swappedTexture != null)
        {
            SwapTexture(swappedTexture);
            swappedTexture = null;
        }
    }
}
