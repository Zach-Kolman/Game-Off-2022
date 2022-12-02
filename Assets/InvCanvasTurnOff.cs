using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvCanvasTurnOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TurnOff());
    }

    // Update is called once per frame
    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
