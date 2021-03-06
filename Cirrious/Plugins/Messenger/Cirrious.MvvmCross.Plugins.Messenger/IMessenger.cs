﻿// IMessenger.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;

namespace Cirrious.MvvmCross.Plugins.Messenger
{
    public interface IMessenger
    {
        /// <summary>
        /// Subscribe to a message type with the given destination and delivery action.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="useStrongReference">Use a strong reference to the deliveryAction</param>
        /// <returns>MessageSubscription used to unsubscribing</returns>
        SubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, bool useStrongReference = false)
            where TMessage : BaseMessage;

        /// <summary>
        /// Unsubscribe from a particular message type.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="subscriptionId">Subscription to remove</param>
        void Unsubscribe<TMessage>(SubscriptionToken subscriptionId)
            where TMessage : BaseMessage;

        /// <summary>
        /// Publish a message to any subscribers
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        void Publish<TMessage>(TMessage message) where TMessage : BaseMessage;

        /// <summary>
        /// Publish a message to any subscribers
        /// - GetType() will be used to determine the message type
        /// </summary>
        /// <param name="message">Message to deliver</param>
        void Publish(BaseMessage message);

        /// <summary>
        /// Publish a message to any subscribers
        /// </summary>
        /// <param name="message">Message to deliver</param>
        /// <param name="messageType">The type of the message to use for delivery - message should be of that class or a of a subclass</param>
        void Publish(BaseMessage message, Type messageType);
    }
}