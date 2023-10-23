using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using System.IO;
using System;

public class sensor : MonoBehaviour
{
    public XRNode node;

    public bool tracked = false; // �f�[�^�擾�\��
    public Vector3 position; // �ʒu
    public Quaternion rotation; // ����
    public Vector3 velocity; // ���x
    public Vector3 acceleration; // �����x
    public Vector3 angularVelocity; // �p���x
    public Vector3 angularAcceleration; // �p�����x

    private OtherFileStorage positionOtherFileStorage;
    private OtherFileStorage rotateOtherFileStorage;
    private OtherFileStorage angularVelocityOtherFileStorage;
    private OtherFileStorage velocityOtherFileStorage;

    DateTime dt;

    public GameObject scoreObject = null;
    private string output = "";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        positionOtherFileStorage = new OtherFileStorage("position", 3);
        rotateOtherFileStorage = new OtherFileStorage("rotate", 4);
        angularVelocityOtherFileStorage = new OtherFileStorage("angularVelocity", 3);
        velocityOtherFileStorage = new OtherFileStorage("velocity", 3);
    }

    // Update is called once per frame
    void Update()
    {
        dt = DateTime.Now;

        List<XRNodeState> states = new List<XRNodeState>();
        InputTracking.GetNodeStates(states);
        foreach (XRNodeState s in states)
        {
            Debug.Log(s);
            // �f�[�^�̎擾������
            tracked = s.tracked;
            s.TryGetPosition(out position);
            s.TryGetRotation(out rotation);
            s.TryGetVelocity(out velocity);
            s.TryGetAcceleration(out acceleration);
            s.TryGetAngularVelocity(out angularVelocity);
            s.TryGetAngularAcceleration(out angularAcceleration);


            string positionText = string.Format("{0},{1},{2}", position.x, position.y, position.z);
            string rotateText = string.Format("{0},{1},{2},{3}", rotation.x, rotation.y, rotation.z, rotation.w);
            string velocityText = string.Format("{0},{1},{2}", velocity.x, velocity.y, velocity.z);
            string angularVelocityText = string.Format("{0},{1},{2}", angularVelocity.x, angularVelocity.y, angularVelocity.z);

            Debug.Log(string.Format("{0},{1}",dt, positionText));

            positionOtherFileStorage.doLog(positionText);
            rotateOtherFileStorage.doLog(rotateText);
            velocityOtherFileStorage.doLog(velocityText);
            angularVelocityOtherFileStorage.doLog(angularVelocityText);

            output = positionOtherFileStorage + "\n" +rotateOtherFileStorage + "\n" + velocityOtherFileStorage + "\n" + angularAcceleration;

            Text score = scoreObject.GetComponent<Text>();
            score.text = output;

            break; // ����ȏニ�[�v�𑱂��Ȃ�
        }
    }
}
