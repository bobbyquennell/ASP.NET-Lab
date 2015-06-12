using OdeToFoodExercise.Models;
using StructureMap;
namespace OdeToFoodExercise {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IOdeToFoodDataSource>().Use<OdeToFoodDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}