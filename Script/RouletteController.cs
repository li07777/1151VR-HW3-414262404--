
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RouletteController : MonoBehaviour
{
    [Header("Spin Settings")]
    public float maxSpeed = 1800f;
    public float acceleration = 2400f;
    public float spinDuration = 5f;
    [Range(0.9f, 0.999f)]
    public float deceleration = 0.985f;

    [Header("Audio")]
    public AudioSource spinSound;
    public AudioSource resultSound;

    [Header("Result UI")]
    public GameObject resultPanel;
    public TMP_Text resultText;
    public Button retryButton;

    [Header("Food Options - Clockwise from Top")]
    public string[] foods =
    {
        "Hot Pot",
        "Ramen",
        "Sushi",
        "Pasta",
        "Fast Food",
        "Korean Food",
        "Drinks",
        "Dessert"
    };

    [Header("Wheel Angle Settings")]
    public float pointerAngle = 90f;
    public float firstFoodAngle = 90f;

    private float rotSpeed = 0f;
    private float timer = 0f;
    private bool spinning = false;

    void Start()
    {
        // Hide result panel at game start
        if (resultPanel != null)
            resultPanel.SetActive(false);

        // Connect retry button
        if (retryButton != null)
            retryButton.onClick.AddListener(RestartSpin);

        // Stop all sounds at start
        if (spinSound != null)
            spinSound.Stop();

        if (resultSound != null)
            resultSound.Stop();
    }

    void Update()
    {
        // Mouse click or touchscreen tap
        if (Input.GetMouseButtonDown(0)
            && !spinning
            && (resultPanel == null ||
                !resultPanel.activeSelf))
        {
            StartSpin();
        }

        if (!spinning)
            return;

        timer += Time.deltaTime;

        // Phase 1: Accelerate and spin fast
        if (timer < spinDuration)
        {
            rotSpeed = Mathf.MoveTowards(
                rotSpeed,
                maxSpeed,
                acceleration * Time.deltaTime
            );
        }
        // Phase 2: Slow down gradually
        else
        {
            rotSpeed *= Mathf.Pow(
                deceleration,
                Time.deltaTime * 60f
            );
        }

        // Rotate wheel clockwise
        transform.Rotate(
            0f,
            0f,
            -rotSpeed * Time.deltaTime
        );

        // Stop when speed becomes very low
        if (timer >= spinDuration && rotSpeed < 2f)
        {
            rotSpeed = 0f;
            spinning = false;

            if (spinSound != null)
                spinSound.Stop();

            ShowResult();
        }
    }

    // Start spinning
    void StartSpin()
    {
        spinning = true;
        timer = 0f;
        rotSpeed = 0f;

        // Stop previous result sound
        if (resultSound != null)
            resultSound.Stop();

        // Play spinning sound
        if (spinSound != null)
            spinSound.Play();
    }

    // Show final result
    void ShowResult()
    {
        if (foods == null || foods.Length != 8)
        {
            Debug.LogError(
                "Please set exactly 8 food options."
            );
            return;
        }

        // Current rotation angle
        float wheelRotation =
            transform.eulerAngles.z;

        // Convert pointer angle to local wheel angle
        float localAngle = Mathf.Repeat(
            pointerAngle - wheelRotation,
            360f
        );

        // Calculate clockwise food index
        float clockwiseAngle = Mathf.Repeat(
            firstFoodAngle - localAngle,
            360f
        );

        // Each section is 45 degrees
        int index = Mathf.FloorToInt(
            (clockwiseAngle + 22.5f) / 45f
        ) % 8;

        string food = foods[index];

        Debug.Log("Wheel Angle: " + wheelRotation);
        Debug.Log("Selected Food: " + food);

        // Update result text in English
        if (resultText != null)
        {
            resultText.text =
                "WHAT TO EAT TODAY?\n\n" +
                "You got: " + food + "!\n" +
                "Enjoy your meal!";
        }

        // Show result panel
        if (resultPanel != null)
            resultPanel.SetActive(true);

        // Play result sound once
        if (resultSound != null)
            resultSound.Play();
    }

    // Spin again
    public void RestartSpin()
    {
        if (resultPanel != null)
            resultPanel.SetActive(false);

        StartSpin();
    }
}
