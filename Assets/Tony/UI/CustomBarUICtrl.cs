using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CustomBarUICtrl : MonoBehaviour{
    public RectTransform Fill;
    
    [SerializeField]
    private float _value;
    public float Value{
        set{
            _value =  math.clamp(value, 0, 1);
            Fill.localScale = new Vector3(_value, 1, 1);
        }
        get{
            return _value;
        }
    }
}
