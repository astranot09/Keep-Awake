//using System.Collections;
//using UnityEngine;

//public class LecturerScript : MonoBehaviour
//{
//    [Header("Teaching")]
//    [SerializeField] private float minTeachingDelay = 3f;
//    [SerializeField] private float maxTeachingDelay = 7f;

//    [Header("Looking")]
//    [SerializeField] private float minLookingDelay = 2f;
//    [SerializeField] private float maxLookingDelay = 4f;

//    [Header("State")]
//    [SerializeField] private bool isTeaching;
//    [SerializeField] private bool isLooking;

//    private SpriteRenderer spriteRenderer;

//    private void OnEnable()
//    {
//        GameManager.OnStart += LectureSetUp;
//    }
//    private void OnDisable()
//    {
//        GameManager.OnStart -= LectureSetUp;
//    }

//    private void LectureSetUp()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        StartCoroutine(TeachingState());
//    }


//    private IEnumerator TeachingState()
//    {
//        isTeaching = true;
//        isLooking = false;

//        float delay = Random.Range(minTeachingDelay, maxTeachingDelay);

//        Debug.Log("Guru mengajar");
//        spriteRenderer.color = Color.white;

//        yield return new WaitForSeconds(delay);

//        StartCoroutine(LookingState());
//    }

//    private IEnumerator LookingState()
//    {
//        isTeaching = false;
//        isLooking = true;

//        float delay = Random.Range(minLookingDelay, maxLookingDelay);

//        Debug.Log("Guru nengok");
//        spriteRenderer.color = Color.red;

//        float timer = 0f;

//        while (timer < delay)
//        {
//            if (!Player.instance.ReturnConcetrate())
//            {
//                Debug.Log("Ketahuan");

//                StartCoroutine(TeachingState());

//                yield break;
//            }

//            timer += Time.deltaTime;

//            yield return null;
//        }

//        StartCoroutine(TeachingState());
//    }
//}

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

    private Coroutine lectureCoroutine;

    private void OnEnable()
    {
        GameManager.OnStart += LectureSetUp;
    }

    private void OnDisable()
    {
        GameManager.OnStart -= LectureSetUp;
    }

    private void LectureSetUp()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Biar ga double coroutine
        if (lectureCoroutine != null)
            StopCoroutine(lectureCoroutine);

        lectureCoroutine = StartCoroutine(LectureLoop());
    }

    private IEnumerator LectureLoop()
    {
        while (true)
        {
            // ====================
            // TEACHING STATE
            // ====================

            isTeaching = true;
            isLooking = false;

            Debug.Log("Guru mengajar");

            spriteRenderer.color = Color.white;

            float teachingDelay = Random.Range(minTeachingDelay, maxTeachingDelay);

            yield return new WaitForSeconds(teachingDelay);


            // ====================
            // LOOKING STATE
            // ====================


            spriteRenderer.color = Color.yellow;
            yield return new WaitForSeconds(1f);

            // ====================
            // LOOKING STATE
            // ====================

            isTeaching = false;
            isLooking = true;

            Debug.Log("Guru nengok");

            spriteRenderer.color = Color.red;

            float lookingDelay = Random.Range(minLookingDelay, maxLookingDelay);

            float timer = 0f;

            while (timer < lookingDelay)
            {
                // Player tidak fokus
                if (!Player.instance.ReturnConcetrate())
                {
                    LectureAngry();

                    yield return new WaitForSeconds(1f);
                    // langsung balik ke teaching
                    break;
                }

                timer += Time.deltaTime;

                yield return null;
            }
        }
    }

    public void LectureAngry()
    {
        Debug.Log("Ketahuan");
    }


}