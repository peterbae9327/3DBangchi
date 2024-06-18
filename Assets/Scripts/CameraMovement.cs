using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(CameraZoomOut());
    }
    IEnumerator CameraZoomOut()
    {
        while(gameObject.transform.position.y < 40)
        {
            gameObject.transform.position += Vector3.up*Time.deltaTime*10;
            yield return null;
        }
        gameObject.transform.position = new Vector3(0, 40, 0);
    }
}
