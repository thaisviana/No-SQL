using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using BIC.Entidades.Persistence;
using BIC.Entidades;
using BIC.Persistence.Mongo;

namespace BIC.Infrastructure {

    /// <summary>
    /// Factory responsável pela fabricação de controllers e injeção de dependências
    /// </summary>
    public class NinjectControllerFactory : DefaultControllerFactory {

        private IKernel ninjectKernel;

        /// <summary>
        /// Instancia o kernel do Ninject e configura o mapeamento de interfaces
        /// </summary>
        public NinjectControllerFactory() {
            ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IRepository<Item>>().To<MongoRepository<Item>>();
        }

        /// <summary>
        /// Sobrescreve o método padrão da fábrica de controllers, executando 
        /// o construtor com os parâmetros corretos (segundo o mapeamento de interfaces feito acima)
        /// </summary>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}