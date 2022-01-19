using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTeaserControl : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float frequency = 1f;
    public GameObject teaser;
    // Position Storage Variables
    Vector2 tempPos = new Vector2 ();
    private GameObject tempTeaser;
    private Animator m_animator;
	private int idleState;
    private int meowState;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
		meowState = Animator.StringToHash("Base Layer.blackcatMeow");
        idleState = Animator.StringToHash("Base Layer.blackcatIdle");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
        GameObject teaserClone = GameObject.Find("cat teaser(Clone)");
        if(Input.GetKey(KeyCode.Space)&&!teaserClone)
        {
            m_animator.SetBool("isPlaying", true);
            tempTeaser = GameObject.Instantiate(teaser, Vector3.zero, Quaternion.identity) as GameObject;

        }
        else if(Input.GetKey(KeyCode.Space)&&teaserClone)
        {
            tempPos = gameObject.transform.position + new Vector3(2.0f, 1.0f,0);

            tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
            tempTeaser.transform.position = tempPos;
            tempTeaser.transform.eulerAngles = new Vector3 (0, 180, 0);
        }
        else
        {
            m_animator.SetBool("isPlaying", false);
    		GameObject.Destroy(tempTeaser);
        }

    }
}
