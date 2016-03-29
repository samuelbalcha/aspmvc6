namespace demo.models
{
    public class SuperHero
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        /**
            public virtual ICollection<SuperPower> Powers { get; set; }
            public virtual ICollection<SuperHero> Friends { get; set; }
        **/
    }
}
