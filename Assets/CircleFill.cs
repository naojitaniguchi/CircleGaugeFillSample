using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFill : MonoBehaviour
{
    public float fillMaxTime = 2.0f;
    public float releaseMaxTime = 0.5f;

    enum CircleMode{
        CIRCLE_FILL,
        CIRCLE_RELEASE,
        NONE
    };

    CircleMode mode;
    float elaspedTime;
    float releaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mode = CircleMode.NONE;
        gameObject.GetComponent<Image>().fillAmount = 0.0f;

        releaseSpeed = 1.0f / releaseMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mode = CircleMode.CIRCLE_FILL;
            elaspedTime = 0.0f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mode = CircleMode.CIRCLE_RELEASE;
            elaspedTime = 0.0f;
        }

        if ( mode == CircleMode.CIRCLE_FILL)
        {
            if (Input.GetMouseButton(0))
            {
                elaspedTime += Time.deltaTime;
                if ( elaspedTime > fillMaxTime)
                {
                    elaspedTime = fillMaxTime;
                }
                float fillRate = elaspedTime / fillMaxTime;
                gameObject.GetComponent<Image>().fillAmount = fillRate;
            }
        }

        if (mode == CircleMode.CIRCLE_RELEASE)
        {
            gameObject.GetComponent<Image>().fillAmount -= releaseSpeed * Time.deltaTime;
            if (gameObject.GetComponent<Image>().fillAmount < 0.0f)
            {
                gameObject.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
    }
}
