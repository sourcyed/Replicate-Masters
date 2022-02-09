using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Vector2 tileSize;
    public Vector2 tileOffset;
    public bool setTilingOnStart = false;
    public bool ignoreX;
    public bool ignoreY;
    public MeshRenderer mRenderer;


    // Start is called before the first frame update
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        if (ignoreX)
        {
            tileSize.x = transform.localScale.x;
        }
        if (ignoreY)
        {
            tileSize.y = transform.localScale.z;
        }
        if (setTilingOnStart)
        {
            SetMaterialTiling();
        }
    }

    public void SetMaterialTiling()
    {
        mRenderer.material.mainTextureScale = new Vector2(transform.localScale.x / tileSize.x, transform.localScale.z / tileSize.y);
        mRenderer.material.mainTextureOffset = tileOffset;
    }
}
