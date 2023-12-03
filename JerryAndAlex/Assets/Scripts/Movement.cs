using Unity.VisualScripting;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{   
    public float movementSpeed = 5f;
    public float sprintMultiplier = 2f;
    public float sprintMax = 10f;
    private float sprint = 0;
    public float sprintCooldown = 3f;
    private float cooldown;
    public float sprintRegain = 3;
    private float barSize;
    public Transform sprintBar;
    
    void Start() {
        barSize = sprintBar.localScale.x;
        cooldown = sprintCooldown;
        sprint = sprintMax;
    }
    void Update()
    {
        if(sprint != 10){
            cooldown -= Time.deltaTime;
        }

        if(cooldown <= 0){
            sprint += Time.deltaTime*sprintRegain;
            if(sprint > sprintMax)
                sprint = sprintMax;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float IsSprint = 1;
        
        if(sprint> 0 && Input.GetKey(KeyCode.LeftShift)){
            IsSprint = sprintMultiplier;
            cooldown = sprintCooldown;
            sprint -= 1*Time.deltaTime;
        }
        
        transform.position += new Vector3(horizontalInput * movementSpeed * Time.deltaTime * IsSprint, verticalInput * movementSpeed * Time.deltaTime * IsSprint, 0);

        sprintBar.localScale= new Vector2(sprint/sprintMax*barSize,sprintBar.localScale.y);
    }
}