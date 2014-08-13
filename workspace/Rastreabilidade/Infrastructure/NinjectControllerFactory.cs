using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Entidades;
using Rastreabilidade.Persistence.Mongo;

namespace Rastreabilidade.Infrastructure {

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

            ninjectKernel.Bind<IRepository<Modulo>>().To<MongoRepository<Modulo>>();
            ninjectKernel.Bind<IRepository<Busca>>().To<MongoRepository<Busca>>();
            ninjectKernel.Bind<IRepository<CasoUso>>().To<MongoRepository<CasoUso>>();
            ninjectKernel.Bind<IRepository<Tabela>>().To<MongoRepository<Tabela>>();
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