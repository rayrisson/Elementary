using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    bool movableBrick = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 1.0f, Space.World);
    }

    IEnumerator MoveBrick(){
        movableBrick = false;
        
        transform.Translate(Vector3.up * Time.deltaTime * 0.7f, Space.World);
        
        yield return new WaitForSeconds (4);
        yield return new WaitForSeconds (10);
        transform.Translate(Vector3.down * Time.deltaTime * 0.7f, Space.World);
        yield return new WaitForSeconds (4);
    }
}
