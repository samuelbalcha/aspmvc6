using demo.models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace demo.orm.Mappings
{
    public class SuperHeroMap : ClassMapping<SuperHero>
    {
        public SuperHeroMap()
        {
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.Name, m => {
                m.Column(c =>
                {
                    c.Name("Name");
                    c.NotNullable(true);
                    c.Unique(true);
                });
            });
            Bag(x => x.Powers, cp => { cp.Cascade(Cascade.Persist.Include(Cascade.Remove)); },
                cr => cr.OneToMany(x => x.Class(typeof(SuperPower))));
        }
    }
}
