using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Object
{
    protected string _desc = "";        // object 설명
    protected string _info = "";        // 영양 정보
    protected bool _isSall = false;     // 팔수 있는지 없는지(재고관리)
    protected float _width = 0.0f;      // 물체의 가로길이
    protected float _height = 0.0f;     // 물체의 세로길이

    [SerializeField]
    protected ITEM_ACTIVE _itemActive;      // 아이템 클릭 상태

    public string getDesc
    {
        get
        {
            return _desc;
        }
    }

    public string getInfo
    {
        get{
            return _info;
        }
    }
    
    public bool getIsSall
    {
        get
        {
            return _isSall;
        }
    }

    public float getWidth
    {
        get
        {
            return _width;
        }
    }
    
    public float getHeight
    {
        get
        {
            return _height;
        }
    }

    public ITEM_ACTIVE getActive
    {
        get
        {
            return _itemActive;
        }
    }
    
    protected ITEM_ACTIVE setActive
    {
        set
        {
            _itemActive = value;
        }
    }
}
