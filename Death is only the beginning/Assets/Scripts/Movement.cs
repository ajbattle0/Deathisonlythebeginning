using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 middlePos;
    public Vector3 endPos;
    public float duration ;
    [SerializeField] bool intro;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameEvents.OnBoatDeparter += MovePuzzleOut;
        GameEvents.OnBoatArrival += MovePuzzleIn;
    }
    private void OnDisable()
    {
        GameEvents.OnBoatArrival -= MovePuzzleIn;
        GameEvents.OnBoatDeparter -= MovePuzzleOut;
    }
    public void MovePuzzleIn()
    {
        StartCoroutine(MoveLocationInCoro());
    }
    IEnumerator MoveLocationInCoro()
    {
        var elapsedTime = 0f;
        var startPos = transform.position;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPos, middlePos, Mathf.SmoothStep(0, 1, percentageComplete));
            
            yield return null;
        }
    }
    public void MovePuzzleOut()
    {
        StartCoroutine(MovePuzzleOutCoro());
    }
    IEnumerator MovePuzzleOutCoro()
    {
        if (intro)
        {
            intro = false;
            yield break;
        }
        var elapsedTime = 0f;
        var startPos = transform.position;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, percentageComplete));
            yield return null;
        }
        this.gameObject.SetActive(false);
    }

}
