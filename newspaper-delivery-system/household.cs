﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newspaper_delivery_system
{
    // Households subscribe to publications and are delivered to by carriers
    public class Household : Carrier
    {
        private List<Publication> subscriptions = new List<Publication>(); // Publications household is subscribed to
        private bool suspended; // if household is suspended from receiving delivery

        // getter and setter
        public bool Suspended
        {
            get { return suspended; }
            set { suspended = value; }
        }

        // default constructor with constructor delegation
        public Household(string _name = "NO_NAME", string _address = "NO_ADDRESS", string _phone = "NO_PHONE", bool _suspended = false) : base(_name, _address, _phone)
        {
            suspended = _suspended;
        }

        // subscription methods
        // ====================

        // check if household has subscription
        public bool hasSubscription(Publication sub)
        {
            // subscription to look for
            Publication found = subscriptions.Find(item => item.Name == sub.Name);

            if (found == null)
                return false;
            return true;
        }

        // add subscription to list
        public void addSubscription(Publication sub)
        {
            sub.incrementSubs();
            sub.incrementOwed();
            subscriptions.Add(sub);

        }

        // remove subscription from list
        public bool removeSubscription(int index)
        {
            // new remove method
            int originalCount = subscriptions.Count;
            subscriptions.RemoveAt(index);
            int newCount = subscriptions.Count;
            if (originalCount > newCount)
                return true;
            else
                return false;
        }

        // display all subscriptions
        public List<Publication> getAllSubscriptions()
        {

            if (subscriptions.Count == 0)
                return null;

            return subscriptions;
        }

        // toString
        public override string ToString()
        {
            return base.ToString() + " Suspended: " + suspended;
        }
    }
}

