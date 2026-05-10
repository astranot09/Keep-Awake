using System.Collections;
using UnityEngine;

public class LecturerScript : MonoBehaviour
{
    [Header("Teaching")]
    [SerializeField] private float minTeachingDelay = 3f;
    [SerializeField] private float maxTeachingDelay = 7f;

    [Header("Looking")]
    [SerializeField] private float minLookingDelay = 2f;
    [SerializeField] private float maxLookingDelay = 4f;

    [Header("State")]
    [SerializeField] private bool isTeaching;
    [SerializeField] private bool isLooking;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TeachingState());
    }

    private IEnumerator TeachingState()
    {
        isTeaching = true;
        isLooking = false;

        float delay = Random.Range(minTeachingDelay, maxTeachingDelay);

        Debug.Log("Guru mengajar");
        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(delay);

        StartCoroutine(LookingState());
    }

    private IEnumerator LookingState()
    {
        isTeaching = false;
        isLooking = true;

        float delay = Random.Range(minLookingDelay, maxLookingDelay);

        Debug.Log("Guru nengok");
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(delay);

        StartCoroutine(TeachingState());
    }
}