using System;
using System.Collections;
using Unity.Mathematics;
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

    [Header("Lecture Angry")]
    [SerializeField] private float timeMines;
    [SerializeField] private float awakeAdd;


    [SerializeField] private Animator animator;

    public static Action LectureAngry;



    private void OnEnable()
    {
        GameManager.OnStart += LectureSetUp;
        LectureAngry += PlayerGotNoticed;
    }

    private void OnDisable()
    {
        GameManager.OnStart -= LectureSetUp;
        LectureAngry -= PlayerGotNoticed;
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


            float teachingDelay = UnityEngine.Random.Range(minTeachingDelay, maxTeachingDelay);
            animator.SetBool("isLooking",false);

            yield return new WaitForSeconds(teachingDelay);


            // ====================
            // OTW NENGOK STATE
            // ====================


            //spriteRenderer.color = Color.yellow;
            lectureNotification.SetActive(true);

            yield return new WaitForSeconds(1f);


            // ====================
            // LOOKING STATE
            // ====================

            isTeaching = false;
            isLooking = true;

            Debug.Log("Guru nengok");

            //spriteRenderer.color = Color.red;
            animator.SetBool("isLooking", true);
            float lookingDelay = UnityEngine.Random.Range(minLookingDelay, maxLookingDelay);

            float timer = 0f;

            while (timer < lookingDelay)
            {
                // Player tidak fokus
                if (!Player.instance.ReturnConcetrate())
                {
                    LectureAngry?.Invoke();
                    SoundManager.instance.PlaySFX(SoundManager.instance.tableSlap);
                    yield return new WaitForSeconds(0.3f);
                    SoundManager.instance.PlaySFX(SoundManager.instance.mad);
                    yield return new WaitForSeconds(0.3f);
                    // langsung balik ke teaching
                    break;
                }

                timer += Time.deltaTime;

                yield return null;
            }
        }
    }

    public void PlayerGotNoticed()
    {
        AwakeBar.instance.AddAwakeInstan(awakeAdd);
        TimerManager.instance.MinesTime(timeMines);
    }

}