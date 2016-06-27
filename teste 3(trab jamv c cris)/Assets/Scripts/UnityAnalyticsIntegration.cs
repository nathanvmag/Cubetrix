using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;
public class UnityAnalyticsIntegration : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        const string projectId = "b80c36bb-02db-408a-bd3d-cca16871961f";
        UnityAnalytics.StartSDK(projectId);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
