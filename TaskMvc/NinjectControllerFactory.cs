using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Implementations;
using BusinessLogic.Interfaces;
using Domain;
using Ninject;

namespace Web
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        //Витягуємо екземпляр контроллера для заданого контексту запиту і типу контролера
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        //Оприділяємо всі привязки
        private void AddBindings()
        {
            ninjectKernel.Bind<IUsersRepository>().To<EFUsersRepository>();
           
            ninjectKernel.Bind<EFDbContext>().ToSelf().WithConstructorArgument("connectionString",
                                                                               ConfigurationManager.ConnectionStrings[0]
                                                                                   .ConnectionString);
            ninjectKernel.Inject(Membership.Provider);
        }
    }
}