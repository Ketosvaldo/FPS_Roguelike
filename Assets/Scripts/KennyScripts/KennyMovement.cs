
using UnityEngine;

public class KennyMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    Vector3[] PatrolPoints;
    public int actualPoint;
    [SerializeField]
    float speed;
    [SerializeField]
    float rotationSpeed = 90.0f;

    [SerializeField]
    int damage;

    public bool stay, chase, attack, evade;
    float counter;

    Transform PlayerLocation;

    [SerializeField]
    int health = 100;
    GameManager manager;

    void Start()
    {
        transform.position = PatrolPoints[0];
        actualPoint = 0;
        rb = GetComponent<Rigidbody>();
        manager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (attack)
            return;
        if (chase)
        {
            Chase(PlayerLocation);
            return;
        }
        if (stay)
        {
            Stay();
            return;
        }
        Patrol();
    }

    void Patrol()
    {
        Vector3 directionToTarget = transform.position - PatrolPoints[actualPoint];

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        targetRotation.x = 0;
        targetRotation.z = 0;

        transform.rotation = targetRotation;

        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[actualPoint + 1], speed);

        if (new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)) != PatrolPoints[actualPoint + 1])
            return;
        stay = true;
    }

    void Stay()
    {
        counter += Time.deltaTime;
        if (counter < 3f)
            return;
        actualPoint = actualPoint < PatrolPoints.Length - 2 ? actualPoint + 1 : 0;
        counter = 0;
        stay = false;
    }

    void Chase(Transform Player)
    {
        Vector3 directionToTarget = Player.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        targetRotation.x = 0;
        targetRotation.z = 0;

        transform.rotation = targetRotation;
        if(!evade)
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * 1.5f);
        else
            transform.position = Vector3.MoveTowards(transform.position, Player.position + new Vector3(5, 0, 0), speed * 5f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15.0f))
        {
            if (hit.collider.name == "Character")
            {
                attack = true;
                chase = false;
                DealDamage(hit);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Character")
        {
            chase = true;
            PlayerLocation = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Character")
        {
            stay = true;
            chase = false;
        }
    }

    void DealDamage(RaycastHit hit)
    {
        hit.collider.gameObject.GetComponent<Stats>().MakeDamage(50);
        Invoke("DeactivateAttack", 3.0f);
    }

    void DeactivateAttack()
    {
        attack = false;
    }

    void DeactivateEvade()
    {
        evade = false;
    }

    public void MakeDamage(int damagePlayer)
    {
        rb.velocity = Vector3.zero;
        health -= damagePlayer;
        if (health <= 0)
            Death();
        int randomNum = Random.Range(0, 10);
        if (randomNum <= 3)
        {
            evade = true;
            Invoke("DeactivateEvade", 0.91f);
        }
    }

    void Death()
    {
        manager.ReducirEnemigos();
        Destroy(gameObject);
    }
}