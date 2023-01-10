using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    void Start()
    {
        //オブジェクトの色をセット
        Renderer.material.color = new Color32(255, 255, 255, _alpha);

        //オブジェクトスケール
        _scale = new Vector3(0,0,0);
    }

    void Update()
    {
        //α値を下げつつオブジェクトの色をセット
        Renderer.material.color = new Color32(255, 255, 255, _alpha);

        //オブジェクトのスケールをセット
        transform.localScale = _scale;

        //少し拡大する
        _scale.x += 10.0f * Time.deltaTime;
        _scale.y += 10.0f * Time.deltaTime;
        //スケールの値が1.０を超えないようにする
        _scale = Vector3.Min(_scale,  Vector3.one);

        //少し透明にする
        _alpha -= 8;

        //ほとんど透明になったらオブジェクトを削除する
        if(_alpha < 8){
            Destroy(gameObject);
        }
    }

    Renderer _renderer = null;
    public Renderer Renderer {
        get { return _renderer ?? (_renderer = gameObject.GetComponent<Renderer> ()); }
    }

    Vector3 _scale;
    byte _alpha = 255;
}
