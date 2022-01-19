
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	#region Singleton class: GameManager

	public static GameManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	Camera cam;
    public Text lifeText;
    public Text ScoreText;
    public GameObject NextLevelCanvas;
    public GameObject LoseCanvas;
    public SoundsEffect soundsEffect;
	public Cat cat;
	public Trajectory trajectory;
	[SerializeField] float pushForce = 4f;

	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

    private int lifeCount = 0;
    private int score = 103;

	//---------------------------------------
	void Start ()
	{
		cam = Camera.main;
		cat.DesactivateRb ();
        // .ToString()
        lifeText.text = lifeCount.ToString();
	}

	void Update ()
	{
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        bool canvas = NextLevelCanvas.activeSelf;
		if (Input.GetMouseButtonDown (1) && !canvas) 
        {
            isDragging = true;
            OnDragStart ();
		}
		if (Input.GetMouseButtonUp (1) && !canvas) {
            isDragging = false;
            OnDragEnd ();
            lifeCount += 1;
            score -= 3;
            lifeText.text = lifeCount.ToString();
            soundsEffect.PlayMeowSE();
		}

		if (isDragging) {
			OnDrag ();
		}
        if (score==0)
        {
            LoseCanvas.SetActive(true);
        }
        ScoreText.text = score.ToString();
	}

	//-Drag--------------------------------------
	void OnDragStart ()
	{
		cat.DesactivateRb ();
		startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

		trajectory.Show ();
	}

	void OnDrag ()
	{
		endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
		distance = Vector2.Distance (startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine (startPoint, endPoint);


		trajectory.UpdateDots (cat.pos, force);
	}

	void OnDragEnd ()
	{
		//push the cat
		cat.ActivateRb ();

		cat.Push (force);

		trajectory.Hide ();
	}

}