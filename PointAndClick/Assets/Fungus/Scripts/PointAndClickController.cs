using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickController : MonoBehaviour
{
    public Vector2 followSpot;
    public float speed;
    public float perspectiveScale;
    public float scaleRatio;
    public bool inDialogue;
    public bool cutSceneInProgress;

    private NavMeshAgent agent;
    private Verb verb;

    // Start is called before the first frame update
    void Start()
    {
        followSpot = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        verb = FindObjectOfType<Verb>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inDialogue)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                followSpot = new Vector2(mousePosition.x, mousePosition.y);
            }
            agent.SetDestination(new Vector3(followSpot.x, followSpot.y, transform.position.z));
        }
    }

    private void ChangePerspective()
    {
        Vector3 scale = transform.localScale;
        scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = scale;
    }

    public void ExitDialogue()
    {
        inDialogue = false;
        cutSceneInProgress = false;

        verb.verb = Verb.Action.Walk;
        verb.UpdateVerbTextBox(null);
        verb.gameObject.SetActive(true);
    }

    public void EnterDialogue()
    {
        inDialogue = true;
        cutSceneInProgress = true;

        verb.verb = Verb.Action.Walk;
        verb.UpdateVerbTextBox(null);
        verb.gameObject.SetActive(false);
    }
}
