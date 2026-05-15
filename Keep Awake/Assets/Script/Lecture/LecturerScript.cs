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

    [Header("Notification")]
    [SerializeField] private GameObject lectureNotification;

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
            lectureNotification.SetActive(false);


            float teachingDelay = Random.Range(minTeachingDelay, maxTeachingDelay);

            yield return new WaitForSeconds(teachingDelay);


            // ====================
            // OTW NENGOK STATE
            // ====================


            spriteRenderer.color = Color.yellow;
            lectureNotification.SetActive(true);

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
                    SoundManager.instance.PlaySFX(SoundManager.instance.tableSlap);

                    yield return new WaitForSeconds(0.3f);
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