using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;
using FarmaciaProjecto.Core.Domain.Interfaces;

namespace FarmaciaProjecto.Core.Infraestructure.Repository.Abstract
{
    public interface IBaseRepository<Entity,EntityId> : ICreate<Entity>,IRead<Entity,EntityId>
                    ,IUpdate<Entity>,IDelete<EntityId>,ITransaction
    {
    }
}
