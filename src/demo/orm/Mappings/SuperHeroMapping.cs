using demo.models;

namespace demo.orm.Mappings
{
    using FluentNHibernate.Mapping;
    public class SuperHeroMapping : ClassMap<SuperHero>
    {
        public SuperHeroMapping()
        {
            Table("SuperHeros");
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
