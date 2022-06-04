using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UICanvasPlayer : MonoBehaviour
{
    [SerializeField] RectTransform[] _crossHairs = new RectTransform[0];

    Vector2[] _crossHairBasePos = new Vector2[0];
    // Start is called before the first frame update
    void Start()
    {
        _crossHairBasePos = new Vector2[_crossHairs.Length];
        for(int i = 0; i < _crossHairs.Length; i++)
        {
            _crossHairBasePos[i] = _crossHairs[i].anchoredPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ExpandCrossHair()
    {
        if(_crossHairs[0].anchoredPosition.y > 125f) return;

        Sequence seq = DOTween.Sequence();
        seq.Join(_crossHairs[0].DOPunchAnchorPos(_crossHairs[0].anchoredPosition + new Vector2(0, 25f), 0.2f));
        seq.Join(_crossHairs[1].DOPunchAnchorPos(_crossHairs[1].anchoredPosition + new Vector2(0, -25f), 0.2f));
        seq.Join(_crossHairs[2].DOPunchAnchorPos(_crossHairs[2].anchoredPosition + new Vector2(-25f, 0), 0.2f));
        seq.Join(_crossHairs[3].DOPunchAnchorPos(_crossHairs[3].anchoredPosition + new Vector2(+25f, 0), 0.2f));
        seq.AppendCallback(() =>
        {
            for(int i = 0; i < _crossHairs.Length; i++)
            {
                _crossHairs[i].anchoredPosition = _crossHairBasePos[i];
            }
        });
    }
}
