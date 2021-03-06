﻿using System;
using System.Collections.Generic;

namespace Plugin.AzurePushNotification.Abstractions
{
    public delegate void AzurePushNotificationTokenEventHandler(object source, AzurePushNotificationTokenEventArgs e);

    public class AzurePushNotificationTokenEventArgs : EventArgs
    {
        public string Token { get; }

        public AzurePushNotificationTokenEventArgs(string token)
        {
            Token = token;
        }

    }

    public delegate void AzurePushNotificationErrorEventHandler(object source, AzurePushNotificationErrorEventArgs e);

    public class AzurePushNotificationErrorEventArgs : EventArgs
    {
        public string Message { get; }

        public AzurePushNotificationErrorEventArgs(string message)
        {
            Message = message;
        }

    }

    public delegate void AzurePushNotificationDataEventHandler(object source, AzurePushNotificationDataEventArgs e);

    public class AzurePushNotificationDataEventArgs : EventArgs
    {
        public IDictionary<string, object> Data { get; }

        public AzurePushNotificationDataEventArgs(IDictionary<string, object> data)
        {
            Data = data;
        }

    }


    public delegate void AzurePushNotificationResponseEventHandler(object source, AzurePushNotificationResponseEventArgs e);

    public class AzurePushNotificationResponseEventArgs : EventArgs
    {
        public string Identifier { get; }

        public IDictionary<string, object> Data { get; }

        public NotificationCategoryType Type { get; }

        public AzurePushNotificationResponseEventArgs(IDictionary<string, object> data, string identifier = "", NotificationCategoryType type = NotificationCategoryType.Default)
        {
            Identifier = identifier;
            Data = data;
            Type = type;
        }

    }

    /// <summary>
    /// Interface for AzurePushNotification
    /// </summary>
    public interface IAzurePushNotification
    {
        /// <summary>
        /// Get all user notification categories
        /// </summary>
        NotificationUserCategory[] GetUserNotificationCategories();
        /// <summary>
        /// Get all subscribed tags
        /// </summary>
        string[] Subscribedtags { get; }
        /// <summary>
        /// Subscribe to multiple tags
        /// </summary>
        void Register(string[] tags);
        /// <summary>
        /// Subscribe to one tag
        /// </summary>
        void Register(string tag);
        /// <summary>
        /// Unsubscribe to one tag
        /// </summary>
        void Unregister(string tag);
        /// <summary>
        /// Unsubscribe to multiple tags
        /// </summary>
        void Unregister(string[] tags);
        /// <summary>
        /// Unsubscribe all tags
        /// </summary>
        void UnregisterAll();
        /// <summary>
        /// Notification handler to receive, customize notification feedback and provide user actions
        /// </summary>
        IPushNotificationHandler NotificationHandler { get; set; }

        /// <summary>
        /// Event triggered when token is refreshed
        /// </summary>
        event AzurePushNotificationTokenEventHandler OnTokenRefresh;
        /// <summary>
        /// Event triggered when a notification is opened
        /// </summary>
        event AzurePushNotificationResponseEventHandler OnNotificationOpened;
        /// <summary>
        /// Event triggered when a notification is received
        /// </summary>
        event AzurePushNotificationDataEventHandler OnNotificationReceived;
        /// <summary>
        /// Event triggered when there's an error
        /// </summary>
        event AzurePushNotificationErrorEventHandler OnNotificationError;
        /// <summary>
        /// Push notification token
        /// </summary>
        string Token { get; }
    }
}
