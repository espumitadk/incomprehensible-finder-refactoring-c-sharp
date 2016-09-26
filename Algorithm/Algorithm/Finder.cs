using System;
using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> people;

        public Finder(List<Person> people)
        {
            this.people = people;
        }

        public QueryResult FindUsing(Rule rule)
        {
            var queryResult = new List<QueryResult>();

            for(var i = 0; i < people.Count - 1; i++)
            {
                for(var j = i + 1; j < people.Count; j++)
                {
                    var result = new QueryResult();
                    if(people[i].BirthDate < people[j].BirthDate)
                    {
                        result.FirstPerson = people[i];
                        result.SecondPerson = people[j];
                    }
                    else
                    {
                        result.FirstPerson = people[j];
                        result.SecondPerson = people[i];
                    }
                    result.BirthDateDiference = BirthDateDiference(result);
                    queryResult.Add(result);
                }
            }

            if(queryResult.Count < 1)
            {
                return new QueryResult();
            }

            QueryResult answer = queryResult[0];
            foreach(var result in queryResult)
            {
                switch(rule)
                {
                    case Rule.Closest:
                        if(result.BirthDateDiference < answer.BirthDateDiference)
                        {
                            answer = result;
                        }
                        break;

                    case Rule.Furthest:
                        if(result.BirthDateDiference > answer.BirthDateDiference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }

        private static TimeSpan BirthDateDiference(QueryResult result)
        {
            return result.SecondPerson.BirthDate - result.FirstPerson.BirthDate;
        }
    }
}