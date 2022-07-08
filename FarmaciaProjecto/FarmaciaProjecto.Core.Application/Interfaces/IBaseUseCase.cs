using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Interfaces;

namespace FarmaciaProjecto.Core.Application.Interfaces
{
     interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>, IUpdate<Entity>, IDelete<EntityId>,
                       IRead<Entity, EntityId>
    {
    }
}
