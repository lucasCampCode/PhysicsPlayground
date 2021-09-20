using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanimaBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementBehaviour _movement;
    [SerializeField]
    private Gradient _healthGradiant;
    [SerializeField]
    private Image _fill;
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _movement.Stamina;
        _fill.color = _healthGradiant.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _movement.Stamina;
        _fill.color = _healthGradiant.Evaluate(_slider.value / _slider.maxValue);
    }
}
