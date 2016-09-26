using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _p;

        public Finder(List<Person> p)
        {
            _p = p;
        }

        public F FindUsing(Rule rule)
        {
            var tr = new List<F>();

            for(var i = 0; i < _p.Count - 1; i++)
            {
                for(var j = i + 1; j < _p.Count; j++)
                {
                    var r = new F();
                    if(_p[i].BirthDate < _p[j].BirthDate)
                    {
                        r.FirstPerson = _p[i];
                        r.SecondPerson = _p[j];
                    }
                    else
                    {
                        r.FirstPerson = _p[j];
                        r.SecondPerson = _p[i];
                    }
                    r.D = r.SecondPerson.BirthDate - r.FirstPerson.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new F();
            }

            F answer = tr[0];
            foreach(var result in tr)
            {
                switch(rule)
                {
                    case Rule.Closest:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case Rule.Furthest:
                        if(result.D > answer.D)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}