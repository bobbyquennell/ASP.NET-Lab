using QuantumITSchoolGPA.Models;
using StructureMap;
namespace QuantumITSchoolGPA {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<ISchoolGpaDataSource>().HttpContextScoped().Use<SchoolGpaDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}