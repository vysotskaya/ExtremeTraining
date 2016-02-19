using System.Collections.Generic;
using System.Data.Entity;

namespace ORM
{
    public class WunderlistDbInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            IList<State> states = new List<State>()
            {
                new State() {StateName = "Active"},
                new State() {StateName = "Completed"}
                //other states
            };
            foreach (State state in states)
            {
                context.Set<State>().Add(state);
            }

            base.Seed(context);
        }
    }
}
