using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchTest : MonoBehaviour {

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;

    private GameObject lineGO;
    private LineRenderer lineRenderer;
    private int i = 0;
    private bool lastState = false;

    void Start()
    {
        lineGO = new GameObject("Line");
        lineGO.AddComponent<LineRenderer>();
        lineRenderer = lineGO.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 20f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                lastState = true;
                Debug.Log("we hit something");
                Destroy(hit.transform.gameObject); 
            }
            else
                lastState = false;

        }

        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && lastState == true)
        {
            lineRenderer.positionCount = i + 1;
            Vector3 mPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 40);
            lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
            i++;
        }

        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended && lastState == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 20f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("we hit something");
                Destroy(hit.transform.gameObject);
            }
            if (lastState == true)
            {
                lineRenderer.positionCount = 0;
                i = 0;
            }
            lastState = false;
        }
    }
}
