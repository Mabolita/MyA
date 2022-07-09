using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWin : MonoBehaviour
{
    public Text wintext;
    DontDestroy _dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        _dontDestroy = FindObjectOfType<DontDestroy>();

        if (_dontDestroy != null)
        {
            wintext.text = "" + _dontDestroy.Score;
           
        }

    }

}
