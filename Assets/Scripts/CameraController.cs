using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    public bool isShake;

    // How long the object should shake for.
    public float shake = 0.4f;
    public float shakeCnt = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        shakeCnt = shake;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }    

	// Use this for initialization
	void Start () {
        shakeCnt = shake;
    }
	
	// Update is called once per frame
	void Update () {
        if(isShake)
        {
            if (shakeCnt > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeCnt -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                isShake = false;
                shakeCnt = shake;
                camTransform.localPosition = originalPos;
            }
        }        
    }

    public void EnableShake()
    {
        isShake = true;
        shakeCnt = shake;
    }
}
