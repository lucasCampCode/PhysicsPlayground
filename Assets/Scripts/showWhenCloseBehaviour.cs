using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenCloseBehaviour : MonoBehaviour
{
    
    public GameObject player;
    public float radius = 10;

    private TextMesh _text;
    private Color _originalColor;
    private Color _opaqeColor;
    private void Awake()
    {
        _text = GetComponent<TextMesh>();
        _originalColor = _text.color;
        _opaqeColor = _text.color;
        _opaqeColor.a = 1;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 distance = player.transform.position - transform.position;
        if(distance.magnitude < radius)
        {
            _text.color = Color.Lerp(_opaqeColor,_originalColor, distance.magnitude/radius);
        }
    }
}
