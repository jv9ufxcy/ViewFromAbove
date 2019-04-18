﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateLookedAtObjects : MonoBehaviour
{
    [SerializeField]    private float maxActivateDistance = 6.0f;

    [SerializeField] TextMeshProUGUI lookedAtObjectText;

    private IActivatable objectLookedAt;

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * maxActivateDistance);

        UpdateObjectLookedAt();
        UpdateLookedAtObjectText();
        ActivateLookedAtObject();
    }

    private void ActivateLookedAtObject()
    {
        if (objectLookedAt != null)
        {
            if (Input.GetButtonDown("Submit"))
            {
                objectLookedAt.DoActivate();
            }
        }
    }

    private void UpdateLookedAtObjectText()
    {
        if (objectLookedAt != null)
            lookedAtObjectText.text = objectLookedAt.NameText+ " (E)";
        else
            lookedAtObjectText.text = "";
    }

    private void UpdateObjectLookedAt()
    {
        RaycastHit hit;
        objectLookedAt = null;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxActivateDistance))
        {
            Debug.Log("Hit: " + hit.transform.name);

            objectLookedAt = hit.transform.GetComponent<IActivatable>();
        }
    }
}
