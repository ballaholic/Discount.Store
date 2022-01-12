using Autofac;

using Discount.Store.Core.Interfaces;
using Discount.Store.Core.Services;

namespace Discount.Store.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CartService>().As<ICartService>().InstancePerLifetimeScope();
        }
    }
}
