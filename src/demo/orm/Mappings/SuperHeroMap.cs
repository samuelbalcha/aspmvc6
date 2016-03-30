using demo.models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace demo.orm.Mappings
{
    public class SuperHeroMap : ClassMapping<SuperHero>
    {
        public SuperHeroMap()
        {
            Id<int>(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.Name, m => {
                m.Column(c =>
                {
                    c.Name("Name");
                    c.NotNullable(true);
                    c.Unique(true);
                });
            });
            Bag<SuperPower>(x => x.Powers, cp => { }, cr => cr.OneToMany(x => x.Class(typeof(SuperPower))));
        }
    }
}
