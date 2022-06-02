using System.Collections.Generic;

namespace AzureAPI.Domain.Entity
{
    public abstract class EntityBase
    {
        public long Id { get; set; }

        internal List<string> _errors;

        public IReadOnlyCollection<string> Erros => _errors;

        public abstract bool Validate();
    }
}
