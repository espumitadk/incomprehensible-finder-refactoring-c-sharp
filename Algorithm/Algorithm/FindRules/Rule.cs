using System.Collections.Generic;

namespace Algorithm.FindRules
{
    public interface Rule
    {
        FindResults ApplyOn(List<RealPerson> people);
    }

}