using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableController : MonoBehaviour
{
    [SerializeField] private List<Color> listColor;
    [SerializeField] private SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        var index = Random.Range(0, listColor.Count);
        var color = listColor[index];
        mySpriteRenderer.color = color;  // Hatalı yazım düzeltildi
    }
}
