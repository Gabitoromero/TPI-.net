using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class PlanInMemory
    {
        public static List<Plan> Planes;

        static PlanInMemory()
        {
            Planes = new List<Plan>
            {
                new Plan(1, "Plan Basico", 1),
                new Plan(2, "Plan Premium", 2),
                new Plan(3, "Plan Familiar", 3)
            };
        }
    }
}
