using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class RulesContainer
    {
        private readonly List<Rules> _list;
        public RulesContainer()
        {
            _list = new List<Rules>();
        }
        public void AddRule(Rules rules)
        {
            _list.Add(rules);
            // Subscribe to the base class event.
            rules.RuleChanged += HandleRuleChanged;
        }
        public List<Rules> ListRule()
        {
            return _list;
        }
        // ...Other methods to draw, resize, etc.

        private void HandleRuleChanged(object sender, RuleEventArgs e)
        {
            if (sender is Rules rules)
            {
                // Diagnostic message for demonstration purposes.
                Console.WriteLine($"Received event. Shape area is now {e.NewArea}");
                // Redraw the shape here.
              //  rules.Draw();
            }
        }
    }
}
