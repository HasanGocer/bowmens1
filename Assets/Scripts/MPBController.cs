using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBController : MonoBehaviour
{
    //KULLANILMIYOR

    [SerializeField] private Color mainColor = Color.black;

    private Renderer _renderer = null;
    private MaterialPropertyBlock _materialPropertyBlock = null;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void SetColor()
    {
        _materialPropertyBlock.SetColor(name: "_color", mainColor);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }
}
