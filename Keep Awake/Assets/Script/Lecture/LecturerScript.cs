using System.Collections;
using UnityEngine;

public class LecturerScript : MonoBehaviour
{
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private float delay;
    [SerializeField] private bool isTeaching;


    [SerializeField] private float lookingTime;
    [SerializeField] private bool isLooking;

    private void Update()
    {

    }

    public void RandomDelay()
    {
        delay = Random.Range(minDelay, maxDelay);
    }

    private IEnumerator LectureTeaching(float delay)
    {
        isTeaching = true;
        yield return new WaitForSeconds(delay);
        isTeaching = false;
        //nengok
    }
}
