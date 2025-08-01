using System;
#if UNITY_ANDROID
using System.Collections;
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
    #if UNITY_ANDROID
    private const string ChannelId = "notification_channel";
    
    public IEnumerator RequestNotificationPermission()
    {
        #if UNITY_ANDROID
        PermissionStatus status = AndroidNotificationCenter.UserPermissionToPost;
        if (status == PermissionStatus.Allowed)
            yield break; 
        
        PermissionRequest request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
            yield return null; 
        #endif
    }

    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Bringing the player back",
            Importance = Importance.Default
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Come back to fart!",
            Text = "It seems that your stomach hurts, come back and release yourself! :)",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime
        };
        
        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
    #endif
}
