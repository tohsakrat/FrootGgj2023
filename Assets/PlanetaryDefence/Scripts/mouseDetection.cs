using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
           // print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            float step = 200 * Time.deltaTime;  
           // gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition), step); 
           Vector3 dirPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           dirPosition.z = 0;
            this.transform.position =   dirPosition;
            }
    }
}
