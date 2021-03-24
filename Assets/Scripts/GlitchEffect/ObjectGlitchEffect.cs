using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGlitchEffect : MonoBehaviour
{

    private Renderer rend;
    public float targetValue = 1f;
    public float currentValue = 1.1f;
    private float randTimeVal;
    public float lerpSpeed = 2f;

    public float countDown;

    private bool hasGlitched;
        
    // Start is called before the first frame update
    void Start()
    {
        rend = transform.GetComponent<Renderer>();
        randTimeVal = Random.Range(0.7f, 1.5f);
        targetValue = Random.Range(0.3f, 1f);
        countDown = Random.Range(0.7f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = Mathf.Lerp(currentValue, targetValue, lerpSpeed * Time.deltaTime);
        
        if (randTimeVal > 0)
        {
            randTimeVal -= Time.deltaTime;
        }
        else
        {
            Glitch();
        }
    }

    private void Glitch()
    {
        
        if (!hasGlitched)
        {
            targetValue = Random.Range(0.3f, 1f);
            rend.material.SetFloat("_ChangePercent", currentValue);
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                targetValue = 1.1f;
                currentValue = 1.1f;
                rend.material.SetFloat("_ChangePercent", currentValue);
                hasGlitched = true;
            }
        }
        else
        {
            randTimeVal = Random.Range(0.3f, 1f);
            countDown = Random.Range(0.7f, 1.5f);
            targetValue = Random.Range(0.3f, 1f);
            hasGlitched = false;
        }
    }
}
