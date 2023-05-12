using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _criticalRadius;
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _damageAmount;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private AudioClip[] _audioClips;

    /* 0 - idle
     * 1 - chase
     * 2 - attack
     */

    NavMeshAgent agent;
    Animator anim;
    float currentHealth;
    AudioSource aSource;
    TMP_Text enemyCount;

    private void Start()
    {
        enemyCount = GameObject.Find("ZombieCount").GetComponent<TMP_Text>();
        aSource = GetComponent<AudioSource>();
        _healthSlider.maxValue = _maxHealth;
        currentHealth = _maxHealth;
        _healthSlider.value = currentHealth;
        anim = GetComponent<Animator>();
        _target = PlayerManager.obj.player;
        agent = GetComponent<NavMeshAgent>();

        //to play idle audio
        PlayAudio(0);
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, _target.position);
        
        if(dist <= _criticalRadius)     //player found
        {
            anim.SetBool("isChasing",true);

            //to play chase audio
            PlayAudio(1);

            agent.SetDestination(_target.position);    

            //attack
            if(dist <= agent.stoppingDistance)
            {
                //to play attack audio
                PlayAudio(2);

                agent.isStopped = true;
                anim.SetBool("Attack", true);
                LookAtPlayer();
            }
            else
            {
                anim.SetBool("Attack",false);
            }
        }
        else
        {
            agent.isStopped = false;
        }
    }

    void PlayAudio(int audioIndex)
    {
        aSource.clip = _audioClips[audioIndex];
        aSource.Play();
    }

    void LookAtPlayer()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime);
    }

/*    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _criticalRadius);
    }
*/
    public void TakeDamage(float damageAmount)
    {
        if(currentHealth > 0)
        {
           _healthSlider.value -= damageAmount;
            currentHealth -= damageAmount;
        }

        //Debug.Log(name + "'s Health : " + currentHealth);

        if(currentHealth <= 0)
        {
            //death

            var collider = GetComponent<CapsuleCollider>().enabled = false;

            EnemyCounter.obj.enemyCount--;
            enemyCount.text = "ZOMBIES REMAINING : " + EnemyCounter.obj.enemyCount;
            anim.enabled = false;
            Destroy(this.gameObject, 1.5f);
        }
    }

    public void DealDamage()
    {
        Debug.Log("PLAYER KO DAMAGE DE DIYA !!! UEHUEHEUEHEHU");
        _target.GetComponent<PlayerHealth>().TakeDamage(_damageAmount);
    }
}