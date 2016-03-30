using NHibernate.Mapping.ByCode.Conformist;
using demo.models;
using NHibernate.Mapping.ByCode;

namespace demo.orm.Mappings
{
    public class SuperPowerMap : ClassMapping<SuperPower>
    {
        public SuperPowerMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Name, m => {
                m.Column(c => 
                    {
                        c.Name("Name");
                        c.NotNullable(true);
                    });
            });
            ManyToOne(x => x.Hero);
        }
    }
}
