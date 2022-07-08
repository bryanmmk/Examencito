using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Interfaces
{
    public interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}
