using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Zoomer : MonoBehaviour{

    private CanvasGroup _Group;
    private CanvasGroup Group{ //make sure group is always called after the function
        get{
            if(_Group == null) _Group = GetComponent<CanvasGroup>();
            return _Group;
        }
    }
    
    public void ZoomIn(){
        gameObject.SetActive(true);
        T.Kill();
        T = DOTween.To(() => Group.alpha, x => Group.alpha = x, 1, 0.2f);//0.2秒內慢慢把Group.alpha數值變成1
    }

    private Tweener T;
    public void ZoomOut(){
        T.Kill();
        T = DOTween.To(() => Group.alpha, x => Group.alpha = x, 0, 0.2f).OnComplete(() => {//0.2秒內慢慢把Group.alpha數值變成0,並在完成後關閉自身go
            gameObject.SetActive(false);
        });
        
    }
}
