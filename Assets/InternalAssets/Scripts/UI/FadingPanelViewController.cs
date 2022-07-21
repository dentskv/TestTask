using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadingPanelViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private Material _material;
    private Image _image;
    
    private void Start()
    {
        _image = GetComponent<Image>();
        _material = _image.material;
    }

    private void Update()
    {
        _text.color = new Color(1, 1, 1, _material.color.a);
    }
}
