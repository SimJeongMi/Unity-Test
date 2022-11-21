using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float dash = 5f;
    public float rotSpeed = 3f;

    private Vector3 dir = Vector3.zero;

    private bool ground = false;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        CheckGround();

        if (Input.GetButtonDown("Jump") && ground)
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }

        // Rigidbody ������Ʈ�� Drag ���� 0 �� ä�� ���� �ڵ带 �����ϸ�
        // rigidbody.force assign attempt for 'Player' is not valid. Input force is { -Infinity, -Infinity, -Infinity }.
        // ��� ������ ��Ÿ����.
        // �ν�����â���� Drag ���� 5 ������ �����ָ� �ȴ�.
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashPower = transform.forward * -Mathf.Log(1 / rigidbody.drag) * dash;
            rigidbody.AddForce(dashPower, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {
            // ���� �ٶ󺸴� ������ ��ȣ != ���ư� ���� ��ȣ
            if (Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0, 1, 0);
            }
            // Time.deltaTime�� ����ϸ� �ʹ� ������ rotSpeed�� �����ش�.
            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }

    void CheckGround()
    {
        RaycastHit hit;

        // ĳ������ �� ������ 0.2 ��ŭ ���� ��ġ���� �Ʒ��������� ���. 0.4��ŭ �������� �߻�ȴ�.
        // �� ���� �ȿ��� �츮�� ������ ���̾ ������ �Ǹ� �� ������ hit�� ��´�.
        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        {
            ground = true;

            Debug.DrawRay(transform.position + (Vector3.up * 0.2f), Vector3.down * hit.distance, Color.red);
        }
        else
        {
            ground = false;
        }
    }
}
