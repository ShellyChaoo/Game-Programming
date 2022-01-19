using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
    private Animator m_animator;

    public AudioClip hurtSE;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (currentHealth==0)
        {
            m_animator.SetBool("Die", true);
            Destroy(gameObject,2.5f);
        }
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
        PlaySE();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            TakeDamage(20);
        }
    }
    public void PlaySE()
    {
        audioPlayer.PlayOneShot(hurtSE);
    }
}
