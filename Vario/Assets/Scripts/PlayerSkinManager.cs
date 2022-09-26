using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Sprite DefaultSkin;
    public Sprite JumpSkin;
    public Sprite RunSkin;

    public void ChangeSkin(Sprite skin)
    {
        GetComponent<SpriteRenderer>().sprite = skin;
    }

    private static PlayerSkinManager _instance;
    
    public static PlayerSkinManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
}
