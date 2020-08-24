using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    // Start is called before the first frame update
    public float visibleHeight = -0.811f;
    public float hiddenHeight = -1.228f;
    public float speed = 4f;

    public float disappearDuration = 0.5f;
    private float disappearTimer = 0.0f;
    private Vector3 targetPosition;
    void Awake()
    {
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z
            );
        transform.localPosition = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0f)
        {
            Hide();
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime*speed);
    }

    public void Rise()
    {
        targetPosition = new Vector3(
         transform.localPosition.x,
         visibleHeight,
         transform.localPosition.z
         );

        disappearTimer = disappearDuration;
    }


   public void Hide()
    {
        targetPosition = new Vector3(
          transform.localPosition.x,
          hiddenHeight,
          transform.localPosition.z
          );
    }

    public void OnHit()
    {
        Hide();
    }
}
