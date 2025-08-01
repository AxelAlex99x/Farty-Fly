using System;
using System.Collections;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class VerifyLastTimePlay : MonoBehaviour
{
    [SerializeField] private NotificationHandler notificationHandler;
    [SerializeField] private int notificationDelay = 24;
    [SerializeField] private int maxNotifications = 1;

    private void Start()
    {
        #if UNITY_ANDROID
        AndroidNotificationCenter.CancelAllNotifications();
        StartCoroutine(RequestPermission());
        #endif
    }

    private IEnumerator RequestPermission()
    {
        yield return notificationHandler.RequestNotificationPermission();
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            for (int i = 1; i <= maxNotifications; i++)
            {
                DateTime notificationTime = DateTime.Now.AddHours(notificationDelay * i);
                #if UNITY_ANDROID
                notificationHandler.ScheduleNotification(notificationTime);
                #endif
            }
        }
    }
}
