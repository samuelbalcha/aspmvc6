using System.Collections.Generic;

namespace demo.models
{
    public class SuperHero
    {
        public SuperHero()
        {
            Powers = new List<SuperPower>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<SuperPower> Powers { get; set; }

        /**
            public virtual ICollection<SuperHero> Friends { get; set; }
        **/
    }
}
