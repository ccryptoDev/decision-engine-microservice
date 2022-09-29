using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public abstract class Rules
    {
        protected string _ruleMessage;

        public string RuleMessage
        {
            get => _ruleMessage;
            set => _ruleMessage = value;
        }
        protected int _ruleVal;

        public int RuleVal
        {
            get => _ruleVal;
            set => _ruleVal = value;
        }
        protected string _ruleId;

        public string RuleId
        {
            get => _ruleId;
            set => _ruleId = value;
        }
        // The event. Note that by using the generic EventHandler<T> event type
        // we do not need to declare a separate delegate type.
        public event EventHandler<RuleEventArgs> RuleChanged;

        // public abstract void Draw();

        //The event-invoking method that derived classes can override.
        protected virtual void OnRuleChanged(RuleEventArgs e)
        {
            // Safely raise the event for all subscribers
            RuleChanged?.Invoke(this, e);
        }

        protected virtual int OnRuleCheck(int ruleFrom,int ruleTo,string declinedif)
        {
            if (declinedif == ">")
            {
                if (ruleFrom > ruleTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == "<")
            {
                if (ruleFrom < ruleTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == "<=")
            {
                if (ruleFrom <= ruleTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == ">=")
            {
                if (ruleFrom >= ruleTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == "=")
            {
                if (ruleFrom == ruleTo)
                    return 1;
                else
                    return 0;
            }
            else
            {
                if (ruleFrom == ruleTo)
                    return 1;
                else
                    return 0;
            }

        }

        protected virtual int OnRuleDateCheck(DateTime ruleDateFrom, DateTime ruleDateTo, string declinedif)
        {
            if (declinedif == ">")
            {
                if (ruleDateFrom > ruleDateTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == "<")
            {
                if (ruleDateFrom < ruleDateTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == "<=")
            {
                if (ruleDateFrom <= ruleDateTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == ">=")
            {
                if (ruleDateFrom >= ruleDateTo)
                    return 1;
                else
                    return 0;
            }
            else if (declinedif == "=")
            {
                if (ruleDateFrom == ruleDateTo)
                    return 1;
                else
                    return 0;
            }
            else
            {
                if (ruleDateFrom != ruleDateTo)
                    return 1;
                else
                    return 0;
            }

        }

        protected virtual string declinedvalue(string declinedName)
        {
            Hashtable declined = new Hashtable();
            declined.Add("lt", "<"); //adding a key/value using the Add() method
            declined.Add("gt", ">");
            declined.Add("gte", ">=");
            declined.Add("lte", "<=");
            declined.Add("eq", "=");
            return declined[declinedName].ToString();

        }
        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int m1;
            int m2;
            if (d1 < d2)
            {
                m1 = (d2.Month - d1.Month);//for years
                m2 = (d2.Year - d1.Year) * 12; //for months
            }
            else
            {
                m1 = (d1.Month - d2.Month);//for years
                m2 = (d1.Year - d2.Year) * 12; //for months
            }

            return m1 + m2;
        }
    }
}
