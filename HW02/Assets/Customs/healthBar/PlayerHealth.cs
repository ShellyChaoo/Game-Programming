using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;
    public GameObject loseCanvas;
	public HealthBar healthBar;
    public AudioClip hurtSE;
    public AudioSource audioPlayer;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;
    private Animator e1_animator;
    private Animator e2_animator;
    private Animator e3_animator;
	private int victoryState;


    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        enemy1 = GameObject.Find("TurtleShellPBR");
        enemy2 = GameObject.Find("TurtleShellPBR (1)");
        enemy3 = GameObject.Find("Slime");
        e1_animator = enemy1.GetComponent<Animator>();
        e2_animator = enemy2.GetComponent<Animator>();
        e3_animator = enemy3.GetComponent<Animator>();
        victoryState = Animator.StringToHash("Base Layer.Victory");
        // oriPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool canvas = loseCanvas.activeSelf;
        if(!canvas)
        {
            if (currentHealth <= 0)
            {
                loseCanvas.SetActive(true);
                if (e1_animator) EnemyAnim(e1_animator,victoryState);
                if (e2_animator) EnemyAnim(e2_animator,victoryState);
                if (e3_animator) EnemyAnim(e3_animator,victoryState);
            }
            
        }
        if (currentHealth > 0 )
        {
            loseCanvas.SetActive(false);
            if (e1_animator) e1_animator.SetBool("Enemywin",false);
            if (e2_animator) e2_animator.SetBool("Enemywin",false);
            if (e3_animator) e3_animator.SetBool("Enemywin",false);
        }
        if (gameObject.transform.position.y<-3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            TakeDamage(5);
            PlaySE();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            TakeDamage(5);
            PlaySE();
        }
    }
    public void PlaySE()
    {
        audioPlayer.PlayOneShot(hurtSE);
    }

    private void EnemyAnim(Animator m_animator,int vicState)
    {
        AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
        if (state.fullPathHash != vicState){
            m_animator.SetBool("Enemywin", true);
        }
    }
}
