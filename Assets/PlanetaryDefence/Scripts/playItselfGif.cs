using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playItselfGif : MonoBehaviour
{
    // Start is called before the first frame update
    public string gifUrlInput;
    private bool m_mutex;
    public UniGifImage gifImage;
    void Start()
    {
        
        if (m_mutex || gifImage == null || string.IsNullOrEmpty(gifUrlInput))
        {
            return;
        }
        m_mutex = true;
        StartCoroutine(ViewGifCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private IEnumerator ViewGifCoroutine()
    {
        yield return StartCoroutine(gifImage.SetGifFromUrlCoroutine(gifUrlInput));
        m_mutex = false;
    }
}
