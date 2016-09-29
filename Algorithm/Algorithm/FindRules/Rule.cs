using System.Collections.Generic;

namespace Algorithm.FindRules
{
    public interface Rule
    {
        QueryResult ApplyOn(List<Person> people);
    }

}