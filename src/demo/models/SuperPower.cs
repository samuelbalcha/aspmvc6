namespace demo.models
{
    public class SuperPower
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual SuperHero Hero { get; set; }
    }
}
