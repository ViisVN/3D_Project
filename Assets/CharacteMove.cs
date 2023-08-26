using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacteMove : MonoBehaviour
{
    private static CharacteMove m_instance;
    public static CharacteMove Instance => m_instance;
    public float moveSpeed = 5f;
    public Rigidbody rb;
    public Animator animator;
    public NavMeshAgent _navmesh;
    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        m_instance = this;
  _navmesh = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Tạo vector di chuyển từ input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        // Di chuyển nhân vật bằng Rigidbody
        rb.MovePosition(transform.position + movement);
        // Xác định hướng di chuyển để xoay nhân vật
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        // Tính tốc độ
        float speed = movement.magnitude / Time.deltaTime;

        // Đặt giá trị "Speed" trong Animator
        animator.SetFloat("Speed", speed);

        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(newRotation);
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //var pos = GetGroundCheckPos();
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(pos, groundCheckRadius);
    }
#endif

}
